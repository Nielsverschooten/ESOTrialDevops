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
    [Route("api/v1/enchantments")]
    public class EnchantmentController : Controller
    {
        private readonly ESOTrialContext context;
        public EnchantmentController(ESOTrialContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Enchantment> GetAllEnchantments()
        {
            return context.Enchantments.ToList();
        }
    }
}