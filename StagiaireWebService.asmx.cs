using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceWeb
{
    /// <summary>
    /// Summary description for StagiaireWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StagiaireWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable GestNomsStagiaire(string date1,string date2)
        {
            DataSet dataSet = new DataSet();
            Database.Execute(Connection =>
            {
                new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand("select NomStg from Stagiaire where DateInscription between @d1 and @d2", Connection)
                    {
                        Parameters =
                        {
                            new SqlParameter("@d1",date1),
                            new SqlParameter("@d2",date2)
                        }
                    }
                }.Fill(dataSet,"nomStag");
            });
            return dataSet.Tables["nomStag"];
        }
    }
}
