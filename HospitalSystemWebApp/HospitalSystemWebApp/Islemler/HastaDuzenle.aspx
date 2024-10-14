<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticiler/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="HastaDuzenle.aspx.cs" Inherits="HospitalSystemWebApp.Islemler.HastaDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="IslemlerCss/HastaDuzenleCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <h2>Hasta Düzenle</h2>
    </div>
    <div class="icerik">
            <div class="sutun">
                <h3>ReçeteID</h3>
                <asp:TextBox ID="tb_receteid" runat="server"></asp:TextBox>
            </div>
            <div class="sutun">
                <h3>İsim</h3>
                <asp:TextBox ID="tb_Isim" runat="server"></asp:TextBox>
            </div>
            <div class="sutun">
                <h3>Soyisim</h3>
                <asp:TextBox ID="tb_soyisim" runat="server"></asp:TextBox>
            </div>
            <div class="sutun">
                <h3>TCK</h3>
                <asp:TextBox ID="tb_tck" runat="server"></asp:TextBox>
            </div>
            <div class="sutun">
                <h3>Telefon</h3>
                <asp:TextBox ID="tb_telefon" runat="server"></asp:TextBox>
            </div>
            <div class="sutun">
                <h3>Şikayet</h3>
                <asp:TextBox ID="tb_sikayet" runat="server"></asp:TextBox>
            </div>
            <div class="sutun">
                <h3>Teşhis</h3>
                <asp:TextBox ID="tb_teshis" runat="server"></asp:TextBox>
            </div>
            <div class="buton">
                <asp:LinkButton ID="lbtn_duzenle" runat="server" OnClick="lbtn_duzenle_Click" Text="DÜZENLE" CssClass="btncss"></asp:LinkButton>
            </div>

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
