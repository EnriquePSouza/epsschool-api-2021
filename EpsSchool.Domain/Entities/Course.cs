using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Course : Entity
    {
        public Course(int id, string name) : base(id)
        {
            Name = name;

        }
        
        [Required]
        [MaxLength(120)]
        public string Name { get; private set; }

        public IEnumerable<CourseSubject> CoursesSubjects { get; private set; }
    }
}