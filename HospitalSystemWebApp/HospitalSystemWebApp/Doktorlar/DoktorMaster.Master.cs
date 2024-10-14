using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Doktorlar
{
    public partial class DoktorMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanDoktor"] != null)
            {
                Doktor D = (Doktor)Session["GirisYapanDoktor"];
            }
            else
            {
                Response.Redirect("/Doktorlar/DoktorGiris.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["GirisYapanDoktor"] = null;
            Response.Redirect("/Doktorlar/DoktorGiris.aspx");
        }
    }
}