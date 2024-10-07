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
                    komut.CommandText = "SELECT ID,Isim,Soyisim,TelNo,Mail,Sifre FROM Yoneticiler WHERE Mail = @mail AND Sifre = @sifre";
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
                        Y.Telefon = okuyucu.GetString(3);
                        Y.Mail = okuyucu.GetString(4);
                        Y.Sifre = okuyucu.GetString(5);

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
        public List<Doktor> DoktorListele()
        {
            List<Doktor> doktorlar = new List<Doktor>();
            try
            {
                komut.CommandText = "SELECT ID,Isim,Soyisim,Alani,TelNo,Mail,Sifre FROM Doktorlar";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu=komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Doktor dok = new Doktor();
                    dok.ID = okuyucu.GetInt32(0);
                    dok.Isim = okuyucu.GetString(1);
                    dok.Soyisim = okuyucu.GetString(2);
                    dok.Alani = okuyucu.GetString(3);
                    dok.TelNo = okuyucu.GetString(4);
                    dok.Mail = okuyucu.GetString(5);
                    dok.Sifre = okuyucu.GetString(6);

                    doktorlar.Add(dok);
                }
                return doktorlar;
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
                komut.Parameters.AddWithValue("@id",id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public bool DoktorEkle(Doktor D)
        {
            try
            {
                komut.CommandText = "INSERT INTO Doktorlar (Isim,Soyisim,Alani,TelNo,Mail,Sifre) VALUES(@isim,@soyisim,@alani,@telno,@mail,@sifre)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", D.Isim);
                komut.Parameters.AddWithValue("@soyisim", D.Soyisim);
                komut.Parameters.AddWithValue("@alani", D.Alani);
                komut.Parameters.AddWithValue("@telno", D.TelNo);
                komut.Parameters.AddWithValue("@mail", D.Mail);
                komut.Parameters.AddWithValue("@sifre", D.Sifre);
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
                baglanti.Close() ;
            }
        }
        public List<Hasta> HastaListele()
        {
            List<Hasta> hastalar = new List<Hasta>();
            try
            {
                komut.CommandText = "SELECT ID,ReceteID,Isim,Soyisim,TCK,TelNo,Sikayet,Teshis,Tarih FROM Hastalar";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Hasta has = new Hasta();
                    has.ID = okuyucu.GetInt32(0);
                    has.ReceteID = okuyucu.GetInt32(1);
                    has.Isim = okuyucu.GetString(2);
                    has.Soyisim = okuyucu.GetString(3);
                    has.TCK = okuyucu.GetString(4);
                    has.TelNo = okuyucu.GetString(5);
                    has.Sikayet = okuyucu.GetString(6);
                    has.Teshis = okuyucu.GetString(7);
                    has.Tarih = okuyucu.GetDateTime(8);

                    hastalar.Add(has);
                }
                return hastalar;
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
        public void HastaSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Hastalar WHERE ID=@id";
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
        public bool HastaEkle(Hasta H)
        {
            try
            {
                komut.CommandText = "INSERT INTO Hastalar (ReceteID,Isim,Soyisim,TCK,TelNo,Sikayet,Teshis,Tarih) VALUES(@receteid,@isim,@soyisim,@tck,@telno,@sikayet,@teshis,@tarih)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@receteid", H.ReceteID);
                komut.Parameters.AddWithValue("@isim", H.Isim);
                komut.Parameters.AddWithValue("@soyisim", H.Soyisim);
                komut.Parameters.AddWithValue("@tck", H.TCK);
                komut.Parameters.AddWithValue("@telno", H.TelNo);
                komut.Parameters.AddWithValue("@sikayet", H.Sikayet);
                komut.Parameters.AddWithValue("@teshis", H.Teshis);
                komut.Parameters.AddWithValue("@tarih", H.Tarih);
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
        public bool EczaciEkle(Eczaci E)
        {
            try
            {
                komut.CommandText = "INSERT INTO Eczacilar (Isim,Soyisim,Mail,Sifre) VALUES(@isim,@soyisim,@mail,@sifre)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", E.Isim);
                komut.Parameters.AddWithValue("@soyisim", E.Soyisim);
                komut.Parameters.AddWithValue("@mail", E.Mail);
                komut.Parameters.AddWithValue("@sifre", E.Sifre);
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
        public List<Eczaci> EczaciListele()
        {
            List<Eczaci> eczacilar = new List<Eczaci>();
            try
            {
                komut.CommandText = "SELECT ID,Isim,Soyisim,Mail,Sifre FROM Eczacilar";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Eczaci E = new Eczaci();
                    E.ID = okuyucu.GetInt32(0);
                    E.Isim = okuyucu.GetString(1);
                    E.Soyisim = okuyucu.GetString(2);
                    E.Mail = okuyucu.GetString(3);
                    E.Sifre = okuyucu.GetString(4);

                    eczacilar.Add(E);
                }
                return eczacilar;
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
        public void EczaciSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Eczacilar WHERE ID=@id";
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
        public bool IlacEkle(Ilac I)
        {
            try
            {
                komut.CommandText = "INSERT INTO Ilaclar (Isim,SKT,Adet,BirimFiyat) VALUES(@isim,@skt,@adet,@birimfiyat)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", I.Isim);
                komut.Parameters.AddWithValue("@skt", I.SKT);
                komut.Parameters.AddWithValue("@adet", I.Adet);
                komut.Parameters.AddWithValue("@birimfiyat", I.BirimFiyat);
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
        public List<Ilac> IlacListele()
        {
            List<Ilac> ilaclar = new List<Ilac>();
            try
            {
                komut.CommandText = "SELECT ID,Isim,SKT,Adet,BirimFiyat FROM Ilaclar";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Ilac I = new Ilac();
                    I.ID = okuyucu.GetInt32(0);
                    I.Isim = okuyucu.GetString(1);
                    I.SKT = okuyucu.GetString(2);
                    I.Adet = okuyucu.GetInt32(3);
                    I.BirimFiyat = okuyucu.GetInt32(4);
                    ilaclar.Add(I);
                }
                return ilaclar;
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
        public void IlacSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Ilaclar WHERE ID=@id";
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
        public bool ReceteOlustur(Recete R)
        {
            try
            {
                komut.CommandText = "INSERT INTO Receteler (IlaclarID,Isim,OlusturmaTarihi) VALUES(@ilaclarid,@isim,@olusturmatarihi)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@ilaclarid",R.IlaclarID);
                komut.Parameters.AddWithValue("@isim", R.Isim);
                komut.Parameters.AddWithValue("@olusturmatarihi", R.Tarih);
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
        public List<Recete> ReceteListele()
        {
            List<Recete> receteler = new List<Recete>();
            try
            {
                komut.CommandText = "SELECT ID,IlaclarID,Isim,OlusturmaTarihi FROM Receteler";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Recete R = new Recete();
                    R.ID = okuyucu.GetInt32(0);
                    R.IlaclarID = okuyucu.GetInt32(1);
                    R.Isim = okuyucu.GetString(2);
                    R.Tarih = okuyucu.GetDateTime(3);
                    receteler.Add(R);
                }
                return receteler;
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
        public void ReceteSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Receteler WHERE ID=@id";
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
        #endregion
    }
}
