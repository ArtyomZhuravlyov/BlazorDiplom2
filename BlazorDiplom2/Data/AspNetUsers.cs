using Microsoft.AspNetCore.Identity;

namespace BlazorDiplom2.Data
{
    public class AspNetUsers : IdentityUser
    {
        //public string SurName { get; set; }

        //public int? StudentId { get; set; }
        
        public Student? Student { get; set; }

        //public int? TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        //public int GroupId { get; set; }      // внешний ключ
        //public Group Group { get; set; }    // навигационное свойство
    }
}
