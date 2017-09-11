using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FooFoo
{
    public class MemoryFileCreator
    {
        public System.IO.MemoryStream CreateMemoryFile()
        {
            MemoryStream ReturnStream = new MemoryStream();

            try
            {
                var dt = Download.GetData();

                //Create a streamwriter to write to the memory stream
                StreamWriter sw = new StreamWriter(ReturnStream);

                int iColCount = dt.Columns.Count;

                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }

                sw.WriteLine();
                int intRows = dt.Rows.Count;

                // Now write all the rows.
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {

                        if (!Convert.IsDBNull(dr[i]))
                        {
                            string str = String.Format("\"{0:c}\"", dr[i].ToString()).Replace("\r\n", " ");
                            sw.Write(str);
                        }
                        else
                        {
                            sw.Write("");
                        }

                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }

                sw.Flush();
                sw.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ReturnStream;
        }
    }
    private static DataTable GetData()
    {
    string strConn = ConfigurationManager.ConnectionStrings["FooFooConnectionString"].ToString();
    SqlConnection conn = new SqlConnection(strConn);
    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [FooFoo] ORDER BY id ASC", conn);
    DataSet ds = new DataSet();
    da.Fill(ds, "FooFoo");
    DataTable dt = ds.Tables["FooFoo"];
        return dt;
    }
}