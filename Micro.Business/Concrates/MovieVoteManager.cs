using Micro.Business.Abstracts;
using Micro.Dal.Concrates.Repo;
using Micro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Business.Concrates
{
    public class MovieVoteManager : IManager<MovieVote>
    {
        MovieVoteRepository _movieVoteRepository;
        public MovieVoteManager(MovieVoteRepository movieVoteRepository)
        {
            _movieVoteRepository = movieVoteRepository;
        }
        public void Add(MovieVote entity)
        {
            _movieVoteRepository.Add(entity);
        }

        public IEnumerable<MovieVote> Find(Expression<Func<MovieVote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieVote> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieVote>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public MovieVote GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(MovieVote entity)
        {
            throw new NotImplementedException();
        }

        public void Update(MovieVote entitiy, int id)
        {
            throw new NotImplementedException();
        }
    }
}
