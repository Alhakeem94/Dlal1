using Dalal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalal.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Products> products { get; set; }
        public string SearchedProduct { get; set; }

    }
}
