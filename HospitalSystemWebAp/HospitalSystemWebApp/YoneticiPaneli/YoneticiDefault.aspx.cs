using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.YoneticiPaneli
{
    public partial class YoneticiDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanYonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["GirisYapanYonetici"];
                Response.Redirect("DoktorIslemleri.aspx");
            }
            else
            {
                Response.Redirect("YoneticiGiris.aspx");
            }
        }
    }
}