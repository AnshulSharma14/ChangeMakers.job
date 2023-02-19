using Changemakers.job.DataAccess.Repositories.Interfaces;
using ChangeMakers.job.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace ChangeMakers.job.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Company company = new();


            if (id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company = _unitOfWork.companyRepos.FirstORDefault(u => u.Id == id);
                return View(company);
            }

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Company obj)
        {

            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.companyRepos.Add(obj);
                }
                else
                {
                    _unitOfWork.companyRepos.Update(obj);
                }
                _unitOfWork.save();
                return RedirectToAction("Register","Account",new {area="Identity"});
            }
            return View(obj);
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var CompanyList = _unitOfWork.companyRepos.GetAll();
            return Json(new { data = CompanyList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.companyRepos.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "something Went Wrong" });
            }
            _unitOfWork.companyRepos.Remove(obj);
            _unitOfWork.save();
            return Json(new { success = true, message = "Data Deleted Succesfully" });
        }
        #endregion


    }

}
