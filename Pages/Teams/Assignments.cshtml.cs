using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pool50.SQLite;

namespace Pool50.Pages
{
    public class AssignmentsModel:PageModel
    {
        [BindProperty]
        public List<Team> availableTeams {get; set;}

        [BindProperty]
        public bool canRequest {get; set;}

        [BindProperty]
        public List<Owner> ownerAssignments {get; set;}

        [BindProperty]
        public Team myTeam {get; set;}

        [BindProperty]
        public String action {get; set;}
        public IActionResult OnGet() 
        {
            PoolContext dbCtx = new PoolContext();
            availableTeams =dbCtx.Teams.OrderBy(t => t.Name).Where(t => !dbCtx.Owners.Select(o => o.TeamId).Contains(t.TeamId)).ToList();
            ownerAssignments = dbCtx.Owners.Include(o => o.Team).OrderBy(o => o.Username).ToList();
            checkCurrentOwnership(dbCtx);
            dbCtx.Dispose();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!"requestTeam".Equals(action)) {
                return OnGet();
            }
            PoolContext dbCtx = new PoolContext();
            availableTeams =dbCtx.Teams.OrderBy(t => t.Name).Where(t => !dbCtx.Owners.Select(o => o.TeamId).Contains(t.TeamId)).ToList();
            ownerAssignments = dbCtx.Owners.OrderBy(o => o.Username).ToList();
            checkCurrentOwnership(dbCtx);
            String userId = HttpContext.User.FindFirst(ClaimTypes.Name).Value.ToString();
            String fullName = findFullName();
            if (canRequest) {
                Team chosenTeam = availableTeams.ToArray()[new Random().Next(availableTeams.Count)];
                Owner newOwner = new Owner {
                    Username = userId,
                    Team = chosenTeam,
                    FullName = fullName
                };
                dbCtx.Owners.Add(newOwner);
                dbCtx.SaveChanges();
            }
            dbCtx.Dispose();
            return OnGet();
        }

        protected void checkCurrentOwnership(PoolContext dbCtx) {
            String userId = HttpContext.User.FindFirst(ClaimTypes.Name).Value.ToString();
            canRequest = false;
            myTeam = null;
            if ((userId != null)&&(userId.Length > 0))
            {
                Owner owner = dbCtx.Owners.Include(o => o.Team).Where(o => o.Username.Equals(userId)).DefaultIfEmpty(null).First();
                canRequest = owner == null;
                if (owner!=null) {
                    myTeam = owner.Team;
                }
            }
        }

        protected String findFullName() {
            String fullName = null;
            try {
                String givenName = HttpContext.User.FindFirst(ClaimTypes.GivenName).Value.ToString();
                String lastName = HttpContext.User.FindFirst(ClaimTypes.Surname).Value.ToString();
                fullName = lastName+", "+givenName;
            } catch (Exception)
            {
                fullName = null;
            }
            if (fullName == null) {
                try {
                    fullName = HttpContext.User.FindFirst("name").Value.ToString();
                } catch (Exception)
                {
                    fullName = null;
                }
            }
            if (fullName == null) {
                try {
                    fullName = HttpContext.User.FindFirst(ClaimTypes.Name).Value.ToString();
                } catch (Exception)
                {
                    fullName = null;
                }
            }
            if (fullName == null) {
                fullName = "<not available>";
            }
            return fullName;
        }
    }
}