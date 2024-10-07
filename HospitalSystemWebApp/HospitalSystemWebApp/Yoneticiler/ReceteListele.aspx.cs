using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Yoneticiler
{
    public partial class ReceteListele : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_receteler.DataSource = vm.ReceteListele();
            lv_receteler.DataBind();
        }

        protected void lv_receteler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            vm.ReceteSil(id);
            lv_receteler.DataSource = vm.ReceteListele();
            lv_receteler.DataBind();
        }
    }
}