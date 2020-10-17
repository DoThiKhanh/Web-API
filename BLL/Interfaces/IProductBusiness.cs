﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IProductBusiness
    {
        bool Create(ProductModel model);
        ProductModel GetDatabyID(string id);
        List<ProductModel> GetDataAll();
        List<ProductModel> GetDataNew();
        List<ProductModel> Gettuongtu(int product_id);

        List<ProductModel> Search(int pageIndex, int pageSize, out long total, string category_id);

    }
}
