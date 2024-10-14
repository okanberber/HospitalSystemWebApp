using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Yoneticiler
{
    public partial class HastaListele : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["GirisYapanYonetici"] != null)
            {
                MasterPageFile = "~/Yoneticiler/YoneticiMaster.Master";
            }
            else if (Session["GirisYapanDoktor"] != null)
            {
                MasterPageFile = "~/Doktorlar/DoktorMaster.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanDoktor"] != null)
            {
                Doktor d = (Doktor)Session["GirisYapanDoktor"];
            }
            else if (Session["GirisYapanYonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["GirisYapanYonetici"];
            }
            else
            {
                Response.Redirect("/Doktorlar/DoktorGiris.aspx");
            }


            lv_hastalar.DataSource = vm.HastaListele();
            lv_hastalar.DataBind();
        }

        protected void lv_doktorlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            vm.HastaSil(id);
            lv_hastalar.DataSource = vm.HastaListele();
            lv_hastalar.DataBind();
        }
    }
}