using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Model
{
    public class Dates
    {
        [Key]
        public int id { get; set; }
        public string maximum { get; set; }
        public string minimum { get; set; }
    }
}
