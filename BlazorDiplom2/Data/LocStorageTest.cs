namespace BlazorDiplom2.Data
{
    public class LocStorageTest
    {
        public DateTime DateTimeStartTest { get; set; }

        //public Test Test { get; set; }
        public int MinutesTest { get; set; }

        public int IdTest { get; set; }

        public int IdStudent { get; set; }

        public List<LocStorageTestKoan> ListLocStoragesTestKoan { get; set; } = new();

        public LocStorageTest(int idStudent)
        {
            IdStudent = idStudent;
        }

        public void StartTest(Test test/*, Student student*/)
        {
            IdTest = test.Id;
            //IdStudent = student.Id;
            MinutesTest = test.Time.Minute;
            DateTimeStartTest = DateTime.Now;
        }

        //public bool isStart()
        //{
        //    if(DateTimeStartTest.Equals(new DateTime()))
        //        return false;
        //    else
        //        return true;
        //}

        public Enums.StatusTest GetStatus(DB db, int idTest)
        {
            if(!IdTest.Equals(0) && !IdTest.Equals(idTest))
                return Enums.StatusTest.InProgressOtherTest;

            //if (DateTime.Now.Subtract(DateTimeStartTest).TotalMinutes < MinutesTest)
            //    ;

            ////Если человек не завершил тест кнопкой и вышел
            //if (!IdTest.Equals(idTest))
            //{

            //    //значит смотрим БД
            //    if (db.ResultTests.Where(x => x.TestId.Equals(idTest) && x.StudentId.Equals(IdStudent)).Count() == 0)
            //        return Enums.StatusTest.NotStart;
            //    else
            //        return Enums.StatusTest.End;
            //}
            //else
            //{

            //}

            //Если человек не завершил тест кнопкой и вышел, а время истекло
            //if(DateTime.Now.Subtract(DateTimeStartTest).TotalMinutes > MinutesTest
            //    && db.ResultTests.Where(x => x.TestId.Equals(idTest) && x.StudentId.Equals(IdStudent)).Count() == 0)
            //{

            //}

            if (DateTimeStartTest.Equals(new DateTime()) && db.ResultTests.Where(x=>x.StudentId.Equals(IdStudent) && x.TestId.Equals(idTest)).Count().Equals(0))
                return Enums.StatusTest.NotStart;
            else if (DateTime.Now.Subtract(DateTimeStartTest).TotalMinutes < MinutesTest)//if(DateTime.Now - DateTimeStartTest < TimeSpan())
                return Enums.StatusTest.InProgress;
            else
                return Enums.StatusTest.End;

        }

        public async void EndTestAsync(DB db)
        {
            List<ResultKoanTest> resultKoanTests = new();
            foreach(var item in ListLocStoragesTestKoan)
            {
                ResultKoanTest resultKoanTest = new()
                {
                    KoanInTestId = item.IdKoanInTest,
                    Answer = item.AnswerStudent,
                    IsError = !item.IsPassed,
                    Message = item.ErrorMessage
                };
                resultKoanTests.Add(resultKoanTest);
            }

            var score = ListLocStoragesTestKoan.Where(x => x.IsPassed).Count();
            var time = new DateTime(1, 1, 1, 0, MinutesTest, 0);
            if(DateTime.Now.Subtract(DateTimeStartTest).TotalMinutes < MinutesTest)
                time = new DateTime(1, 1, 1, 0, (int)DateTime.Now.Subtract(DateTimeStartTest).TotalMinutes, 0);

            ResultTest resultTest = new ResultTest()
            {
                Score = score,
                IsPassed = score >= db.Tests.First(x=>x.Id.Equals(IdTest)).MinScore,
                StudentId = IdStudent,
                ResultKoanTests = resultKoanTests,
                TestId = IdTest,
                Time = time

            };
            db.ResultTests.Add(resultTest);
            db.SaveChanges();
            
            await LocStorage.LocalStorage.SetItemAsync(Constants.LOC_STOR, Newtonsoft.Json.JsonConvert.SerializeObject(new LocStorageTest(IdStudent)));
        }

    }




}
