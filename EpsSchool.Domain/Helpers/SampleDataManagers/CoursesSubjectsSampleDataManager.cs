using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Helpers.SampleDataManagers
{
    public class CoursesSubjectsSampleDataManager
    {
        public static CourseSubject courseSubject1 = new CourseSubject(CoursesSampleDataManager.course1.Id, 
                                                                       SubjectsSampleDataManager.subject1.Id);
        public static CourseSubject courseSubject2 = new CourseSubject(CoursesSampleDataManager.course1.Id,
                                                                       SubjectsSampleDataManager.subject3.Id);
        public static CourseSubject courseSubject3 = new CourseSubject(CoursesSampleDataManager.course1.Id,
                                                                       SubjectsSampleDataManager.subject5.Id);
        public static CourseSubject courseSubject4 = new CourseSubject(CoursesSampleDataManager.course2.Id,
                                                                       SubjectsSampleDataManager.subject2.Id);
        public static CourseSubject courseSubject5 = new CourseSubject(CoursesSampleDataManager.course2.Id,
                                                                       SubjectsSampleDataManager.subject3.Id);
        public static CourseSubject courseSubject6 = new CourseSubject(CoursesSampleDataManager.course3.Id,
                                                                       SubjectsSampleDataManager.subject1.Id);
        public static CourseSubject courseSubject7 = new CourseSubject(CoursesSampleDataManager.course3.Id,
                                                                       SubjectsSampleDataManager.subject3.Id);
        public static CourseSubject courseSubject8 = new CourseSubject(CoursesSampleDataManager.course3.Id,
                                                                       SubjectsSampleDataManager.subject4.Id);
                                                                        
    }
}