using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchit.Domain.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int ValueNumber { get; set; }
        public string ValueSymbol { get; set; }

        public Course? Course { get; set; }
        
    }
}
