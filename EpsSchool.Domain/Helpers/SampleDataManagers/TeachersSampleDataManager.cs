using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Helpers.SampleDataManagers
{
    public class TeachersSampleDataManager
    {
        public static Teacher teacher1 = new Teacher("José", "Roberto", "44778899", SubjectsSampleDataManager.subject1.Id);
        public static Teacher teacher2 = new Teacher("Carlos", "Eduardo", "33568941", SubjectsSampleDataManager.subject2.Id);
        public static Teacher teacher3 = new Teacher("Manuel", "Nobre", "99587462", SubjectsSampleDataManager.subject3.Id);
        public static Teacher teacher4 = new Teacher("João", "Olavo", "33506987", SubjectsSampleDataManager.subject4.Id);
        public static Teacher teacher5 = new Teacher("Lucas", "Ribas", "33214896", SubjectsSampleDataManager.subject5.Id);
        
    }
}