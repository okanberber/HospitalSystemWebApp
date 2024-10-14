<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticiler/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="EczaciListele.aspx.cs" Inherits="HospitalSystemWebApp.Yoneticiler.EczaciListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="IslemlerCss/EczaciListeleCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="baslik">
      <h2>Eczacılar</h2>
  </div>
  <div class="tablotasiyici">
      <asp:ListView ID="lv_eczacilar" runat="server" OnItemCommand="lv_eczacilar_ItemCommand">
          <LayoutTemplate>
              <table cellspacing="0" cellpadding="0" class="tablo">
              <tr>
                  <th>ID</th>
                  <th>İsim</th>
                  <th>Soyisim</th>
                  <th>Mail</th>
                  <th>Sifre</th>
                  <th>Seçenekler</th>
              </tr>
              <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                  </table>
          </LayoutTemplate>
          <ItemTemplate>
              <tr>
                  <td><%#Eval("ID") %></td>
                  <td><%#Eval("Isim") %></td>
                  <td><%#Eval("Soyisim") %></td>
                  <td><%#Eval("Mail") %></td>
                  <td><%#Eval("Sifre") %></td>
                  <td>
                      <a href="/Islemler/EczaciDuzenle.aspx?eczaciId=<%# Eval("ID") %>">Düzenle</a>
                      <asp:LinkButton ID="lbtn_sil" runat="server" Text="Sil" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                  </td>
              </tr>
          </ItemTemplate>
      </asp:ListView>
  </div>
</asp:Content>
