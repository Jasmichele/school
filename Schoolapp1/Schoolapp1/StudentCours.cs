//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schoolapp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentCours
    {
        public int StudentsID { get; set; }
        public int CoursesID { get; set; }
        public int Anything { get; set; }
    
        public virtual Cours Cours { get; set; }
        public virtual student student { get; set; }
    }
}
