using DKCommerceBussinesEntity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Libreria;


namespace DKCommerceDataAccess
{
    public class ProductoDA : ConfigDataAccess
    {
        public const string UpProductoInsert = "UpProductoInsert";
        public const string UpProductoUpdate = "UpProductoUpdate";
        public const string UpProductoDelete = "UpProductoDelete";
        public const string UpProductoSelById = "UpProductoSelById";
        public const string UpProductoStatus = "UpProductoStatus";
        public const string UpProductoExists = "UpProductoExists";
        public const string UpProductoPagination = "UpProductoPagination";



    }
}
