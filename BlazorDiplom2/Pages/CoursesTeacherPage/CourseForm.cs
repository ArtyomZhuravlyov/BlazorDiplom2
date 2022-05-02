
using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Pages.CoursesTeacherPage
{
    public class CourseForm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set;}

        public List<ModuleForm> ModuleForms { get; set;} = new List<ModuleForm>();
}
}
