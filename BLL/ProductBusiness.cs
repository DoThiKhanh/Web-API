﻿using BLL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
  public  class ProductBusiness : IProductBusiness
    {
        private IProductRepository _res;
        public ProductBusiness(IProductRepository CategoryRes)
        {
            _res = CategoryRes;
        }
        public bool Create(ProductModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(ProductModel model)
        {
            return _res.Update(model);
        }
        public List<ProductModel> TK(int pageIndex, int pageSize, out long total, string product_name, decimal product_price)
        {
            return _res.TK(pageIndex, pageSize, out total, product_name, product_price);
        }
        public ProductModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ProductModel> GetDataAll(int page_index,int page_size,out long total)
        {
            return _res.GetDataAll(page_index,page_size,out total);
        }
        public List<ProductModel> Gettuongtu(int product_id)
        {
            return _res.Gettuongtu( product_id);
        }
        public List<ProductModel> GetDataNew()
        {
            return _res.GetDataNew();
        }
        public List<ProductModel> SearchCategory(int pageIndex, int pageSize, out long total, string category_id)
        {
            return _res.SearchCategory(pageIndex, pageSize, out total, category_id);
        }
        public List<ProductModel> SearcBrand(int pageIndex, int pageSize, out long total, string brand_id)
        {
            return _res.SearcBrand(pageIndex, pageSize, out total, brand_id);
        }
    }
}
