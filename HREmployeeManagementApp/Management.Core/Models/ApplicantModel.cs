using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Models
{
    public class ApplicantModel
    {
        public int ApplicantMasterid { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public decimal TotalExperience { get; set; }
        public decimal RelevantExperience { get; set; }
        public string AppliedForPosition { get; set; }
        public string TechnicalSkills { get; set; }
        public string HighestQualification { get; set; }
        public string YearOfPassing { get; set; }
        public string CurrentCtc { get; set; }
        public string ExpectedCtc { get; set; }
        public int NoticePeriodDays { get; set; }
        public string StatusofEmployment { get; set; }
        public string Email { get; set; }
        public string CurrentLocation { get; set; }
        public bool WillingToRelocate { get; set; }
        public string CurrentCompany { get; set; }
       
    }

}
