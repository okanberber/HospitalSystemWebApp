using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Yoneticiler
{
    public partial class EczaciListele : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanYonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["GirisYapanYonetici"];
                lv_eczacilar.DataSource = vm.EczaciListele();
                lv_eczacilar.DataBind();
            }
            else
            {
                Response.Redirect("/Yoneticiler/YoneticiGiris.aspx");
            }
            
        }

        protected void lv_eczacilar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            vm.EczaciSil(id);
            lv_eczacilar.DataSource = vm.EczaciListele();
            lv_eczacilar.DataBind();
        }
    }
}