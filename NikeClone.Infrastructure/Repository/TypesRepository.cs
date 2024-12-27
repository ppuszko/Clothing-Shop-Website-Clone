using NikeClone.Application.Interfaces;
using NikeClone.Domain.Entities;
using NikeClone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Infrastructure.Repository {
    public class TypesRepository : Repository<Types>, ITypesRepository {
        private readonly ApplicationDbContext _db;
        public TypesRepository(ApplicationDbContext db) : base(db){

            _db = db;
        }


        public void Update(Types entity) {
            _db.Types.Update(entity);
        }
    }
}
