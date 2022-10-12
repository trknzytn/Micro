using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Model
{
    public class MovieVote
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }

        [Range(1, 10)]
        public Double Vote { get; set; }
        public string Comment { get; set; }
    }
}
