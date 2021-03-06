﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface IProductRepository
    {
        bool Create(ProductModel model);
        bool Update(ProductModel model);
        bool Delete(string id);
        List<ProductModel> TK(int pageIndex, int pageSize, out long total, string product_name, decimal product_price);
        ProductModel GetDatabyID(int id);
        List<ProductModel> GetDataAll(int page_index ,int page_size,out long total);
        List<ProductModel> GetDataNew();
        List<ProductModel> Gettuongtu(int product_id);
        List<ProductModel> SearchCategory(int pageIndex, int pageSize, out long total, string category_id);
        List<ProductModel> SearcBrand(int pageIndex, int pageSize, out long total, string brand_id);
    }
}
