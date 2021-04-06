using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class CourseSubject : Entity
    {
        public CourseSubject(Guid courseId, Guid subjectId)
        {
            CourseId = courseId;
            SubjectId = subjectId;
        }

        [Required]
        [Range(1, int.MaxValue)]
        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }
        
        public IEnumerable<StudentCourseSubject> StudentsCoursesSubjects { get; set; }
    }
}