<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fornecedor.aspx.cs" Inherits="gestaostocks.fornecedor" %>

<%@ Register Src="~/header.ascx" TagPrefix="uc1" TagName="header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:whitesmoke;font-size:x-large;">
    <form id="form1" runat="server">
        <uc1:header runat="server" ID="header" />
        <br />
          <asp:Label ID="Label2" runat="server" Text="Forncedores" Font-Bold="true" Font-Size="X-Large"></asp:Label>
        <br />
    <div>
    <table>
        <tr>
            <td>
                Nome
            </td>
            <td>
                <asp:TextBox ID="tb_nome" runat="server" Width="432px" MaxLength="45"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td>
                Morada
            </td>
            <td>
                <asp:TextBox ID="tb_morada" runat="server" Height="81px" TextMode="MultiLine" Width="432px" MaxLength="450"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                Telefone
            </td>
            <td>
                <asp:TextBox ID="tb_telefone" runat="server" Width="231px" MaxLength="45"></asp:TextBox>
            </td>
             <td>

        <asp:Button ID="btn_inserir_fornecedor" runat="server" Text="Inserir" OnClick="btn_inserir_fornecedor_Click" Font-Size="X-Large" />

             </td>
        </tr>
    </table>
    </div>
        <asp:GridView ID="GridView1" runat="server" ShowHeader="False" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="nome" />
                <asp:BoundField DataField="morada" />
                <asp:BoundField DataField="telefone" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </form>
</body>
</html>
