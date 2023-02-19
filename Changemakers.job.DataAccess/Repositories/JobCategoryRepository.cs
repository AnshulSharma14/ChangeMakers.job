using Changemakers.job.DataAccess.Repositories.Interfaces;
using ChangeMakers.job.Data;
using ChangeMakers.job.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Changemakers.job.DataAccess.Repositories
{
    public class JobCategoryRepository:Repository<JobCategory>, IJobCategoryRepository
    {
        private readonly ApplicationDbContext _context;
    public JobCategoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public void Update(JobCategory jobCategory)
        {
            _context.Update(jobCategory);
        }
    }
}
