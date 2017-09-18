using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebEntityCore.Models
{
    public class Courses
    {

        public int CoursesId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }       
        public string CourseTutor { get; set; }
        public string CourseFees { get; set; }        
        public int CourseCategoryId { get; set; }
        public virtual CourseCategory CourseCategory { get; set; }

    }
}
