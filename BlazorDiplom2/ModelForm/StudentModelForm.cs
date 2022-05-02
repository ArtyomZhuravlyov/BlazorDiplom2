using BlazorDiplom2.Data;
using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.ModelForm
{
    public class StudentModelForm : UserModelForm
    {     
        [Required]
        public string Group { get; set; }

        [Required]
        public string EducationalInstitution { get; set; }

    }
}
