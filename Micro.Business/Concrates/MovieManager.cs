using Micro.Business.Abstracts;
using Micro.Dal.Abstracts.Repo;
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
    public class MovieManager : IManager<Movie>
    {
        MovieRepository _movieRepository;
        public MovieManager(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void AddBulk(List<Movie> entity)
        {
            _movieRepository.AddBulk(entity);
        }

        public void AddBulk_(MovieObject entity)
        {
            _movieRepository.AddBulk_(entity);
        }

        public void Add(Movie entity)
        {
            _movieRepository.Add(entity);
        }

        public IEnumerable<Movie> Find(Expression<Func<Movie, bool>> predicate)
        {
            return _movieRepository.Find(predicate);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            return _movieRepository.GetAllAsync();
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public void Remove(Movie entity)
        {
            _movieRepository.Remove(entity);
        }

        public void Update(Movie entitiy, int id)
        {
            _movieRepository.Update(entitiy, id);
        }
    }
}
