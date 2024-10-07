<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticiler/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="IlacEkle.aspx.cs" Inherits="HospitalSystemWebApp.Yoneticiler.IlacEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="YoneticiCss/IlacEkleCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="baslik">
      <h2>İlaç Ekle</h2>
  </div>
  <div class="icerik">
      <div class="sutun"><h3>İsim</h3><asp:TextBox ID="tb_Isim" runat="server"></asp:TextBox></div>
      <div class="sutun"><h3>SKT</h3><asp:TextBox ID="tb_skt" runat="server"></asp:TextBox></div>
      <div class="sutun"><h3>Adet</h3><asp:TextBox ID="tb_adet" runat="server"></asp:TextBox></div>
      <div class="sutun"><h3>BirimFiyat</h3><asp:TextBox ID="tb_birimfiyat" runat="server"></asp:TextBox></div>
      <div class="buton"><asp:Button ID="btn_ekle" runat="server" OnClick="btn_ekle_Click" Text="EKLE" CssClass="btncss"/></div>
  </div>

    <div class="tablotasiyici">
    <asp:ListView ID="lv_ilaclar" runat="server" OnItemCommand="lv_ilaclar_ItemCommand" >
        <LayoutTemplate>
            <table cellspacing="0" cellpadding="0" class="tablo">
            <tr>
                <th>ID</th>
                <th>İsim</th>
                <th>SKT</th>
                <th>Adet</th>
                <th>BirimFiyat</th>
            </tr>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("ID") %></td>
                <td><%#Eval("Isim") %></td>
                <td><%#Eval("SKT") %></td>
                <td><%#Eval("Adet") %></td>
                <td><%#Eval("BirimFiyat") %></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>
</asp:Content>
