using DKCommerceBussinesEntity;
using Libreria;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceDataAccess
{
    public class ContactoProveedorDA: ConfigDataAccess
    {
        public const string UpContactoProveedorInsert = "UpContactoProveedorInsert";
        public const string UpContactoProveedorUpdate = "UpContactoProveedorUpdate";
        public const string UpContactoProveedorDelete = "UpContactoProveedorDelete";
        public const string UpContactoProveedorSelById = "UpContactoProveedorSelById";



    }
}

