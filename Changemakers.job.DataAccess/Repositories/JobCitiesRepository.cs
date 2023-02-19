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
    public class JobCitiesRepository : Repository<JobCities>, IJobCitiesRepo
    {
        private readonly ApplicationDbContext _context;
        public JobCitiesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(JobCities jobCities)
        {
            _context.Update(jobCities);
        }
    }
}