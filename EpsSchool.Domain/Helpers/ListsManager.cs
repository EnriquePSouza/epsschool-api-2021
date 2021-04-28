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

            Student studentData1 = StudentsSampleDataManager.student1;
            Student studentData2 = StudentsSampleDataManager.student2;
            Student studentData3 = StudentsSampleDataManager.student3;

            CourseSubject courseSubject1;

            StudentCourseSubject studentCourseSubjectItem1;
            StudentCourseSubject studentCourseSubjectItem2;
            StudentCourseSubject studentCourseSubjectItem3;

            List<StudentCourseSubject> studentCourseSubject1 = new List<StudentCourseSubject>();
            List<StudentCourseSubject> studentCourseSubject2 = new List<StudentCourseSubject>();
            List<StudentCourseSubject> studentCourseSubject3 = new List<StudentCourseSubject>();

            studentData1.Id = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");
            studentData1.Enrollment = DateTime.Now.ToString("yydd") +
                            studentData1.Id.GetHashCode()
                                            .ToString().Replace("-", "51").Substring(0, 5);

            studentData2.Id = new Guid("2ae369e0-632d-45db-ade9-ebbcc2a21bd9");
            studentData2.Enrollment = DateTime.Now.ToString("yydd") +
                            studentData2.Id.GetHashCode()
                                            .ToString().Replace("-", "51").Substring(0, 5);

            studentData3.Id = new Guid("bdad5b21-e879-45fd-9cb2-c7530c5d803a");
            studentData3.Enrollment = DateTime.Now.ToString("yydd") +
                            studentData3.Id.GetHashCode()
                                            .ToString().Replace("-", "51").Substring(0, 5);

            studentData3.Status = false;

            courseSubject1 = new CourseSubject(
                                    new Guid("3a00bebe-ace3-42e8-ad35-4a4104ae2b72"),
                                            SubjectsSampleDataManager.subject1.Id);

            studentCourseSubjectItem1 = new StudentCourseSubject(courseSubject1.Id,
                                                                 studentData1.Id);

            studentCourseSubjectItem2 = new StudentCourseSubject(courseSubject1.Id,
                                                                 studentData2.Id);

            studentCourseSubjectItem3 = new StudentCourseSubject(courseSubject1.Id,
                                                                 studentData3.Id);

            studentCourseSubjectItem1.CourseSubject = courseSubject1;
            studentCourseSubjectItem2.CourseSubject = courseSubject1;
            studentCourseSubjectItem3.CourseSubject = courseSubject1;

            studentCourseSubject1.Add(studentCourseSubjectItem1);
            studentCourseSubject2.Add(studentCourseSubjectItem2);
            studentCourseSubject3.Add(studentCourseSubjectItem3);

            studentData1.StudentsCoursesSubjects = studentCourseSubject1;
            studentData2.StudentsCoursesSubjects = studentCourseSubject2;
            studentData3.StudentsCoursesSubjects = studentCourseSubject3;

            output.Add(studentData1);
            output.Add(studentData2);
            output.Add(studentData3);

            return output;
        }

        public static List<Teacher> LoadTeacherQueriesTestsSampleData()
        {
            List<Teacher> output = new List<Teacher>();

            Teacher teacherData1 = TeachersSampleDataManager.teacher1;

            teacherData1.Id = new Guid("b4fabc54-ce8c-4009-beb4-51d577563c65");
            teacherData1.Enrollment = DateTime.Now.ToString("yydd") +
                            teacherData1.Id.GetHashCode()
                                            .ToString()
                                            .Replace("-", "51").Substring(0, 5);

            output.Add(teacherData1);

            return output;
        }

        public static List<CourseSubject> LoadCourseSubjectQueriesTestsSampleData()
        {
            List<CourseSubject> output = new List<CourseSubject>();

            Student studentData1 = StudentsSampleDataManager.student1;

            Subject subjectItem1 = SubjectsSampleDataManager.subject1;

            CourseSubject courseSubjectItem1 =
                            new CourseSubject(
                                    new Guid("3a00bebe-ace3-42e8-ad35-4a4104ae2b72"),
                                            subjectItem1.Id);

            List<StudentCourseSubject> studentCourseSubject1 = new List<StudentCourseSubject>();
            List<CourseSubject> courseSubject1 = new List<CourseSubject>();

            studentData1.Id = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");
            studentData1.Enrollment = DateTime.Now.ToString("yydd") +
                            studentData1.Id.GetHashCode()
                                            .ToString().Replace("-", "51").Substring(0, 5);

            studentCourseSubject1.Add(new StudentCourseSubject(
                                            courseSubjectItem1.Id, studentData1.Id));

            courseSubjectItem1.StudentsCoursesSubjects = studentCourseSubject1;

            studentData1.StudentsCoursesSubjects = studentCourseSubject1;

            courseSubjectItem1.StudentsCoursesSubjects = studentCourseSubject1;

            output.Add(courseSubjectItem1); ;

            return output;
        }

        public static List<Subject> LoadSubjectQueriesTestsSampleData()
        {
            List<Subject> output = new List<Subject>();

            Subject subjectData1 = SubjectsSampleDataManager.subject1;
            subjectData1.Id = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");

            output.Add(subjectData1);
            output.Add(SubjectsSampleDataManager.subject2);
            output.Add(SubjectsSampleDataManager.subject3);

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