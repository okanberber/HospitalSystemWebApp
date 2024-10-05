using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeriModeli
    {
        SqlConnection baglanti; SqlCommand komut;

        public VeriModeli()
        {
            baglanti = new SqlConnection(BaglantiYollari.connect);
            komut = baglanti.CreateCommand();
        }
        #region Yönetici Metotları
        public Yonetici YoneticiGiris(string mail,string sifre)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@sifre", sifre);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (sayi == 1)
                {
                    komut.CommandText = "SELECT ID,Isim,Soyisim,TelNo,Mail,Sifre,Durum,Silinmis FROM Yoneticiler WHERE Mail = @mail AND Sifre = @sifre";
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@mail", mail);
                    komut.Parameters.AddWithValue("@sifre", sifre);

                    SqlDataReader okuyucu = komut.ExecuteReader();
                    Yonetici Y = new Yonetici();
                    while (okuyucu.Read())
                    {
                        Y.ID = okuyucu.GetInt32(0);
                        Y.Isim = okuyucu.GetString(1);
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
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        #endregion
    }

}
