<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebForm2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Product ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="ProductIDtxt" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Height="26px" OnClick="Button1_Click" Text="Load" />
            <br />
            Product Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="ProductNametxt" runat="server"></asp:TextBox>
            <br />
            Product Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="ProductPricetxt" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Save" Width="224px" />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="1" Width="497px">
                <SideBarTemplate>
                    <asp:DataList ID="SideBarList" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="SideBarButton" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <SelectedItemStyle Font-Bold="True" />
                    </asp:DataList>
                </SideBarTemplate>
                <WizardSteps>
                    <asp:WizardStep runat="server" title="Step 1">
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" title="Step 2">
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
