using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Islemler
{
    public partial class DoktorDuzenle : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count!= 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["doktorId"]);
                    Doktor D = vm.DoktorGetir(id);
                    if (D != null)
                    {
                        tb_Isim.Text = D.Isim;
                        tb_soyisim.Text = D.Soyisim;
                        tb_alan.Text = D.Alani;
                        tb_telefon.Text = D.TelNo;
                        tb_mail.Text = D.Mail;
                        tb_sifre.Text = D.Sifre;
                    }
                    else
                    {
                        Response.Redirect("/Islemler/DoktorListele.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("/Islemler/DoktorListele.aspx");
            }
        }

        protected void lv_doktorlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }


        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["doktorId"]);
            Doktor D = vm.DoktorGetir(id);
            D.Isim = tb_Isim.Text;
            D.Soyisim = tb_soyisim.Text;
            D.Alani = tb_alan.Text;
            D.TelNo = tb_telefon.Text;
            D.Mail = tb_mail.Text;
            D.Sifre = tb_sifre.Text;
            vm.DoktorGuncelle(D);
        }
    }
}