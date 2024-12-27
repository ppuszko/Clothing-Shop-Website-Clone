using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeClone.Application.Interfaces {
    public interface IUnitOfWork {
        ICategoryRepository Category { get; }
        ITypesRepository Types { get; }
        IProductRepository Products { get; }
        IProductImageRepository ProductImages { get; }

        public void Save();
    }
}
