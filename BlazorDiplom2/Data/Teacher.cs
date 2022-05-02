namespace BlazorDiplom2.Data
{
    public class Teacher
    {
       
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string AspNetUsersId { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Group> Groups { get; set; } = new List<Group>();

        public List<Koan> Koans { get; set; } = new List<Koan>();


    }
}
