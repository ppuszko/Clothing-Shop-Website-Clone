using NikeClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Application.Interfaces {
    public interface IProductRepository : IRepository<Product> {
        public void Update(Product entity);
    }
}
