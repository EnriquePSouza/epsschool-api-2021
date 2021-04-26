using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        Task SaveAsync();
        Task<User> GetById(Guid Id);
        Task<List<User>> GetAll();
    }
}