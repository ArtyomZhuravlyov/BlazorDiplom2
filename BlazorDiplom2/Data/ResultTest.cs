namespace BlazorDiplom2.Data
{
    public class ResultTest
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public double Score { get; set; }

        public bool IsPassed { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public List<ResultKoanTest> ResultKoanTests { get; set; } = new List<ResultKoanTest>();
    }
}
