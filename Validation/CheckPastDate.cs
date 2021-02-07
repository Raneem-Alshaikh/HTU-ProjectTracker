using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Validation
{
    public class CheckPastDate : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            return (DateTime)date > DateTime.Now;
        }
        
    }
}
