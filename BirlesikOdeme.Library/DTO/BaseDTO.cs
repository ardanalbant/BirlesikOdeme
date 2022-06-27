using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Library.DTO
{
    public class BaseDTO
    {
        public DateTime EKLZMN { get; set; }

        public string EKLKLN { get; set; }

        public DateTime GNCZMN { get; set; }

        public string GNCKLN { get; set; }
    }
}