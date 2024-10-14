using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Eczacilar
{
    public partial class EczaciMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanEczaci"] != null)
            {
                Eczaci E = (Eczaci)Session["GirisYapanEczaci"];
            }
            else
            {
                Response.Redirect("/Yoneticiler/EczaciGiris.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["GirisYapanEczaci"] = null;
            Response.Redirect("/Eczacilar/EczaciGiris.aspx");
        }
    }
}