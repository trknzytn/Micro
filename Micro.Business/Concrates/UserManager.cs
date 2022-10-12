using Micro.Business.Abstracts;
using Micro.Dal.Abstracts.Repo;
using Micro.Dal.Concrates.Repo;
using Micro.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Business.Concrates
{
    public class UserManager : IManager<User>
    {
        UserRepository _userRepository;
        public UserManager(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User entity)
        {
            _userRepository.Add(entity);
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.Find(predicate);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Remove(User entity)
        {
            _userRepository.Remove(entity);
        }

        public void Update(User entitiy, int id)
        {
            _userRepository.Update(entitiy, id);
        }
    }
}
