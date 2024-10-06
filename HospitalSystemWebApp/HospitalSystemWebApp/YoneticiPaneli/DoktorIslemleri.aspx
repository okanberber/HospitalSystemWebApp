<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="DoktorIslemleri.aspx.cs" Inherits="HospitalSystemWebApp.YoneticiPaneli.DoktorIslemleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/DoktorCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="anatasiyici">
        <div class="baslik">
            <h2>Doktor İşlemleri</h2>
        </div>
        <div class="icerik">
            <div class="sol">
                <div class="panel">
                    <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                        <strong>Basarisiz ! </strong>
                        <asp:Label ID="lbl_mesaj" runat="server">bıdıbıdı</asp:Label>
                    </asp:Panel>
                    <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                        <strong>Başarılı ! </strong>
                        <asp:Label ID="lbl_basarilimesaj" runat="server">bıdıbıdı</asp:Label>
                    </asp:Panel>
                </div>
                <div class="tablo">
                    <asp:ListView ID="lv_doktorlar" runat="server" OnItemCommand="lv_doktorlar_ItemCommand">
                        <LayoutTemplate>
                            <table cellspacing="0" cellpadding="0" class="tablo">
                                <tr>
                                    <th>ID</th>
                                    <th>İsim</th>
                                    <th>Soyisim</th>
                                    <th>Telefon</th>
                                    <th>Alan</th>
                                    <th>Mail</th>
                                    <th>Şifre</th>
                                    <th>Durum</th>
                                    <th>Silinmiş</th>
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
                                <td><%#Eval("TelNo") %></td>
                                <td><%#Eval("Alani") %></td>
                                <td><%#Eval("Mail") %></td>
                                <td><%#Eval("Sifre") %></td>
                                <td><%#Eval("Durum") %></td>
                                <td><%#Eval("Silinmis") %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablobuton" Text="SİL" CommandArgument='<%#Eval("ID") %>' CommandName="sil"></asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="tablobuton" Text="DÜZENLE" CommandArgument='<%#Eval("ID") %>' CommandName="duzenle"></asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CssClass="tablobuton" Text="DURUM DEGİŞTİR" CommandArgument='<%#Eval("ID") %>' CommandName="durum"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>

            <div class="sag">


                <div class="metinkutular">
                    <div class="satir">
                        <asp:TextBox ID="tb_isim" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:TextBox ID="tb_soyisim" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:TextBox ID="tb_telefon" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:TextBox ID="tb_alan" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:TextBox ID="tb_mail" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:CheckBox ID="cb_aktif" runat="server" />
                    </div>
                </div>
                <div class="stronglar">
                    <div class="strongsatir"><strong>İsim</strong></div>
                    <div class="strongsatir"><strong>Soyisim</strong></div>
                    <div class="strongsatir"><strong>Telefon</strong></div>
                    <div class="strongsatir"><strong>Alan</strong></div>
                    <div class="strongsatir"><strong>Mail</strong></div>
                    <div class="strongsatir"><strong>Şifre</strong></div>
                    <div class="strongsatir"><strong>Durum</strong></div>

                </div>
                <div class="butonekle">
                    <asp:Button ID="btn_ekle" runat="server" Text="EKLE" CssClass="buton1" OnClick="btn_ekle_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

