using Changemakers.job.DataAccess.Repositories.Interfaces;
using ChangeMakers.job.Data;
using ChangeMakers.job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Changemakers.job.DataAccess.Repositories
{
    public class JobTypeRepository: Repository<JobType>, IJobType
    {
        private readonly ApplicationDbContext _context;
        public JobTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(JobType jobType)
        {
            _context.Update(jobType);
        }
    }
}
