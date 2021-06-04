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
    [Route("api/v1/rarities")]
    public class RarityController : Controller
    {
        private readonly ESOTrialContext context;
        public RarityController(ESOTrialContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Rarity> GetAllRarities()
        {
            return context.Rarities.ToList();
        }
    }
}