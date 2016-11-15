using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schoolapp1.Models
{
    public class cat
    {
        public student Student { get; set; }
        public List<Cours> Courses { get; set; }
    }
}