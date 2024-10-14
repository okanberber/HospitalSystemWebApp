using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystemWebApp
{
    public partial class AnaSayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_doktorgiris_Click(object sender, EventArgs e)
        {
            Response.Redirect("Doktorlar/DoktorGiris.aspx");
        }

        protected void lbtn_eczacigiris_Click(object sender, EventArgs e)
        {
            Response.Redirect("Eczacilar/EczaciGiris.aspx");
        }
    }
}