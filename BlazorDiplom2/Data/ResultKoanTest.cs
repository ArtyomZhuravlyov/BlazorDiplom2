namespace BlazorDiplom2.Data
{
    public class ResultKoanTest
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public string Answer { get; set; }
        public bool IsError { get; set; }

        public int ResultTestId { get; set; }
        public ResultTest ResultTest { get; set; }

        public int KoanInTestId { get; set; }
        public KoanInTest KoanInTest { get; set; }
    }
}
