using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebEntityCore.Models
{
    public class CourseCategory
    {
        public int CourseCategoryId { get; set; }
        public string CategegoryName { get; set; }
        public string CategoryDescription { get; set; }       
        public virtual List<Courses> Courses { get; set; }
    }
}
