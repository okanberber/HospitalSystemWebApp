using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.YoneticiPaneli
{
    public partial class DoktorIslemleri : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanYonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["GirisYapanYonetici"];
            }
            else
            {
                Response.Redirect("YoneticiGiris.aspx");
            }
            lv_doktorlar.DataSource = vm.DoktorListele();
            lv_doktorlar.DataBind();
        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {
            Doktorlar dok = new Doktorlar();
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                dok.Isim = tb_isim.Text;
                if (!string.IsNullOrEmpty(tb_soyisim.Text))
                {
                    dok.Soyisim = tb_soyisim.Text;
                    if (!string.IsNullOrEmpty(tb_telefon.Text))
                    {
                        dok.TelNo = tb_telefon.Text;
                        if (!string.IsNullOrEmpty(tb_alan.Text))
                        {
                            dok.Alani = tb_alan.Text;
                            if (!string.IsNullOrEmpty(tb_mail.Text))
                            {
                                dok.Mail = tb_mail.Text;
                                if (!string.IsNullOrEmpty(tb_sifre.Text))
                                {
                                    dok.Sifre = tb_sifre.Text;
                                    dok.Durum = cb_aktif.Checked;
                                    dok.Silinmis = false;
                                    if (vm.DoktorEkle(dok))
                                    {
                                        pnl_basarili.Visible = true;
                                        pnl_basarisiz.Visible = false;
                                        lbl_basarilimesaj.Text = "Doktor Başarı İle Eklendi";
                                        Response.Redirect("DoktorIslemleri.aspx");
                                    }
                                    else
                                    {
                                        pnl_basarisiz.Visible = true;
                                        pnl_basarili.Visible = false;
                                        lbl_mesaj.Text = "bir hata oluştu";
                                    }
                                }
                                else
                                {
                                    lbl_mesaj.Text = "şifre alanı boş bırakılamaz";
                                    pnl_basarisiz.Visible = true;
                                }
                            }
                            else
                            {
                                lbl_mesaj.Text = "mail alanı boş bırakılamaz";
                                pnl_basarisiz.Visible = true;
                            }
                        }
                        else
                        {
                            lbl_mesaj.Text = "alan boş bırakılamaz";
                            pnl_basarisiz.Visible = true;
                        }
                    }
                    else
                    {
                        lbl_mesaj.Text = "telefon alanı boş bırakılamaz";
                        pnl_basarisiz.Visible = true;
                    }
                }
                else
                {
                    lbl_mesaj.Text = "soyisim alanı boş bırakılamaz";
                    pnl_basarisiz.Visible = true;
                }
            } 
            else
                {
                    lbl_mesaj.Text = "isim alanı boş bırakılamaz";
                    pnl_basarisiz.Visible = true;
                }
            
        }

        protected void lv_doktorlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id=Convert.ToInt32(e.CommandArgument);
            if ((e.CommandName == "sil"))
            {
                vm.DoktorSil(id);
            }
            if(e.CommandName == "durum")
            {
                vm.DoktorDurumDegistir(id);
            }
            if(e.CommandName == "duzenle")
            {
                    Doktorlar d = new Doktorlar();
                    d.Isim = tb_isim.Text;
                    d.Soyisim = tb_soyisim.Text;
                    d.TelNo = tb_telefon.Text;
                    d.Alani = tb_alan.Text;
                    d.Mail = tb_mail.Text;
                    d.Sifre = tb_sifre.Text;
                    d.Durum = cb_aktif.Checked;
                    d.Silinmis = false;
                    vm.DoktorDuzenle(id, d);
            }
            Response.Redirect("DoktorIslemleri.aspx");
        }
    }
}