using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Data
{
    public class Student 
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string AspNetUsersId { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public List<ResultTest> ResultTests { get; set; } = new List<ResultTest>();

        public List<KoanInModule> KoanInModules { get; set; } = new List<KoanInModule>();

        //public List<Result_Learning> Result_Learnings { get; set; } = new List<Result_Learning>();
    }
}
