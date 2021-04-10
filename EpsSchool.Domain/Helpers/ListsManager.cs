using System;
using System.Collections.Generic;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers.SampleDataManagers;

namespace EpsSchool.Domain.Helpers
{
    public class ListsManager
    {
        public static List<Student> LoadStudentQueriesTestsSampleData()
        {
            List<Student> output = new List<Student>();

            CourseSubject courseSubjectQuery1;

            Student studentQuery1 = StudentsSampleDataManager.student1;
            Student studentQuery2 = StudentsSampleDataManager.student2;
            Student studentQuery3 = StudentsSampleDataManager.student3;

            StudentCourseSubject studentCourseSubjectItem1;
            StudentCourseSubject studentCourseSubjectItem2;
            StudentCourseSubject studentCourseSubjectItem3;

            List<StudentCourseSubject> studentCourseSubject1 = new List<StudentCourseSubject>();
            List<StudentCourseSubject> studentCourseSubject2 = new List<StudentCourseSubject>();
            List<StudentCourseSubject> studentCourseSubject3 = new List<StudentCourseSubject>();

            studentQuery1.Id = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");
            studentQuery1.Enrollment = DateTime.Now.ToString("yydd") +
                           studentQuery1.Id.GetHashCode().ToString().Replace("-", "51").Substring(0, 5);

            studentQuery2.Id = new Guid("2ae369e0-632d-45db-ade9-ebbcc2a21bd9");
            studentQuery2.Enrollment = DateTime.Now.ToString("yydd") +
                           studentQuery2.Id.GetHashCode().ToString().Replace("-", "51").Substring(0, 5);

            studentQuery3.Id = new Guid("bdad5b21-e879-45fd-9cb2-c7530c5d803a");
            studentQuery3.Enrollment = DateTime.Now.ToString("yydd") +
                           studentQuery3.Id.GetHashCode().ToString().Replace("-", "51").Substring(0, 5);
            studentQuery3.Status = false;

            courseSubjectQuery1 = new CourseSubject(new Guid("3a00bebe-ace3-42e8-ad35-4a4104ae2b72"),
                                                    SubjectsSampleDataManager.subject1.Id);

            studentCourseSubjectItem1 = new StudentCourseSubject(courseSubjectQuery1.Id,
                                                                 studentQuery1.Id);
            studentCourseSubjectItem2 = new StudentCourseSubject(courseSubjectQuery1.Id,
                                                                 studentQuery2.Id);
            studentCourseSubjectItem3 = new StudentCourseSubject(courseSubjectQuery1.Id,
                                                                 studentQuery3.Id);

            studentCourseSubjectItem1.CourseSubject = courseSubjectQuery1;
            studentCourseSubjectItem2.CourseSubject = courseSubjectQuery1;
            studentCourseSubjectItem3.CourseSubject = courseSubjectQuery1;

            studentCourseSubject1.Add(studentCourseSubjectItem1);
            studentCourseSubject2.Add(studentCourseSubjectItem2);
            studentCourseSubject3.Add(studentCourseSubjectItem3);

            studentQuery1.StudentsCoursesSubjects = studentCourseSubject1;
            studentQuery2.StudentsCoursesSubjects = studentCourseSubject2;
            studentQuery3.StudentsCoursesSubjects = studentCourseSubject3;

            output.Add(studentQuery1);
            output.Add(studentQuery2);
            output.Add(studentQuery3);

            return output;
        }

        public static List<Teacher> LoadTeacherQueriesTestsSampleData()
        {
            List<Teacher> output = new List<Teacher>();

            Teacher teacherQuery1 = TeachersSampleDataManager.teacher1;
            Student studentQuery1 = StudentsSampleDataManager.student1;

            Subject subjectItemQuery1 = SubjectsSampleDataManager.subject1;
            CourseSubject courseSubjectItemQuery1 = 
                            new CourseSubject(new Guid("3a00bebe-ace3-42e8-ad35-4a4104ae2b72"), 
                                              subjectItemQuery1.Id);

            List<StudentCourseSubject> studentCourseSubject1 = new List<StudentCourseSubject>();
            List<CourseSubject> courseSubjectQuery1 = new List<CourseSubject>();
            List<Subject> subjectQuery1 = new List<Subject>();

            teacherQuery1.Id = new Guid("b4fabc54-ce8c-4009-beb4-51d577563c65");
            teacherQuery1.Enrollment = DateTime.Now.ToString("yydd") +
                           teacherQuery1.Id.GetHashCode().ToString().Replace("-", "51").Substring(0, 5);

            studentQuery1.Id = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");
            studentQuery1.Enrollment = DateTime.Now.ToString("yydd") +
                           studentQuery1.Id.GetHashCode().ToString().Replace("-", "51").Substring(0, 5);

            studentCourseSubject1.Add(new StudentCourseSubject(courseSubjectItemQuery1.Id, studentQuery1.Id));

            courseSubjectItemQuery1.StudentsCoursesSubjects = studentCourseSubject1;

            studentQuery1.StudentsCoursesSubjects = studentCourseSubject1;

            courseSubjectItemQuery1.StudentsCoursesSubjects = studentCourseSubject1;

            courseSubjectQuery1.Add(courseSubjectItemQuery1);

            subjectItemQuery1.TeacherId = teacherQuery1.Id;

            subjectItemQuery1.CoursesSubjects = courseSubjectQuery1;

            subjectQuery1.Add(subjectItemQuery1);

            teacherQuery1.Subject = subjectQuery1;

            output.Add(teacherQuery1);

            return output;
        }

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

    }
}