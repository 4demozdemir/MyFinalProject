using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstarct
{
    public interface IProductDal :IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
