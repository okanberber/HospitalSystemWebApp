<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HospitalSystemWebApp.AdminPanel.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin-Login</title>
    <link href="Css/LoginCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">

            <div class="line">
                <br />
                <br />
                <h1 style="color:mediumpurple">Admin Login</h1>
            </div>
            <div class="line">
                <img style="width: 300px" src="Images/pngwing.com.png" />
                <div class="line">
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="box" placeholder="...@hotmail.com"></asp:TextBox>
                </div>
                <div class="line">
                    <asp:TextBox ID="tb_password" runat="server" CssClass="box" placeholder="password"></asp:TextBox>
                </div>
                <br />
               <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false"><strong>Başarısız !</strong>
                   <asp:Label ID="lbl_mesaj" runat="server">Mail Boş Bırakılamaz</asp:Label>
               </asp:Panel>
                <div class="line">
                    <asp:LinkButton ID="lbtn_login" runat="server" CssClass="button" OnClick="lbtn_login_Click">Login</asp:LinkButton>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
    </form>
</body>
</html>
