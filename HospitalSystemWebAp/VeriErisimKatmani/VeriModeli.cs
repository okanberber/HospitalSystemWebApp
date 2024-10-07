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
        public bool DoktorEkle(Doktorlar dok)
        {
            try
            {
                komut.CommandText = "INSERT INTO Doktorlar (Isim,Soyisim,TelNo,Alani,Mail,Sifre,Durum,Silinmis) VALUES (@isim,@soyisim,@telno,@alan,@mail,@sifre,@durum,@silinmis)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", dok.Isim);
                komut.Parameters.AddWithValue("@soyisim", dok.Soyisim);
                komut.Parameters.AddWithValue("@telno", dok.TelNo);
                komut.Parameters.AddWithValue("@alan", dok.Alani);
                komut.Parameters.AddWithValue("@mail", dok.Mail);
                komut.Parameters.AddWithValue("@sifre", dok.Sifre);
                komut.Parameters.AddWithValue("@durum", dok.Durum);
                komut.Parameters.AddWithValue("@silinmis", dok.Silinmis);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close ();
            }
        }
        public List<Doktorlar> DoktorListele()
        {
            List<Doktorlar> doktor= new List<Doktorlar>();
            try
            {
                komut.CommandText = "SELECT ID,Isim,Soyisim,TelNo,Alani,Mail,Sifre,Durum,Silinmis FROM Doktorlar";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Doktorlar dok = new Doktorlar();
                    dok.ID = okuyucu.GetInt32(0);
                    dok.Isim = okuyucu.GetString(1);
                    dok.Soyisim = okuyucu.GetString(2);
                    dok.TelNo = okuyucu.GetString(3);
                    dok.Alani = okuyucu.GetString(4);
                    dok.Mail = okuyucu.GetString(5);
                    dok.Sifre = okuyucu.GetString(6);
                    dok.Durum = okuyucu.GetBoolean(7);
                    dok.Silinmis = okuyucu.GetBoolean(8);
                    doktor.Add(dok);
                }
                return doktor;
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
        public void DoktorSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Doktorlar WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void DoktorDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM Doktorlar WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id",id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());
                komut.CommandText = "UPDATE Doktorlar SET Durum = @durum WHERE ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@durum",!durum);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery ();
            }
            finally
            {
                baglanti.Close() ;
            }
        }
        public bool DoktorDuzenle(int id, Doktorlar d)
        {
            try
            {
                komut.CommandText="UPDATE Doktorlar SET Isim=@isim, Soyisim=@soyisim, TelNo=@telefon, Alani=@alan, Mail=@mail, Sifre=@sifre, Durum=@durum, Silinmis=@silinmis WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id",id);
                komut.Parameters.AddWithValue("@isim", d.Isim);
                komut.Parameters.AddWithValue("@soyisim", d.Soyisim);
                komut.Parameters.AddWithValue("@telefon", d.TelNo);
                komut.Parameters.AddWithValue("@alan", d.Alani);
                komut.Parameters.AddWithValue("@mail", d.Mail);
                komut.Parameters.AddWithValue("@sifre", d.Sifre);
                komut.Parameters.AddWithValue("@durum", d.Durum);
                komut.Parameters.AddWithValue("@silinmis", d.Silinmis);
                baglanti.Open() ;
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
               return false;
            }
            finally
            {
                baglanti.Close ();
            }
        }
        public List<Hastalar> HastaListele()
        {
            List<Hastalar> hasta = new List<Hastalar>();
            try {
            komut.CommandText = "SELECT ID,ReceteID,Isim,Soyisim,TCK,TelNo,Sikayet,Teshis,Tarih,Durum,Silinmis FROM Doktorlar";
            komut.Parameters.Clear();
            baglanti.Open();
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                Hastalar H = new Hastalar();
                H.ID = okuyucu.GetInt32(0);
                H.ReceteID = okuyucu.GetInt32(1);
                H.Soyisim = okuyucu.GetString(2);
                H.TCK = okuyucu.GetString(3);
                H.TelNo = okuyucu.GetString(4);
                H.Sikayet = okuyucu.GetString(5);
                H.Teshis = okuyucu.GetString(6);
                H.Tarih = okuyucu.GetDateTime(7);
                H.Durum = okuyucu.GetBoolean(8);
                H.Silinmis = okuyucu.GetBoolean(9);
                hasta.Add(H);
            }
            return hasta;
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
        public bool HastaEkle(Hastalar H)
        {
            try
            {
                komut.CommandText = "INSERT INTO Hastalar (Isim,Soyisim,TCK,TelNo,Sikayet,Teshis,Tarih,Durum,Silinmis) VALUES (@isim,@soyisim,@tck,@telefon,@sikayet,@teshis,@tarih,@durum,@silinmis)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", H.Isim);
                komut.Parameters.AddWithValue("@soyisim", H.Soyisim);
                komut.Parameters.AddWithValue("@tck", H.Soyisim);
                komut.Parameters.AddWithValue("@telefon", H.TelNo);
                komut.Parameters.AddWithValue("@sikayet", H.Sikayet);
                komut.Parameters.AddWithValue("@teshis", H.Teshis);
                komut.Parameters.AddWithValue("@tarih", H.Tarih);
                komut.Parameters.AddWithValue("@durum", H.Durum);
                komut.Parameters.AddWithValue("@silinmis", H.Silinmis);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }
        #endregion
        #region Eczacı Metotları
        public Eczacilar EczaciGiris(string mail,string sifre)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Eczacilar WHERE Mail=@mail AND Sifre=@sifre";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@sifre", sifre);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (sayi == 1)
                {
                    komut.CommandText = "SELECT ID,Isim,Soyisim,Mail,Sifre,Durum,Silinmis FROM Eczacilar WHERE Mail = @mail AND Sifre = @sifre";
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@mail", mail);
                    komut.Parameters.AddWithValue("@sifre", sifre);

                    SqlDataReader okuyucu = komut.ExecuteReader();
                    Eczacilar E = new Eczacilar();
                    while (okuyucu.Read())
                    {
                        E.ID = okuyucu.GetInt32(0);
                        E.Isim = okuyucu.GetString(1);
                        E.Soyisim = okuyucu.GetString(2);
                        E.Mail = okuyucu.GetString(3);
                        E.Sifre = okuyucu.GetString(4);
                        E.Durum = okuyucu.GetBoolean(5);
                        E.Silinmis = okuyucu.GetBoolean(6);

                    }
                    return E;
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
