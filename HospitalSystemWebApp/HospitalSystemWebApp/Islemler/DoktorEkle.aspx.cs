using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Yoneticiler
{
    public partial class DoktorEkle : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanYonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["GirisYapanYonetici"];
                lv_doktorlar.DataSource = vm.DoktorListele();
                lv_doktorlar.DataBind();
            }
            else
            {
                Response.Redirect("/Yoneticiler/YoneticiGiris.aspx");
            }
        }

        protected void lv_doktorlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {

            Doktor D = new Doktor();
            D.Isim = tb_Isim.Text;
            D.Soyisim = tb_soyisim.Text;
            D.Alani = tb_alan.Text;
            D.TelNo = tb_telefon.Text;
            D.Mail = tb_mail.Text;
            D.Sifre = tb_sifre.Text;
            vm.DoktorEkle(D);
            lv_doktorlar.DataSource = vm.DoktorListele();
            lv_doktorlar.DataBind();
        }
    }
}