using Microsoft.EntityFrameworkCore;
using NikeClone.Application.Interfaces;
using NikeClone.Domain.Entities;
using NikeClone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Infrastructure.Repository {
    public class ProductRepository : Repository<Product>, IProductRepository {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) :base(db) {
            _db = db;
         
        }
        public void Update(Product entity) {
            _db.Products.Update(entity);
        }
    }
}
