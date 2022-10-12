using Micro.Dal.Abstracts.Repo;
using Micro.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Dal.Concrates.Repo
{
    public class MovieVoteRepository : EntityRepository<MovieVote>, IMovieVoteRepository
    {
        DbContext Context;
        public MovieVoteRepository(DbContext context_) : base(context_)
        {
            this.Context = context_;
        }
    }
}
