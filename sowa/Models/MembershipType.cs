using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sowa.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public byte DurationInMonths { get; set; }
        public short SignUpFee { get; set; }
        public byte DiscountRate { get; set; }


    }
}