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
    public class ContactoClienteDA: ConfigDataAccess
    {
        public const string UpContactoClienteInsert = "UpContactoClienteInsert";
        public const string UpContactoClienteUpdate = "UpContactoClienteUpdate";
        public const string UpContactoClienteDelete = "UpContactoClienteDelete";
        public const string UpContactoClienteSelById = "UpContactoClienteSelById";

 
    }
}
