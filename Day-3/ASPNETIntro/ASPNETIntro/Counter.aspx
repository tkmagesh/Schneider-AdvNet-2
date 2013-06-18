<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Counter.aspx.cs" Inherits="ASPNETIntro.Counter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
    <div>
        <asp:TextBox runat="server" ID="txtNumber1"></asp:TextBox>
        <asp:TextBox runat="server" ID="txtNumber2"></asp:TextBox>
        <asp:Button Text="Add" runat="server" ID="btnAdd" OnClick="btnAdd_Click"/>
        <asp:Label Text="" ID="lblResult" runat="server" />
    </div>
    </form>
</body>
</html>
