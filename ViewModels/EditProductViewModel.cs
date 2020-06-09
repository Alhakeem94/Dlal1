using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalal.ViewModels
{
    public class EditProductViewModel : CreateProductViewModel
    {
        public int ProductId { get; set; }
        public string ExistingPhotoPath { get; set; }

    }
}
