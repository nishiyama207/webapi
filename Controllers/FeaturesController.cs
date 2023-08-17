using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using webapi.Data;
using webapi.Entities;

namespace webapi.Controllers
{
    [Route("api/feature")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private Feature featuremodel;

        private readonly FeatureContext context;

        public FeaturesController(FeatureContext context)
        {
            this.context = context;
        }

        [HttpPost("save")]
        public IActionResult SaveFeature(FeatureRequest request)
        {
            featuremodel.InsertFeature();
        
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

            return Ok(new { success = true });
        }
    }
}
