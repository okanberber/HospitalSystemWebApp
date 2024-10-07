<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="HospitalSystemWebApp.YoneticiPaneli.YoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yönetici-Giriş</title>
    <link href="Css/GirisCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="tasiyici">

     <div class="satir">
         <br />
         <br />
         <h1 style="color:mediumpurple">Yönetici Giriş</h1>
     </div>
     <div class="satir">
         <img style="width: 300px" src="Resimler/pngwing.com.png" />
         <div class="satir">
             <asp:TextBox ID="tb_mail" runat="server" CssClass="kutu" placeholder="...@hotmail.com"></asp:TextBox>
         </div>
         <div class="satir">
             <asp:TextBox ID="tb_sifre" runat="server" CssClass="kutu" placeholder="password" TextMode="Password"></asp:TextBox>
         </div>
         <br />
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false"><strong>Başarısız !</strong>
            <asp:Label ID="lbl_mesaj" runat="server">Mail Boş Bırakılamaz</asp:Label>
        </asp:Panel>
         <div class="satir">
             <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="button" OnClick="lbtn_giris_Click">Giriş Yap</asp:LinkButton>
         </div>
     </div>
     <div style="clear: both"></div>
 </div>
    </form>
</body>
</html>
