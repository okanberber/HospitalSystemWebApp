<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticiler/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="IlacListele.aspx.cs" Inherits="HospitalSystemWebApp.Yoneticiler.IlacListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="IslemlerCss/IlacListeleCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <h2>İlaçlar</h2>
    </div>
    <div class="tablotasiyici">
        <asp:ListView ID="lv_ilaclar" runat="server" OnItemCommand="lv_ilaclar_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="tablo">
                    <tr>
                        <th>ID</th>
                        <th>İsim</th>
                        <th>SKT</th>
                        <th>Adet</th>
                        <th>BirimFiyat</th>
                        <th>Seçenekler</th>
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
                    <td>

                        <asp:LinkButton ID="lbtn_sil" runat="server" Text="Sil" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
