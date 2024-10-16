﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace HospitalSystemWebApp.Yoneticiler
{
    public partial class HastaEkle : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
       protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["GirisYapanYonetici"] != null)
            {             
                MasterPageFile = "~/Yoneticiler/YoneticiMaster.Master";
            }
            else if (Session["GirisYapanDoktor"]!=null)
            {
                MasterPageFile = "~/Doktorlar/DoktorMaster.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanDoktor"] != null)
            {
                Doktor d = (Doktor)Session["GirisYapanDoktor"];
            }
            else if (Session["GirisYapanYonetici"] != null)
            {
                Yonetici y = (Yonetici)Session["GirisYapanYonetici"];
            }
            else
            {
                Response.Redirect("/Doktorlar/DoktorGiris.aspx");
            }
            lv_hastalar.DataSource = vm.HastaListele();
            lv_hastalar.DataBind();
        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {
            Hasta H = new Hasta();
            H.ReceteID = Convert.ToInt32(tb_receteid.Text);
            H.Isim = tb_Isim.Text;
            H.Soyisim = tb_soyisim.Text;
            H.TCK = tb_tck.Text;
            H.TelNo = tb_telefon.Text;
            H.Sikayet = tb_sikayet.Text;
            H.Teshis = tb_teshis.Text;
            H.Tarih = DateTime.Now;
            vm.HastaEkle(H);
            lv_hastalar.DataSource = vm.HastaListele();
            lv_hastalar.DataBind();
        }

        protected void lv_hastalar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            
        }
    }
}