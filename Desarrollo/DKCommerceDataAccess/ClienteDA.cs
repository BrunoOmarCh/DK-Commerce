using DKCommerceBussinesEntity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria;

namespace DKCommerceDataAccess
{
    public class ClienteDA : ConfigDataAccess
    {
        public const string UpClienteInsert = "UpClienteInsert";
        public const string UpClienteUpdate = "UpClienteUpdate";
        public const string UpClienteDelete = "UpClienteDelete";
        public const string UpClienteSelById = "UpClienteSelById";

    }
}
