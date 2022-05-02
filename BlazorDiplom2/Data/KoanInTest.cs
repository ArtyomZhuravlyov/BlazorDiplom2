using System.ComponentModel.DataAnnotations;

namespace BlazorDiplom2.Data
{
    public class KoanInTest
    {
        public int Id { get; set; }

        public int Priority { get; set; }

        public int KoanId { get; set; }
        [ValidateComplexType]
        public Koan Koan { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public List<ResultKoanTest> ResultKoanTests { get; set; } = new List<ResultKoanTest>();
    }
}
