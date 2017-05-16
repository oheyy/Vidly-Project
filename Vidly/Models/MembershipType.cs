using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //Explictly declared to use in the Min18yearIfAmember
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}