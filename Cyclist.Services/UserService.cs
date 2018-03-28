using Cyclist.DataModel.UnitOfWork;
using Cyclist.DataModel.Models;
using System.Linq;
using System;

namespace Cyclist.Services
{
    public class UserService : IService<User>
    {
        public readonly UnitOfWork unitOfwork;

        public UserService()
        {
            unitOfwork = UnitOfWork.UnitOfWorkInstance();
        }

        public User Get(String id)
        {
            return unitOfwork.UsersRepository.Get(id);
        }

        public IQueryable<User> GetAll()
        {
            return unitOfwork.UsersRepository.GetAll();
        }

        public void Delete(String id)
        {
            unitOfwork.UsersRepository.Delete(id);
        }

        public void Insert(User user)
        {
            unitOfwork.UsersRepository.Add(user);
        }

        public void Update(User user)
        {
            unitOfwork.UsersRepository.Update(user.UserId, user);
        }
    }
}
