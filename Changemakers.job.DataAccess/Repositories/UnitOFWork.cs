using ChangeMakers.job.Data;
using Changemakers.job.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Changemakers.job.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            jobCategory = new JobCategoryRepository(_context);
            jobType = new JobTypeRepository(_context);
            jobCitiesRepo=new JobCitiesRepository(_context);
            jobsRepository = new JobRepostory(_context);
            companyRepos=new CompanyRepo(_context);
        }
       
        public IJobType jobType { get; private set; }

        public IJobCategoryRepository jobCategory { get; private set; }

        public IJobCitiesRepo jobCitiesRepo { get; set; }

        public IJobsRepository jobsRepository { get; set; }

        public ICompanyRepos companyRepos { get; set; }

        public void save()
        {
            _context.SaveChanges();
        }
    }

}
