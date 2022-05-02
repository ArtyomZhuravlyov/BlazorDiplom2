namespace BlazorDiplom2.Data
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public int? EducationalInstitutionId { get; set; }

        public EducationalInstitution? EducationalInstitution { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Student> Students { get; set; } = new List<Student>();

        
    }
}
