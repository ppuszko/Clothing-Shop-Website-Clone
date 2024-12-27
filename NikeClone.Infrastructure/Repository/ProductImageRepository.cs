using NikeClone.Application.Interfaces;
using NikeClone.Domain.Entities;
using NikeClone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Infrastructure.Repository {
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository {
        private readonly ApplicationDbContext _db;
        public ProductImageRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
    }
}
