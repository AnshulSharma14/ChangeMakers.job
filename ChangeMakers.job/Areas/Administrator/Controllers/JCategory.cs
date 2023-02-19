using Changemakers.job.DataAccess.Repositories.Interfaces;
using ChangeMakers.job.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChangeMakers.job.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class JCategory : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JCategory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            JobCategory category = new JobCategory();
            if (id == null) return View(category);
            category = _unitOfWork.jobCategory.Get(id.GetValueOrDefault());
            if (category == null)
                return NotFound();
            return View(category);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(JobCategory category)
        {
            if (category == null)
                return NotFound();
            if (!ModelState.IsValid)
                return View();
            if (category.Id == 0)
            {
                _unitOfWork.jobCategory.Add(category);
            }
            else
            {
                _unitOfWork.jobCategory.Update(category);
            }
            _unitOfWork.save();
            return RedirectToAction("Index");
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var CategoryList = _unitOfWork.jobCategory.GetAll();
            return Json(new { data = CategoryList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.jobCategory.Get(id);
            if (category == null)
                return Json(new { success = false, message = "something Went Wrong" });
            _unitOfWork.jobCategory.Remove(category);
            _unitOfWork.save();
            return Json(new { success = true, message = "Data Deleted Succesfully" });

        }
        #endregion
    }
}
