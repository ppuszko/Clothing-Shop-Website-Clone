using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using NikeClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Domain.ViewModels {
    public class ProductVM {
        public Product Product { get; set; }
        [ValidateNever]
        public ICollection<IFormFile> ImageList { get; set; }
        [ValidateNever]
        public List<ProductImage> ProductImageList { get; set; } = new List<ProductImage>();
        [ValidateNever]
        public IEnumerable<SelectListItem> TypesList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        
    }
}
