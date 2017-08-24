using Excalibur.Utilities.CleverDAL.ADO.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.HR.Controllers
{
    public class MyCleverDALController : CleverStoreageProcedureController
    {
        public MyCleverDALController()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ToString();
            ConnectionString = connectionString;
        }

    }
}
