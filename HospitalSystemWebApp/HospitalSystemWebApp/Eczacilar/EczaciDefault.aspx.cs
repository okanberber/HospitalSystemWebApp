using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Eczacilar
{
    public partial class EczaciDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanEczaci"] != null)
            {
                Eczaci E = (Eczaci)Session["GirisYapanEczaci"];

            }
            else
            {
                Response.Redirect("/Eczacilar/EczaciGiris.aspx");
            }
        }
    }
}