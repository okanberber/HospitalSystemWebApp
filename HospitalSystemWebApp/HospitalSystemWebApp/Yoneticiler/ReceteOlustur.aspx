<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticiler/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="ReceteOlustur.aspx.cs" Inherits="HospitalSystemWebApp.Yoneticiler.ReceteOlustur" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="YoneticiCss/ReceteOlusturCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="baslik">
      <h2>Reçete Oluştur</h2>
  </div>
  <div class="icerik">
      <div class="sutun"><h3>İlaçID</h3><asp:DropDownList ID="ddl_ilaclar" runat="server" DataTextField="Isim" DataValueField="ID"></asp:DropDownList></div>
      
      <div class="buton"><asp:Button ID="btn_ekle" runat="server" OnClick="btn_ekle_Click" Text="OLUŞTUR" CssClass="btncss"/></div>
  </div>

    <div class="tablotasiyici">
    <asp:ListView ID="lv_receteler" runat="server" OnItemCommand="lv_receteler_ItemCommand" >
        <LayoutTemplate>
            <table cellspacing="0" cellpadding="0" class="tablo">
            <tr>
                <th>ID</th>
                <th>İlaçID</th>
                <th>İsim</th>
                <th>OluşturmaTarihi</th>
            </tr>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("ID") %></td>
                <td><%#Eval("IlaclarID") %></td>
                <td><%#Eval("Isim") %></td>
                <td><%#Eval("Tarih") %></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>
</asp:Content>
