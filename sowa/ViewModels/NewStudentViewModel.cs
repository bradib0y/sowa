using sowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sowa.ViewModels
{
    public class StudentFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes  { get; set; }
        public Student Student { get; set; }
    }
}