using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //data annotations used to override conventions
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        

        public bool IsSubscribedToNewsletter { get; set; }

        //Navigation Property - Associating Customer class with MembershipType Class
        public MembershipType MembershipType { get; set; }

        //Foreign Key association with MembershipType and EF recognizes this with the convention of NameofClass+Id
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        //Nullable BirthDate
        [Display(Name = "Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}