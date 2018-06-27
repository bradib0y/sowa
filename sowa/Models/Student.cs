using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sowa.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public MembershipType MembershipType { get; set; }

        [ForeignKey("MembershipType")]
        public byte MembershipTypeId { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public DateTime Birthday { get; set; }
    }
}