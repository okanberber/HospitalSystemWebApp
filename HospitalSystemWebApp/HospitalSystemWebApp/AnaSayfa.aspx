<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="HospitalSystemWebApp.AnaSayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AnasayfaGiris</title>
    <link href="AnaSayfaCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="tasiyici">
             <div class="doktor">
                 <asp:LinkButton ID="lbtn_doktorgiris" runat="server" Text="DOKTOR" CssClass="doktorbuton" OnClick="lbtn_doktorgiris_Click"></asp:LinkButton>
             </div>
             <div class="eczaci">
                 <asp:LinkButton ID="lbtn_eczacigiris" runat="server" Text="ECZACI" CssClass="eczacibuton" OnClick="lbtn_eczacigiris_Click"></asp:LinkButton>
             </div>
     <div style="clear: both"></div>
 </div>

    </form>
</body>
</html>
