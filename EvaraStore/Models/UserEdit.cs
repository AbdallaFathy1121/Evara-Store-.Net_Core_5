using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public class UserEdit
    {
        [RegularExpression(@"^.{8,}$", ErrorMessage ="You Should Write Upper than 8 Character")]
        public string UserName { get; set; }

        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "InValid Email Format")]
        public string Email { get; set; }

        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$", ErrorMessage = "You must write a strong password that contains (upper and lowercase letters and not less than 8 characters)")]
        public string Password { get; set; }

    }
}
