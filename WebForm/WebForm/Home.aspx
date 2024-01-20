<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebForm.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 400px;
        }
        .auto-style2 {
            width: 293px;
        }
        .auto-style4 {
            font-size: xx-large;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            width: 230px;
        }
        .auto-style7 {
            width: 293px;
            height: 38px;
        }
        .auto-style8 {
            width: 230px;
            height: 38px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Earth" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Mercury" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Venus" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Plants" />
        <br />
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

            <asp:View ID="View1" runat="server">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Plants.jpg" />
            </asp:View> 
            <asp:View ID="View2" runat="server">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Earth.jpg" />
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Mercury.jpg" />
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Venus.jpg" />
            </asp:View>
        </asp:MultiView>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <p>
                &nbsp;</p>
            <p>
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Gender" Text="Male" />
            </p>
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Gender" Text="Female" />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" />
            <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Value="0">Male</asp:ListItem>
                <asp:ListItem Value="1">Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />
            &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
        </asp:Panel>
        <table class="auto-style1">
            <tr>
                <td class="auto-style5" colspan="2">
                    <asp:Label ID="Label3" runat="server" CssClass="auto-style4" Text="Add User"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">User Name:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox1" runat="server" Width="214px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBox2" runat="server" Width="214px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Age:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBox3" runat="server" Width="214px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">
                    <asp:Button ID="Button7" runat="server" CssClass="auto-style4" Text="Add" OnClick="Button7_Click" />
                </td>
            </tr>
        </table>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Name</asp:TableCell>
                <asp:TableCell runat="server">Email</asp:TableCell>
                <asp:TableCell runat="server">Age</asp:TableCell>
            </asp:TableRow>
          
        </asp:Table>
        <br />
    </form>
</body>
</html>
