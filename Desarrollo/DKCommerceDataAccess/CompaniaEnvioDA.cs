using DKCommerceBussinesEntity;
using Libreria;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DKCommerceDataAccess
{
    public class CompaniaEnvioDA : ConfigDataAccess
    {
        public const string UpCompaniaEnvioInsert = "UpCompaniaEnvioInsert";
        public const string UpCompaniaEnvioUpdate = "UpCompaniaEnvioUpdate";
        public const string UpCompaniaEnvioDelete = "UpCompaniaEnvioDelete";
        public const string UpCompaniaEnvioSelById = "UpCompaniaEnvioSelById";

    }
}
