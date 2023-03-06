using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchit.Domain.Models.AtributesValidation
{
    internal class CourseNameAttribute:ValidationAttribute
    {
        string[] names;
        internal CourseNameAttribute(string[] names)
        {
            this.names = names;
        }

        
        public override bool IsValid(object? value)
        {
           return names.Contains(value);
           
        }
    }
}
