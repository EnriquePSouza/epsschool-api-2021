using System;
using System.Collections.Generic;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers.SampleDataManagers;

namespace EpsSchool.Domain.Helpers
{
    public class ListsManager
    {
        public static List<Student> LoadStudentsSampleData()
        {
            List<Student> output = new List<Student>();

            output.Add(StudentsSampleDataManager.student1);
            output.Add(StudentsSampleDataManager.student2);
            output.Add(StudentsSampleDataManager.student3);
            output.Add(StudentsSampleDataManager.student4);
            output.Add(StudentsSampleDataManager.student5);
            output.Add(StudentsSampleDataManager.student6);
            output.Add(StudentsSampleDataManager.student7);
            output.Add(StudentsSampleDataManager.student8);
            output.Add(StudentsSampleDataManager.student9);

            return output;
        }

        public static List<Teacher> LoadTeachersSampleData()
        {
            List<Teacher> output = new List<Teacher>();

            output.Add(TeachersSampleDataManager.teacher1);
            output.Add(TeachersSampleDataManager.teacher2);
            output.Add(TeachersSampleDataManager.teacher3);
            output.Add(TeachersSampleDataManager.teacher4);
            output.Add(TeachersSampleDataManager.teacher5);

            return output;
        }

        public static List<Course> LoadCoursesSampleData()
        {
            List<Course> output = new List<Course>();

            output.Add(CoursesSampleDataManager.course1);
            output.Add(CoursesSampleDataManager.course2);
            output.Add(CoursesSampleDataManager.course3);

            return output;
        }

        public static List<Subject> LoadSubjectsSampleData()
        {
            List<Subject> output = new List<Subject>();

            output.Add(SubjectsSampleDataManager.subject1);
            output.Add(SubjectsSampleDataManager.subject2);
            output.Add(SubjectsSampleDataManager.subject3);
            output.Add(SubjectsSampleDataManager.subject4);
            output.Add(SubjectsSampleDataManager.subject5);

            return output;
        }

        public static List<CourseSubject> LoadCoursesSubjectsSampleData()
        {
            List<CourseSubject> output = new List<CourseSubject>();

            output.Add(CoursesSubjectsSampleDataManager.courseSubject1);
            output.Add(CoursesSubjectsSampleDataManager.courseSubject2);
            output.Add(CoursesSubjectsSampleDataManager.courseSubject3);
            output.Add(CoursesSubjectsSampleDataManager.courseSubject4);
            output.Add(CoursesSubjectsSampleDataManager.courseSubject5);
            output.Add(CoursesSubjectsSampleDataManager.courseSubject6);
            output.Add(CoursesSubjectsSampleDataManager.courseSubject7);
            output.Add(CoursesSubjectsSampleDataManager.courseSubject8);

            return output;
        }

        public static List<StudentCourseSubject> LoadStudentCoursesSubjectsSampleData()
        {
            List<StudentCourseSubject> output = new List<StudentCourseSubject>();

            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject1);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject2);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject3);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject4);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject5);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject6);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject7);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject8);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject9);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject10);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject11);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject12);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject13);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject14);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject15);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject16);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject17);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject18);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject19);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject20);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject21);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject22);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject23);
            output.Add(StudentsCoursesSubjectsSampleDataManager.studentCourseSubject24);

            return output;
        }

        public static List<Student> LoadStudentQueriesTestsSampleData()
        {
            Student studentQuery1 = StudentsSampleDataManager.student1;
            Student studentQuery2 = StudentsSampleDataManager.student2;
            Student studentQuery3 = StudentsSampleDataManager.student3;

            studentQuery1.Id = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");
            studentQuery1.Enrollment = DateTime.Now.ToString("yydd") +
                           studentQuery1.Id.GetHashCode().ToString().Replace("-", "0").Substring(0, 4);
            
            studentQuery2.Id = new Guid("2ae369e0-632d-45db-ade9-ebbcc2a21bd9");
            studentQuery2.Enrollment = DateTime.Now.ToString("yydd") +
                           studentQuery2.Id.GetHashCode().ToString().Replace("-", "0").Substring(0, 4);
            
            studentQuery3.Id = new Guid("bdad5b21-e879-45fd-9cb2-c7530c5d803a");
            studentQuery3.Enrollment = DateTime.Now.ToString("yydd") +
                           studentQuery3.Id.GetHashCode().ToString().Replace("-", "0").Substring(0, 4);
            studentQuery3.Status = false;


            List<Student> output = new List<Student>();

            output.Add(studentQuery1);
            output.Add(studentQuery2);
            output.Add(studentQuery3);

            return output;
        }

        public static List<Teacher> LoadTeacherQueriesTestsSampleData()
        {
            throw new NotImplementedException();
        }

    }
}