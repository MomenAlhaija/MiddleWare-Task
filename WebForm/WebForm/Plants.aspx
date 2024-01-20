<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plants.aspx.cs" Inherits="WebForm.Plants" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/Images/Plants.jpg">
            <asp:CircleHotSpot NavigateUrl="~/Venus.aspx" Radius="50" X="80" Y="80" />
            <asp:CircleHotSpot NavigateUrl="~/Earth.aspx" Radius="50" X="120" Y="80" />
            <asp:CircleHotSpot NavigateUrl="~/Mercury.aspx" Radius="50" X="80" Y="90" />
        </asp:ImageMap>
    </form>
</body>
</html>
