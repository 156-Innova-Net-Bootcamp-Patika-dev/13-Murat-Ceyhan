using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week1_Homework.Entities
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Director { get; set; }
        public List<string> Writers { get; set; }
        public List<string> Actors { get; set; }

    }
}
