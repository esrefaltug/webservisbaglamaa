using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace webservisbaglama
{
    /// <summary>
    /// WebService1 için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Merhaba Dünya";
        //}
        //public int Sum(int a, int b)
        //{
        //    int x = a + b;
        //    try
        //    {
        //        return x;
        //    }
        //    catch (FormatException ex1)
        //    {
        //        Console.WriteLine("Kullanıcı kaynaklı hata var.Yanlış formmatta giriş yapıldı.");
        //        return a + b;
        //    }
        //}



        public DataSet SorguCalistir(string query)
        {
            SqlConnection con = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = Mesaa;Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

        //[WebMethod]
        //public string POST(int Id,string Name,String SurName,string Email)
        //{
        //    string str1 = Id.ToString();
        //    string connString = ("Server=localhost\\SQLEXPRESS; Database= Mesaa;Trusted_Connection=True;MultipleActiveResults=true");
        //    string query = "INSERT INTO demoJSON(Id,Name,SurName,Email)VALUES('" + str1 + "','" + Name + "','" + SurName + "','" + Email + "')";//post metot
        //    try
        //    {
        //        using (SqlConnection conn=new SqlConnection(connString))
        //        {
        //            using (SqlCommand command=new SqlCommand(query,conn))
        //            {
        //                conn.Open();
        //                command.ExecuteNonQuery();
        //                return "Harika";
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (SystemException ex)
        //    {

        //        return "Sistem Hatası";
        //    }

        //}

        [WebMethod]
        public DataSet GET()
        {
            string query = "Select * from BILGISAYARLAR4"; //Get metot
            return SorguCalistir(query);
        }
        [WebMethod]
        public DataSet DELETE(string dpo)
        {
            string query = "DELETE FROM DisplayCikislari";   //Delete metot
            return SorguCalistir(query);
        }
        [WebMethod]
        public DataSet POST( string Name, String SurName, string Email)
        {
            
            string query = "INSERT INTO demoJSON(Name,SurName,Email)VALUES('" + Name + "','" + SurName + "','" + Email + "')";//post metot
            
            return SorguCalistir(query);
        }
        [WebMethod]
       public DataSet PUT(int id,int hdm)
        {
            string query = "UPDATE DisplayCikislari SET HDMI="+hdm+"WHERE Id="+id;
            return SorguCalistir(query);
        }

       
      
















    }
}
