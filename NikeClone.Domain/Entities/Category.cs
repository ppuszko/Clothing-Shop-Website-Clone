﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Domain.Entities {
    public class Category {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
