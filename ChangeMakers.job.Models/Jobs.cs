using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ChangeMakers.job.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
       public double Salary { get; set; }
        [Required]
        public int JobCategoryId { get; set; }
        [ForeignKey("JobCategoryId")]
        [ValidateNever]
        public JobCategory Category { get; set; }
        [Required]
        public int JobTypeId { get; set; }
        [ForeignKey("JobTypeId")]
        [ValidateNever]
        public JobType JobType { get; set; }
        public int JobCityId { get; set; }
        [ForeignKey("JobCityId")]
        [ValidateNever]
        public JobCities JobCities { get; set; }

    }
}
