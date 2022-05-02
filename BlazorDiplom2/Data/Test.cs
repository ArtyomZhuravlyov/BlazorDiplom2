using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Data
{
    public class Test
    {
        public int Id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public double MinScore { get; set; }
        [ValidateComplexType]
        public List<KoanInTest> KoanInTests { get; set; } = new List<KoanInTest>();

        public int ModuleId { get; set; }
        public Module Module { get; set; }

        public List<ResultTest> ResultTests { get; set; } = new List<ResultTest>();

    }
}
