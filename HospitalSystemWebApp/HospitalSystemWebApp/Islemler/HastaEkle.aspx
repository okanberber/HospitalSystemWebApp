<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticiler/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="HastaEkle.aspx.cs" Inherits="HospitalSystemWebApp.Yoneticiler.HastaEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="IslemlerCss/HastaEkleCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <h2>Hasta Ekle</h2>
    </div>
    <div class="icerik">
        <div class="sutun">
            <h3>ReçeteID</h3>
            <asp:TextBox ID="tb_receteid" runat="server"></asp:TextBox></div>
        <div class="sutun">
            <h3>İsim</h3>
            <asp:TextBox ID="tb_Isim" runat="server"></asp:TextBox></div>
        <div class="sutun">
            <h3>Soyisim</h3>
            <asp:TextBox ID="tb_soyisim" runat="server"></asp:TextBox></div>
        <div class="sutun">
            <h3>TCK</h3>
            <asp:TextBox ID="tb_tck" runat="server"></asp:TextBox></div>
        <div class="sutun">
            <h3>Telefon</h3>
            <asp:TextBox ID="tb_telefon" runat="server"></asp:TextBox></div>
        <div class="sutun">
            <h3>Şikayet</h3>
            <asp:TextBox ID="tb_sikayet" runat="server"></asp:TextBox></div>
        <div class="sutun">
            <h3>Teşhis</h3>
            <asp:TextBox ID="tb_teshis" runat="server"></asp:TextBox></div>
           
        <div class="buton">
            <asp:Button ID="btn_ekle" runat="server" OnClick="btn_ekle_Click" Text="EKLE" CssClass="btncss" /></div>
    </div>

    <div class="tablotasiyici">
        <asp:ListView ID="lv_hastalar" runat="server" OnItemCommand="lv_hastalar_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="tablo">
                    <tr>                       
                        <th>ID</th>
                        <th>ReçeteID</th>
                        <th>İsim</th>
                        <th>Soyisim</th>
                        <th>TCK</th>
                        <th>Telefon</th>
                        <th>Şikayet</th>
                        <th>Teşhis</th>
                        <th>Tarih</th>
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
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
