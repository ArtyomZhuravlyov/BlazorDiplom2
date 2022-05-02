using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Data
{
    //[Index(nameof(Name), nameof(Link), IsUnique = true)]
    //[Index("IX_NameAndTeacher", nameof(Name), IsUnique = true)]
    //[Index("IX_NameAndTeacher", nameof(TeacherId), IsUnique = true)]
    [Index(nameof(Name), nameof(TeacherId), Name = "IX_NameAndTeacher", IsUnique = true)]
    //[Index("IX_NameAndTeacher", IsUnique = true)]
    public class Koan /*: ICloneable*/
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Link { get; set; }
        [Required]
        public string Description { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<KoanInModule> KoanInModules { get; set; } = new List<KoanInModule>();

        public List<KoanInTest> KoanInTests { get; set; } = new List<KoanInTest>();

        //public object Clone()
        //{
        //    return MemberwiseClone();
        //}

        public Koan Copy()
        {
            return (Koan)MemberwiseClone();
        }
    }
}
