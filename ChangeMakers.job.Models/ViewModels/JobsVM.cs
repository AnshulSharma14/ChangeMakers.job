using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChangeMakers.job.Models.ViewModels
{
    public class JobsVM
    {
        public Jobs jobs { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> JobCategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> JobTypeList { get; set; }
         [ValidateNever]
        public IEnumerable<SelectListItem> JobCityList { get; set; }
    }
}
