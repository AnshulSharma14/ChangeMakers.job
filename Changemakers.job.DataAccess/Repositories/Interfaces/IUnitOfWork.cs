using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Changemakers.job.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IJobType jobType { get; }
       IJobCategoryRepository jobCategory { get; }
        IJobCitiesRepo jobCitiesRepo { get; }
        IJobsRepository jobsRepository { get; }

    ICompanyRepos companyRepos { get; } 
        void save();
    }
}
