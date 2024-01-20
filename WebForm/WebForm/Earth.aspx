<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Earth.aspx.cs" Inherits="WebForm.Earth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Earth Plant</h2>
        </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Earth.jpg" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Plants.aspx">Back</asp:HyperLink>
    </form>
</body>
</html>
