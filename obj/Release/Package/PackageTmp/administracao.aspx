<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administracao.aspx.cs" Inherits="gestaostocks.administracao" %>

<%@ Register Src="~/header.ascx" TagPrefix="uc1" TagName="header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:whitesmoke; font-size:x-large;">
    <form id="form1" runat="server">
        <uc1:header runat="server" ID="header" />
        <br />
    <div style="float:left;">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Área de Destino:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tb_destino" runat="server"  MaxLength="45"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btn_gravar" runat="server" Text="Gravar" OnClick="btn_gravar_Click" />
            </td>
        </tr>
    </table>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="iddestinos" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" ShowHeader="False" CellPadding="4" ForeColor="#333333" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="designacao_destino" />
          
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
    </div>

            <div style="float:right;">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Funcionário:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tb_funcionario" runat="server" MaxLength="45"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btn_funcionario" runat="server" Text="Gravar" OnClick="btn_funcionario_Click"  />
            </td>
        </tr>
    </table>
                <div style="float:right;">
        <asp:GridView ID="GridView2" runat="server" DataKeyNames="idfuncionario" AutoGenerateColumns="False" ShowHeader="False" CellPadding="4" ForeColor="#333333" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="nome_funcionario" />
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
                    </div>
    </div>
    </form>
</body>
</html>
