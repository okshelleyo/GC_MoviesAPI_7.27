using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIs.Models
{

    public class MovieRootobject
    {
        public Movie[] Property1 { get; set; }
    }

    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public int runtime { get; set; }
    }

}
