using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Helpers.SampleDataManagers
{
    public class SubjectsSampleDataManager
    {
        public static Subject subject1 = new Subject("Matemática", TeachersSampleDataManager.teacher1.Id);
        public static Subject subject2 = new Subject("Limpeza de Gabinete", TeachersSampleDataManager.teacher2.Id);
        public static Subject subject3 = new Subject("Português", TeachersSampleDataManager.teacher3.Id);
        public static Subject subject4 = new Subject("Arquitetura de Servidores", TeachersSampleDataManager.teacher4.Id);
        public static Subject subject5 = new Subject("Programação", TeachersSampleDataManager.teacher5.Id);
        
    }
}