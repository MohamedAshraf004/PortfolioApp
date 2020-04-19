using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.ViewModel
{
    public class HomeViewModel
    {
        public Owner Owner{ get; set; }
        public IEnumerable<PortfolioItem> PortfolioItems { get; set; }

    }
}
