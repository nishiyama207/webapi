using System.ComponentModel.DataAnnotations;

namespace webapi.Entities
{
    public class FeatureRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string InpDate { get; set; }
    }
}
