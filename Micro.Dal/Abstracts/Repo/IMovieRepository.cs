using Micro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Dal.Abstracts.Repo
{
    public interface IMovieRepository : IEntityRepository<Movie>
    {
        void AddBulk(List<Movie> entity);
        void AddBulk_(MovieObject entity);
    }
}
