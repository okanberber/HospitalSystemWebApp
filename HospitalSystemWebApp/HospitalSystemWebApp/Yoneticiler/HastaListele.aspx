<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticiler/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="HastaListele.aspx.cs" Inherits="HospitalSystemWebApp.Yoneticiler.HastaListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="YoneticiCss/DoktorListeleCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="baslik">
     <h2>Hastalar</h2>
 </div>
 <div class="tablotasiyici">
     <asp:ListView ID="lv_hastalar" runat="server" OnItemCommand="lv_doktorlar_ItemCommand">
         <LayoutTemplate>
             <table cellspacing="0" cellpadding="0" class="tablo">
             <tr>
                 <th>ID</th>
                 <th>Reçete ID</th>
                 <th>İsim</th>
                 <th>Soyisim</th>
                 <th>TCK</th>
                 <th>Telefon</th>
                 <th>Şikayet</th>
                 <th>Teşhis</th>
                 <th>Tarih</th>
                 <th>Seçenekler</th>
             </tr>
             <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                 </table>
         </LayoutTemplate>
         <ItemTemplate>
             <tr>
                 <td><%#Eval("ID") %></td>
                 <td><%#Eval("ReceteID") %></td>
                 <td><%#Eval("Isim") %></td>
                 <td><%#Eval("Soyisim") %></td>
                 <td><%#Eval("TCK") %></td>
                 <td><%#Eval("TelNo") %></td>
                 <td><%#Eval("Sikayet") %></td>
                 <td><%#Eval("Teshis") %></td>
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
