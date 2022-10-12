using Micro.Dal.Abstracts.Repo;
using Micro.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Dal.Concrates.Repo
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        DbContext context;
        public UserRepository(DbContext context_) : base(context_)
        {
            this.context = context_;
        }


    }
}
