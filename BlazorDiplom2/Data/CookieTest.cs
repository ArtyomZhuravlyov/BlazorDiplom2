namespace BlazorDiplom2.Data
{
    public class CookieTest
    {
        private DateTime DateTimeStartTest { get; set; }

        public Test Test { get; set; }

        public List<CookieTestKoan> CookieTestKoan { get; set; } = new();

        public void StartTest(Test test)
        {
            Test = test;
            DateTimeStartTest = DateTime.Now;
        }

        //public bool isStart()
        //{
        //    if(DateTimeStartTest.Equals(new DateTime()))
        //        return false;
        //    else
        //        return true;
        //}

        public Enums.StatusTest GetStatus()
        {
            if (DateTimeStartTest.Equals(new DateTime()))
                return Enums.StatusTest.NotStart;
            else if (DateTime.Now.Subtract(DateTimeStartTest).TotalMinutes < Test?.Time.Minute)//if(DateTime.Now - DateTimeStartTest < TimeSpan())
                return Enums.StatusTest.InProgress;
            else
                return Enums.StatusTest.End;
        }

    }

    

    
}
