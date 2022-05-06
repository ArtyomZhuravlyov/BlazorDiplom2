using BlazorDiplom2.Data;
using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.ModelForm
{
    public class TeacherModelForm : UserModelForm
    {

        //[Required]
        public List<string> Groups { get; set; } = new();


    }
}
