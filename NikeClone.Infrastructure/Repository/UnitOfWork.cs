using NikeClone.Application.Interfaces;
using NikeClone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Infrastructure.Repository {
    public class UnitOfWork : IUnitOfWork {
        
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db ) {
            _db = db;
            Category = new CategoryRepository(_db);
            Types = new TypesRepository(_db);
            Products = new ProductRepository(_db);
            ProductImages = new ProductImageRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public ITypesRepository Types { get; private set; }

        public IProductRepository Products { get; private set; }

        public IProductImageRepository ProductImages { get; private set; }

        public void Save() {
            _db.SaveChanges();
        }
    }
}
