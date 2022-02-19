using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DescartesDiffApi;
using DescartesDiffApi.Model.v1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DescartesDiffApiTest
{
    public class DescartesDiffApiTest
    {
        [Fact]
        public void diffCalculationUnitTest()
        {

            DiffCalculation diffCalculation = new DiffCalculation();

            DiffResponse diffResponse = new DiffResponse();

            byte[] byteArrayData1 = Encoding.ASCII.GetBytes("AAAAAA==");
            byte[] byteArrayData2 = Encoding.ASCII.GetBytes("AQABAQ==");

            diffResponse = diffCalculation.diffResponse(byteArrayData1, byteArrayData2);
        }
    }
}