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
    [Route("api/v1/traits")]
    public class TraitController : Controller
    {
        private readonly ESOTrialContext context;
        public TraitController(ESOTrialContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Trait> GetAllTraits([FromQuery]string name)
        {
            IQueryable<Trait> query = context.Traits;
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(t => t.name == name);
            }

            return query.ToList();
        }
    }
}