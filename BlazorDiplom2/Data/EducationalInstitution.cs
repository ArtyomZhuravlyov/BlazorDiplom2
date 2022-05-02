using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Data
{
    public class EducationalInstitution
    {
        public int Id { get; set; }

        [Required]
        public string ShortName { get; set; }

        [Required]
        public string FullName { get; set; }

        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
