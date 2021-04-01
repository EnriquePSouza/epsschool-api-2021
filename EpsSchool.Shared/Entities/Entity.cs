using System;
using System.ComponentModel.DataAnnotations;

namespace EpsSchool.Shared.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity(int id)
        {
            Id = id;
        }
        
        [Key]
        public int Id { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}