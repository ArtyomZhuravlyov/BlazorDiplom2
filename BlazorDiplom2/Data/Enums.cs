namespace BlazorDiplom2.Data
{
    public class Enums
    {
        public enum Roles //это если других ролей никогда не будет
        {
            Administrator,
            Teacher,
            Student
        }

        //public enum RolesRussian //это если других ролей никогда не будет
        //{
        //    Administrator,
        //    Teacher,
        //    Student
        //}

        public enum TabUniversityAndGroup
        {
            EducationalInstitutions,
         //   EditEducationalInstitution,
            AddEducationalInstitution,
           // EditGroup,
            Groups,
            AddGroup
        }

        public enum TabUsers
        {
            Users,
            AddUser
        }

        public enum TabKoansTeacher
        {
            Koans,
        //    EditKoan,
            AddKoan
        }

        
        public enum TabCoursesTeacher
        {
            Courses,
            AddCourse,
            AddGroupsToCourse
        }

        public enum TabTestStudent
        {
            Test,
            ResultTest
        }

        public enum StatusTest
        {
            NotStart,
            InProgress,
            End,
            InProgressOtherTest
        }



        //public enum ShowComponent
        //{
        //    CreateEdit,
        //    AddUser
        //}
    }
}
