using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Yoneticiler
{
    public partial class EczaciEkle : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_eczacilar.DataSource = vm.EczaciListele();
            lv_eczacilar.DataBind();
        }

        protected void lv_eczacilar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {
            Eczaci E = new Eczaci();
            E.Isim = tb_Isim.Text;
            E.Soyisim = tb_soyisim.Text;
            E.Mail = tb_mail.Text;
            E.Sifre = tb_sifre.Text;
            vm.EczaciEkle(E);
            lv_eczacilar.DataSource = vm.EczaciListele();
            lv_eczacilar.DataBind();
        }
    }
}