using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpsSchool.Domain.Entities
{
    public class StudentCourseSubject
    {
        public StudentCourseSubject(Guid courseSubjectId, Guid studentId)
        {
            StudentId = studentId;
            CourseSubjectId = courseSubjectId;
            StartDate = DateTime.Now;
            EndDate = null;
            Grade = null;
        }
        
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(9999)]
        public int? Grade { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public Guid CourseSubjectId { get; set; }

        public CourseSubject CourseSubject { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public Guid StudentId { get; set; }
        
        public Student Student { get; set; }
    }
}