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
    [Route("api/feature")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        //private Feature featuremodel;

        private readonly FeatureContext context;

        public FeaturesController(FeatureContext context)
        {
            this.context = context;
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
                Name = request.Name,
                InpDate = DateTime.Parse(request.InpDate)
            };

            this.context.Features.Add(feature);
            this.context.SaveChanges();

            //featuremodel.InsertFeature();

            return Ok(new { success = true });
        }
    }
}
