using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Data
{
    public class Module
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Priority { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
        [ValidateComplexType]
        public Test Test { get; set; }
        [ValidateComplexType]

        public List<KoanInModule> KoanInModules { get; set; } = new List<KoanInModule>();

       

    }
}
