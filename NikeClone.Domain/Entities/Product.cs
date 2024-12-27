using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Domain.Entities {
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Size { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public bool OnSale { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PromoPrice { get; set; }

        [ForeignKey("Types")]
        public int TypeId { get; set; }

        [ValidateNever]
        public Types Type { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; }
        public bool ForMen { get; set; }
    }
}
