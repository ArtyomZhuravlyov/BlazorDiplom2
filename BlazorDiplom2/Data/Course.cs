using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Data
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int? TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public List<Group> Groups { get; set; } = new List<Group>();

        [ValidateComplexType]
        public List<Module>  Modules { get; set; } = new List<Module>();

    }
}
