using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Islemler
{
    public partial class EczaciDuzenle : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["eczaciId"]);
                    Eczaci E = vm.EczaciGetir(id);
                    if (E != null)
                    {
                        tb_Isim.Text = E.Isim;
                        tb_soyisim.Text = E.Soyisim;
                        tb_mail.Text = E.Mail;
                        tb_sifre.Text = E.Sifre;
                    }
                    else
                    {
                        Response.Redirect("/Islemler/EczaciListele.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("/Islemler/EczaciListele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["eczaciId"]);
            Eczaci E = vm.EczaciGetir(id);
            E.Isim = tb_Isim.Text;
            E.Soyisim = tb_soyisim.Text;
            E.Mail = tb_mail.Text;
            E.Sifre = tb_sifre.Text;
            vm.EczaciGuncelle(E);
        }

        protected void lv_doktorlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
    }
}