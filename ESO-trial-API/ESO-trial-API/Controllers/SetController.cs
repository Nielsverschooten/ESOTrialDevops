using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESO_trial_API.Models;
using ESO_trial_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ESO_trial_API.Controllers
{
    [Authorize]
    [Route("api/v1/sets")]
    public class SetController:Controller
    {
        private readonly ESOTrialContext context;
        public SetController(ESOTrialContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Set> GetAllSets(int? page, string sort, int length = 2, string dir = "asc")
        {
            IQueryable<Set> query = context.Sets;
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "name":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.name);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.name);
                        }
                        break;
                    case "description":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.description);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.description);
                        }
                        break;
                }
            }
            if (page.HasValue)
            {
                query = query.Skip(page.Value * length);
                query = query.Take(length);
            }
            
            return query.ToList();
        }
    }
}
