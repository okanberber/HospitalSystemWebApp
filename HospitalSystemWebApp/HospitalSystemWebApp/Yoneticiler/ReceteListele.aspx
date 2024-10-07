<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticiler/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="ReceteListele.aspx.cs" Inherits="HospitalSystemWebApp.Yoneticiler.ReceteListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="YoneticiCss/ReceteListeleCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="baslik">
     <h2>Reçeteler</h2>
 </div>
 <div class="tablotasiyici">
     <asp:ListView ID="lv_receteler" runat="server" OnItemCommand="lv_receteler_ItemCommand">
         <LayoutTemplate>
             <table cellspacing="0" cellpadding="0" class="tablo">
                 <tr>
                     <th>ID</th>
                     <th>İlaçID</th>
                     <th>İsim</th>
                     <th>OluşturmaTarihi</th>
                     <th>Seçenekler</th>
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
                 <td>
                     <a href="#">Düzenle</a>
                     <asp:LinkButton ID="lbtn_sil" runat="server" Text="Sil" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                 </td>
             </tr>
         </ItemTemplate>
     </asp:ListView>
 </div>
</asp:Content>
