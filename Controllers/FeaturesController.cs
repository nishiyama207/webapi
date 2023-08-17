using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Entities;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly FeatureContext context;

        public FeaturesController(FeatureContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Feature>> List()
        {
            var features = context.Features;
            return features;
        }

        [HttpPost("save")]
        public IActionResult SaveFeature(FeatureRequest request)
        {
                    
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var feature = new Feature
            {
                Id = request.Id,
                Name = request.Name,
                InpDate = DateTime.Parse(request.InpDate)
            };

            // Addした段階ではSql文はDBに発行されない
            this.context.Features.Add(feature);

            // SaveChangesが呼び出された段階で初めてInsert文が発行される
            this.context.SaveChanges();

            // EntityFlameworkを使うとSQL文を書く必要はない


            return Ok(new { success = true });
        }
    }
}
