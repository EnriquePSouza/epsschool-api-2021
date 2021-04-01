using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Subject : Entity
    {
        public Subject(int id, string name, int teacherId) : base(id)
        {
            Name = name;
            TeacherId = teacherId;
        }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [MaxLength(9999)]
        public int Workload { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
        
        public IEnumerable<CourseSubject> CoursesSubjects { get; set; }
    }
}