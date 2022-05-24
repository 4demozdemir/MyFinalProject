﻿using DataAccess.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{   
   public class InMemoryProductDal : IProductDal

    {
         List<Product> _products; 

      
        public InMemoryProductDal() 
        {
            _products = new List<Product> { 
              new Product{ProductId=1,CategoryId=1,ProductName="Bilgisayar",UnitPrice=56,UnitsInSoct=6},
              new Product{ProductId=2,CategoryId=1,ProductName="Monitor",UnitPrice=45,UnitsInSoct=20},
              new Product{ProductId=2,CategoryId=1,ProductName="Klavye",UnitPrice=4,UnitsInSoct=25}
            };

        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

      
        public void Delete(Product product)
        {
            //Product productToDelete = null;
            //foreach (var item in _products)
            //{
            //    if (product.ProductId == item.ProductId)
            //    {
            //        productToDelete = item;
            //    }
            //}
            Product productToDelete = _products.SingleOrDefault(p=> p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {

            return _products; 
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId==categoryId).ToList();
            
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInSoct = product.UnitsInSoct;
            productToUpdate.CategoryId = product.CategoryId;
                
        }


    }
}