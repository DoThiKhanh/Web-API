﻿using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
  public class ProductRepository : IProductRepository
    {
        private IDatabaseHelper _dbHelper;
        public ProductRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(ProductModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_product_create",
                "@product_id", model.product_id,
                "@category_id", model.category_id,
                "@brand_id", model.brand_id,
                "@product_image", model.product_image,
                "@product_name", model.product_name,
                "@product_price", model.product_price,
                "@product_desc", model.product_desc,
                "@product_content", model.product_content,
                "@product_status", model.product_status);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_get_by_id",
                     "@product_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProductModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string category_id)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@category_id", category_id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ProductModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}