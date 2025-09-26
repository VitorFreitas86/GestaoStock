<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="produtos.aspx.cs" Inherits="gestaostocks.produtos" %>

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
            <asp:Label ID="Label2" runat="server" Text="Produtos" Font-Bold="true" Font-Size="X-Large"></asp:Label>
        <br />
    <div>
    <table>
        <tr>
            <td>
                Designação
            </td>
            <td>
                <asp:TextBox ID="tb_designacao" runat="server" Width="503px" MaxLength="45"></asp:TextBox>
            </td>
             <td>
                Tipo
            </td>
            <td>
                <asp:DropDownList ID="ddl_tipo" runat="server">
                     <asp:ListItem Text="--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="UN" Value="UN"></asp:ListItem>   
                    <asp:ListItem Text="Kg" Value="Kg"></asp:ListItem>
                    <asp:ListItem Text="g" Value="g"></asp:ListItem>
                    <asp:ListItem Text="L" Value="L"></asp:ListItem>
                        
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv1" ForeColor="Red" runat="server" ControlToValidate="ddl_tipo" InitialValue="0" ErrorMessage="Necessário selecionar o tipo de medida do produto" />
            </td>
            <td>

        <asp:Button ID="btn_gravar" runat="server" Text="Gravar" OnClick="btn_gravar_Click" Font-Size="X-Large" />

            </td>
        </tr>
    </table>
    </div>
        <asp:GridView ID="GridView1" ShowHeader="false" runat="server" AutoGenerateColumns="False" DataKeyNames="idprodutos" CellPadding="4" ForeColor="#333333" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="designacao" />
                 <asp:BoundField DataField="tipo" />
                    <asp:BoundField DataField="quantidade" />
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
