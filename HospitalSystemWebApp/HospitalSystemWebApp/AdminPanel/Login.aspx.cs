using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
namespace HospitalSystemWebApp.AdminPanel
{
    public partial class Login : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text))
            {
                if (!string.IsNullOrEmpty(tb_password.Text)) 
                {
                    Admins y = dm.AdminLogin(tb_mail.Text, tb_password.Text);
                    if (y != null)
                    {
                        Response.Redirect("AdminDefault.aspx");
                        pnl_basarisiz.Visible = false;
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Kullanıcı Bulunamadı";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Şifre boş bırakılamaz";
                }
            }
            else
            {
                pnl_basarisiz.Visible= true;
                lbl_mesaj.Text = "Mail Adresi Boş Bırakılamaz";
            }
        }
    }
}