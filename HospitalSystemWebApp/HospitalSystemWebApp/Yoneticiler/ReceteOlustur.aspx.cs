using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Yoneticiler
{
    public partial class ReceteOlustur : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_receteler.DataSource = vm.ReceteListele();
            lv_receteler.DataBind();
            ddl_ilaclar.DataSource = vm.IlacListele();
            ddl_ilaclar.DataBind();
        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string sayi = Convert.ToString(r.Next(0,10000));
            Recete R = new Recete();
            R.Isim = sayi;
            R.IlaclarID = Convert.ToInt32(ddl_ilaclar.Text);
            R.Tarih = DateTime.Now;

            vm.ReceteOlustur(R);
            lv_receteler.DataSource = vm.ReceteListele();
            lv_receteler.DataBind();
        }

        protected void lv_receteler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
    }
}