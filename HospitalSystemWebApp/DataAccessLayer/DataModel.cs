using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class DataModel
    {
        SqlConnection con;SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(Connection.connect);
            cmd = con.CreateCommand();
        }
        #region Admin Methods

        public Admins AdminLogin(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail",mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi=Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT ID,Isim,Soyisim,TelNo,Mail,Sifre,Durum,Silinmis FROM Yoneticiler WHERE Mail = @mail AND Sifre = @sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    
                    SqlDataReader okuyucu = cmd.ExecuteReader();
                    Admins Y = new Admins();
                    while (okuyucu.Read())
                    {
                        Y.ID = okuyucu.GetInt32(0);
                        Y.Isim=okuyucu.GetString(1);
                        Y.Soyisim = okuyucu.GetString(2);
                        Y.TelNo = okuyucu.GetString(3);
                        Y.Mail = okuyucu.GetString(4);
                        Y.Sifre = okuyucu.GetString(5);
                        Y.Durum = okuyucu.GetBoolean(6);
                        Y.Silinmis = okuyucu.GetBoolean(7);
                        
                    }
                    return Y;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
              return null ;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
