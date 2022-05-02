namespace BlazorDiplom2.Data
{
    public class Result_Learning
    {
        public int Id { get; set; }

        public bool IsPassed { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
