using ChangeMakers.job.Data;
using Changemakers.job.DataAccess.Repositories.Interfaces;
using ChangeMakers.job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Changemakers.job.DataAccess.Repositories
{
    public class JobRepostory : Repository<Jobs>, IJobsRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRepostory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Jobs jobs)
        {
            _context.Update(jobs);
        }
    }
}
