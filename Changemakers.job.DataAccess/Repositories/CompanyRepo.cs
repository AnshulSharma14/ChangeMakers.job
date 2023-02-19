using ChangeMakers.job.Data;
using Changemakers.job.DataAccess.Repositories.Interfaces;
using ChangeMakers.job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Changemakers.job.DataAccess.Repositories
{
    internal class CompanyRepo : Repository<Company>, ICompanyRepos
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Company company)
        {
            _context.Update(company);
        }
    }
}
