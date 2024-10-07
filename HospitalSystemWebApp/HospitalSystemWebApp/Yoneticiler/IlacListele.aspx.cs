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
        protected void Page_Load(object sender, EventArgs e)
        {
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