using System.Collections.Generic;
using Entities.Concrete;
namespace DataAccess.Abstarct
{
    public interface IProductDal 
    {
      
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategory(int categoryId);

    }
}
