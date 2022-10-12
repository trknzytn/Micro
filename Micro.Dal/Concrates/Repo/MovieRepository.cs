using EFCore.BulkExtensions;
using Micro.Dal.Abstracts.Repo;
using Micro.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Dal.Concrates.Repo
{
    public class MovieRepository : EntityRepository<Movie>, IMovieRepository
    {
        DbContext Context;
        public MovieRepository(DbContext context_) : base(context_)
        {
            this.Context = context_;
        }

        public void AddBulk(List<Movie> entity)
        {
            Context.BulkInsert(entity, options => {
                options.InsertIfNotExists = true;
                options.ColumnPrimaryKeyExpression = c => c.id;
            });

            Context.BulkUpdate(entity, options => options.ColumnPrimaryKeyExpression = c => c.id);

        }

        public void AddBulk_(MovieObject entity)
        {
            entity.results.ToList().ForEach(c => c.page = entity.page);

            Context.BulkInsert(entity.results, options => {
                options.InsertIfNotExists = true;
                options.ColumnPrimaryKeyExpression = c => c.id;
            });

            Context.BulkUpdate(entity.results, options => options.ColumnPrimaryKeyExpression = c => c.id);

        }
    }
}
