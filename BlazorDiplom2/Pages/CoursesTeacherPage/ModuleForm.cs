using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Pages.CoursesTeacherPage
{
    public class ModuleForm
    {
        public int Id { get; set; }

        public int Priority { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public double MinScore { get; set; }

        public List<string> ListKoanInModule { get; set; } = new List<string>();

        public List<string> ListKoanInTest { get; set; } = new List<string>();
    }
}
