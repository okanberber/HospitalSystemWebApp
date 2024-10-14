<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticiler/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="DoktorDuzenle.aspx.cs" Inherits="HospitalSystemWebApp.Islemler.DoktorDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="IslemlerCss/DoktorDuzenleCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="baslik">
      <h2>Doktor Düzenle</h2>
  </div>
  <div class="icerik">
      <div class="sutun"><h3>İsim</h3><asp:TextBox ID="tb_Isim" runat="server"></asp:TextBox></div>
      <div class="sutun"><h3>Soyisim</h3><asp:TextBox ID="tb_soyisim" runat="server"></asp:TextBox></div>
      <div class="sutun"><h3>Alan</h3><asp:TextBox ID="tb_alan" runat="server"></asp:TextBox></div>
      <div class="sutun"><h3>Telefon</h3><asp:TextBox ID="tb_telefon" runat="server"></asp:TextBox></div>
      <div class="sutun"><h3>Mail</h3><asp:TextBox ID="tb_mail" runat="server"></asp:TextBox></div>
      <div class="sutun"><h3>Sifre</h3><asp:TextBox ID="tb_sifre" runat="server"></asp:TextBox></div>
      <div class="buton"><asp:LinkButton ID="lbtn_duzenle" runat="server" OnClick="lbtn_duzenle_Click" Text="DÜZENLE" CssClass="btncss"></asp:LinkButton></div>

  </div>

    <div class="tablotasiyici">
    <asp:ListView ID="lv_doktorlar" runat="server" OnItemCommand="lv_doktorlar_ItemCommand">
        <LayoutTemplate>
            <table cellspacing="0" cellpadding="0" class="tablo">
            <tr>
                <th>ID</th>
                <th>İsim</th>
                <th>Soyisim</th>
                <th>Alan</th>
                <th>Telefon</th>
                <th>Mail</th>
                <th>Sifre</th>
            </tr>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("ID") %></td>
                <td><%#Eval("Isim") %></td>
                <td><%#Eval("Soyisim") %></td>
                <td><%#Eval("Alani") %></td>
                <td><%#Eval("TelNo") %></td>
                <td><%#Eval("Mail") %></td>
                <td><%#Eval("Sifre") %></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>
</asp:Content>
