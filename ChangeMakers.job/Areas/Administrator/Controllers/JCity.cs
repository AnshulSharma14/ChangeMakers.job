using Changemakers.job.DataAccess.Repositories.Interfaces;
using ChangeMakers.job.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChangeMakers.job.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class JCity : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JCity(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            JobCities jobCities = new JobCities();
            if (id == null) return View(jobCities); 
            jobCities = _unitOfWork.jobCitiesRepo.Get(id.GetValueOrDefault());
            if (jobCities == null)
                return NotFound();
            return View(jobCities);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(JobCities jobCities)
        {
            if (jobCities == null)
                return NotFound();
            if (!ModelState.IsValid)
                return View();
            if (jobCities.Id == 0)
            {
                _unitOfWork.jobCitiesRepo.Add(jobCities);
            }
            else
            {
                _unitOfWork.jobCitiesRepo.Update(jobCities);
            }
            _unitOfWork.save();
            return RedirectToAction("Index");
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var JCitylist = _unitOfWork.jobCitiesRepo.GetAll();
            return Json(new { data = JCitylist });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var JCityList = _unitOfWork.jobCitiesRepo.Get(id);
            if (JCityList == null)
                return Json(new { success = false, message = "something Went Wrong" });
            _unitOfWork.jobCitiesRepo.Remove(JCityList);
            _unitOfWork.save();
            return Json(new { success = true, message = "Data Deleted Succesfully" });

        }
        #endregion
    }
}
