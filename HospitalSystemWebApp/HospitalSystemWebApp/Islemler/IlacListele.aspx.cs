using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Yoneticiler
{
    public partial class IlacListele : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["GirisYapanYonetici"] != null)
            {
                MasterPageFile = "~/Yoneticiler/YoneticiMaster.Master";
            }
            else if (Session["GirisYapanEczaci"] != null)
            {
                MasterPageFile = "~/Eczacilar/EczaciMaster.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanEczaci"] != null)
            {
                Eczaci E = (Eczaci)Session["GirisYapanEczaci"];
            }
            else if (Session["GirisYapanYonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["GirisYapanYonetici"];
            }
            else
            {
                Response.Redirect("/Eczacilar/EczaciGiris.aspx");
            }
            lv_ilaclar.DataSource = vm.IlacListele();
            lv_ilaclar.DataBind();
        }

        protected void lv_ilaclar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            vm.IlacSil(id);
            lv_ilaclar.DataSource = vm.IlacListele();
            lv_ilaclar.DataBind();
        }
    }
}