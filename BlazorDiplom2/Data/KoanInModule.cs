using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Data
{
    public class KoanInModule
    {
        public int Id { get; set; }

        public int Priority { get; set; }

        public int KoanId { get; set; }
        [ValidateComplexType]
        public Koan Koan { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
