using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Subject : Entity
    {
        public Subject(string name)
        {
            Name = name;
        }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }
        
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<CourseSubject> CoursesSubjects { get; set; }
    }
}