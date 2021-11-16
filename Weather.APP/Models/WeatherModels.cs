using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.APP.Models
{
    public class Main
    {
        public double temp { get; set; }
    }
    public class info
    {
        public Main main { get; set; }
        public string dt_txt { get; set; }
    }
    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }
    public class City
    {
        public string name { get; set; }
    }
    public class Root
    {
        public List<info> list { get; set; }
        public City city { get; set; }
    }
}
