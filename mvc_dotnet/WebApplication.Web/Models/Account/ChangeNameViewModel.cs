using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models.Account
{
    public class ChangeNameViewModel
    {
        ///// <summary>
        ///// The user's first name (can be null)
        ///// </summary>
        //[MaxLength(50)]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //[Required(AllowEmptyStrings = true)]
        //public string OldFirstName { get; set; }

        ///// <summary>
        ///// The user's last name (can be null)
        ///// </summary>
        //[MaxLength(50)]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //[Required(AllowEmptyStrings = true)]
        //public string OldLastName { get; set; }

        /// <summary>
        /// The user's first name (can be null)
        /// </summary>
        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string NewFirstName { get; set; }

        /// <summary>
        /// The user's last name (can be null)
        /// </summary>
        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string NewLastName { get; set; }
    }
}
