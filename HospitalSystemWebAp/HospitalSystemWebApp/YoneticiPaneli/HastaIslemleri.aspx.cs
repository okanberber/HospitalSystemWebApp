using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.YoneticiPaneli
{
    public partial class HastaIslemleri : System.Web.UI.Page
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
            lv_hastalar.DataSource = vm.HastaListele();
            lv_hastalar.DataBind();
        }

        protected void lv_hastalar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {

           Hastalar H = new Hastalar();
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                H.Isim = tb_isim.Text;
                if (!string.IsNullOrEmpty(tb_soyisim.Text))
                {
                    H.Soyisim = tb_soyisim.Text;
                    if (!string.IsNullOrEmpty(tb_tck.Text))
                    {
                        H.TCK = tb_tck.Text;
                        if (!string.IsNullOrEmpty(tb_telefon.Text))
                        {
                            H.TelNo = tb_telefon.Text;
                            if (!string.IsNullOrEmpty(tb_sikayet.Text))
                            {
                                    H.Sikayet = tb_sikayet.Text;
                                    H.Durum = cb_aktif.Checked;
                                    H.Silinmis = false;
                                    if (vm.HastaEkle(H))
                                    {
                                        pnl_basarili.Visible = true;
                                        pnl_basarisiz.Visible = false;
                                        lbl_basarilimesaj.Text = "Hasta Başarı İle Eklendi";
                                        Response.Redirect("HastaIslemleri.aspx");
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
                                    lbl_mesaj.Text = "şikayet alanı boş bırakılamaz";
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
                            lbl_mesaj.Text = "Tck boş bırakılamaz";
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
        }
    }
