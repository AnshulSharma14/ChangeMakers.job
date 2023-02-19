using Changemakers.job.DataAccess.Repositories.Interfaces;
using ChangeMakers.job.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChangeMakers.job.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class JType : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JType(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            JobType jobtype = new JobType();
            if (id == null) return View(jobtype);
            jobtype = _unitOfWork.jobType.Get(id.GetValueOrDefault());
            if (jobtype == null)
                return NotFound();
            return View(jobtype);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(JobType jobType)
        {
            if (jobType == null)
                return NotFound();
            if (!ModelState.IsValid)
                return View();
            if (jobType.Id == 0)
            {
                _unitOfWork.jobType.Add(jobType);
            }
            else
            {
                _unitOfWork.jobType.Update(jobType);
            }
            _unitOfWork.save();
            return RedirectToAction("Index");
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobTypes = _unitOfWork.jobType.GetAll();
            return Json(new { data = jobTypes });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var jobTypes = _unitOfWork.jobType.Get(id);
            if (jobTypes == null)
                return Json(new { success = false, message = "something Went Wrong" });
            _unitOfWork.jobType.Remove(jobTypes);
            _unitOfWork.save();
            return Json(new { success = true, message = "Data Deleted Succesfully" });

        }
        #endregion
    }
}
