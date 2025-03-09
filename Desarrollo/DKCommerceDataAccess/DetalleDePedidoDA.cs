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
    public class DetalleDePedidoDA: ConfigDataAccess
    {
        public const string UpDetalleDePedidoInsert = "UpDetalleDePedidoInsert";
        public const string UpDetalleDePedidoUpdate = "UpDetalleDePedidoUpdate";
        public const string UpDetalleDePedidoDelete = "UpDetalleDePedidoDelete";
        public const string UpDetalleDePedidoSelById = "UpDetalleDePedidoSelById";



    }
}
