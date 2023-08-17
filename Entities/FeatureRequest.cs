using System.ComponentModel.DataAnnotations;

namespace webapi.Entities
{
    public class FeatureRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string InpDate { get; set; }
    }
}
