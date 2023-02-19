using Changemakers.job.DataAccess.Repositories.Interfaces;
using ChangeMakers.job.Models;
using ChangeMakers.job.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ChangeMakers.job.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class JobsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<SelectListItem> JobCategory { get; private set; }
        public IEnumerable<SelectListItem> jJobType { get; private set; }
        public IEnumerable<SelectListItem> JobCity { get; private set; }
        public JobsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            JobsVM jobsVM = new JobsVM()
            {
                jobs = new Jobs(),
                JobCategoryList = _unitOfWork.jobCategory.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                JobTypeList = _unitOfWork.jobType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                JobCityList = _unitOfWork.jobCitiesRepo.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }), 
            };

            if (id == null || id == 0)
            {
                return View(jobsVM);
            }
            else
            {
                jobsVM.jobs = _unitOfWork.jobsRepository.FirstORDefault(u => u.Id == id);
                return View(jobsVM);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Jobs jobs)
        {
            if (jobs == null)
                return NotFound();
            if (!ModelState.IsValid)
                return View();
            if (jobs.Id == 0)
            {
                _unitOfWork.jobsRepository.Add(jobs);
            }
            else
            {
                _unitOfWork.jobsRepository.Update(jobs);
            }
            _unitOfWork.save();
            return RedirectToAction("Index");
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobList = _unitOfWork.jobsRepository.GetAll(includeProperties:"Category,JobType,JobCities");
            return Json(new { data = jobList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var joblist = _unitOfWork.jobsRepository.Get(id);
            if (joblist == null)
                return Json(new { success = false, message = "something Went Wrong" });
            _unitOfWork.jobsRepository.Remove(joblist);
            _unitOfWork.save();
            return Json(new { success = true, message = "Data Deleted Succesfully" });

        }
        #endregion
    }
}

 