﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mercury.aspx.cs" Inherits="WebForm.Mercury" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Mercury Plant</h1>
            
        </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Mercury.jpg" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Plants.aspx">Back</asp:HyperLink>
    </form>
</body>
</html>
