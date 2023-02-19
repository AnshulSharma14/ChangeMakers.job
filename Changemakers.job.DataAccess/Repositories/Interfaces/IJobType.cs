using ChangeMakers.job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Changemakers.job.DataAccess.Repositories.Interfaces
{
    public interface IJobType:IRepository<JobType>
    {
        void Update(JobType jobType);
    }
}
