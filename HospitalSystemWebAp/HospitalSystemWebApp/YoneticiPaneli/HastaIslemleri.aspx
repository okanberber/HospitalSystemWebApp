<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="HastaIslemleri.aspx.cs" Inherits="HospitalSystemWebApp.YoneticiPaneli.HastaIslemleri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/HastaCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="anatasiyici">
        <div class="baslik">
            <h2>Hasta İşlemleri</h2>
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
                    <asp:ListView ID="lv_hastalar" runat="server" OnItemCommand="lv_hastalar_ItemCommand">
                        <LayoutTemplate>
                            <table cellspacing="0" cellpadding="0" class="tablo">
                                <tr>
                                    <th>ID</th>
                                    <th>Reçete</th>
                                    <th>İsim</th>
                                    <th>Soyisim</th>
                                    <th>TC</th>
                                    <th>Telefon</th>
                                    <th>Şikayet</th>
                                    <th>Teşhis</th>
                                    <th>Tarih</th>
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
                                <td><%#Eval("ReceteID") %></td>
                                <td><%#Eval("Isim") %></td>
                                <td><%#Eval("Soyisim") %></td>
                                <td><%#Eval("TCK") %></td>
                                <td><%#Eval("TelNo") %></td>
                                <td><%#Eval("Sikayet") %></td>
                                <td><%#Eval("Teshis") %></td>
                                <td><%#Eval("Tarih") %></td>
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
                        <asp:TextBox ID="tb_tck" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:TextBox ID="tb_telefon" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:TextBox ID="tb_sikayet" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:TextBox ID="tb_teshis" runat="server" CssClass="metinkutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:CheckBox ID="cb_aktif" runat="server" />
                    </div>
                </div>
                <div class="stronglar">
                    <div class="strongsatir"><strong>İsim</strong></div>
                    <div class="strongsatir"><strong>Soyisim</strong></div>
                    <div class="strongsatir"><strong>TCK</strong></div>
                    <div class="strongsatir"><strong>Telefon</strong></div>
                    <div class="strongsatir"><strong>Şikayet</strong></div>
                    <div class="strongsatir"><strong>Teşhis</strong></div>
                    <div class="strongsatir"><strong>Durum</strong></div>

                </div>
                <div class="butonekle">
                    <asp:Button ID="btn_ekle" runat="server" Text="EKLE" CssClass="buton1" OnClick="btn_ekle_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
