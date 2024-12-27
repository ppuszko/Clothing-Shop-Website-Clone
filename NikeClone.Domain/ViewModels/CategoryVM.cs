using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using NikeClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Domain.ViewModels {
    public class CategoryVM {
        public Category? Category { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TypeList { get; set; }
    }
}
