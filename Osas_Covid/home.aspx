<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Osas_Covid.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Osas_Covid</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/css/home.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="grid">
        <h2>Quantidade de novos casos por mês</h2>
            Selecione o Ano: 
            <asp:DropDownList runat="server" ID="yearlist" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="OnChange_YearList">
            </asp:DropDownList><br/><br/>
            
            <asp:GridView onrowdatabound="GridView1_RowDataBound" ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
