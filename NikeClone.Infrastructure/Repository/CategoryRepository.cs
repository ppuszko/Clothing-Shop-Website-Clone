using NikeClone.Application.Interfaces;
using NikeClone.Domain.Entities;
using NikeClone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Infrastructure.Repository {
    public class CategoryRepository :Repository<Category>, ICategoryRepository{
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) :base(db){
            _db = db;
        }

        public void Update(Category entity) {
            _db.Categories.Update(entity);
        }
    }
}
