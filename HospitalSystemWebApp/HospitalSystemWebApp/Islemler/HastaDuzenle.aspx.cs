using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Islemler
{

    public partial class HastaDuzenle : System.Web.UI.Page
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
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["hastaId"]);
                    Hasta H = vm.HastaGetir(id);
                    if (H != null)
                    {
                        tb_receteid.Text = Convert.ToString(H.ReceteID);
                        tb_Isim.Text = H.Isim;
                        tb_soyisim.Text = H.Soyisim;
                        tb_tck.Text = H.TCK;
                        tb_telefon.Text = H.TelNo;
                        tb_sikayet.Text = H.Sikayet;
                        tb_teshis.Text =H.Teshis;
                        
                    }
                    else
                    {
                        Response.Redirect("/Islemler/HastaListele.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("/Islemler/HastaListele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["hastaId"]);
            Hasta H = vm.HastaGetir(id);
            H.ReceteID = Convert.ToInt32(tb_receteid.Text);
            H.Isim = tb_Isim.Text;
            H.Soyisim = tb_soyisim.Text;
            H.TCK = tb_tck.Text;
            H.TelNo = tb_telefon.Text;
            H.Sikayet = tb_sikayet.Text;
            H.Teshis = tb_teshis.Text;
            vm.HastaGuncelle(H);
        }

        protected void lv_doktorlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
    }
}