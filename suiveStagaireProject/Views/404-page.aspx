<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404-page.aspx.cs" Inherits="suiveStagaireProject.Views._404_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="HomePage.aspx?id=<%=Session["id"]%>"> <img style="width=100%" src="../Layout/images/404-page.png"  /></a>
        </div>
    </form>
</body>
</html>
