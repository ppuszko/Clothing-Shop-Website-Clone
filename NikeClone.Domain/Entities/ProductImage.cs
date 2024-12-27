using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Domain.Entities {
    public class ProductImage {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public bool IsMain { get; set; } = false;
        public bool IsSecondary { get; set; } = false;
    }
}
