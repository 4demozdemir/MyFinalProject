﻿using Business.Absract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal  _productDal;
        public ProductManager(IProductDal productDal )
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }

        public    IDataResult<List<Product>> GetAll()
        {   // İş kodları
            if(DateTime.Now.Hour ==22)
            {
                return new ErrorDataResult();
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),true,"Listelendi"); 
        } 

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=> p.CategoryId==id);
        }

        public Product GetById(int productId)
        {

            return _productDal.Get(p=> p.ProductId==productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>= min && p.UnitPrice<=max); 
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
