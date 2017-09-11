using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FooFoo
{
    public partial class Download : System.Web.UI.Page
    {
        private readonly MemoryFileCreator _memoryFileCreator = new MemoryFileCreator();

        protected void Page_Load(object sender, EventArgs e)
        {
            var byteArray = GetCsv();

            ClearResponse();



            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.CacheControl = "private";
            Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
            Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
            Response.AppendHeader("Pragma", "cache");
            Response.AppendHeader("Expires", "60");
            Response.ContentType = "text/comma-separated-values";
            Response.AddHeader("Content-Disposition", "attachment; filename=FooFoo.csv");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.BinaryWrite(byteArray);
        }

        private void ClearResponse()
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Cookies.Clear();
        }

        private byte[] GetCsv()
        {
            System.IO.MemoryStream ms = _memoryFileCreator.CreateMemoryFile();

            byte[] byteArray = ms.ToArray();
            ms.Flush();
            ms.Close();
            return byteArray;
        }
    }
}