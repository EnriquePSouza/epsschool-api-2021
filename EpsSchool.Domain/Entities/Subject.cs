using System.Collections.Generic;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Subject : Entity
    {
        public Subject(int id, string nome, int teacherId) : base(id)
        {
            Nome = nome;
            TeacherId = teacherId;
        }

        public string Nome { get; private set; }
        public int CargaHoraria { get; private set; }
        public int TeacherId { get; private set; }
        public Teacher Teacher { get; private set; }
        public IEnumerable<CourseSubject> CoursesSubjects { get; private set; }
    }
}