using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class EditCheeseViewModel :CheeseListViewModel
    {
        public int CheeseId { get; set; }
        public static int nextId = 1;
    }
}
