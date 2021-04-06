using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Subject : Entity
    {
        public Subject(string name, Guid teacherId)
        {
            Workload = null;
            Name = name;
            TeacherId = teacherId;
        }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [MaxLength(9999)]
        public int? Workload { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public Guid TeacherId { get; set; }

        public Teacher Teacher { get; set; }
        
        public IEnumerable<CourseSubject> CoursesSubjects { get; set; }
    }
}