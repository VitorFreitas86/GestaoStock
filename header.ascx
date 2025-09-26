<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="gestaostocks.header" %>
<table>
    <tr>
        <td>
            <asp:Button ID="btn_entrada" runat="server" Text="Entrada" OnClick="btn_entrada_Click" CausesValidation="false" Font-Size="X-Large" />
        </td>
          <td>
            <asp:Button ID="btn_saida" runat="server" Text="Saída" OnClick="btn_saida_Click"  CausesValidation="false" Font-Size="X-Large" />
        </td>
         <td>
            <asp:Button ID="btn_produtos" runat="server" Text="Produtos" OnClick="btn_produtos_Click"  CausesValidation="false" Font-Size="X-Large" />
        </td>
        <td>
            <asp:Button ID="btn_fornecedores" runat="server" Text="Fornecedores" OnClick="btn_fornecedores_Click"  CausesValidation="false" Font-Size="X-Large" />
        </td>
          <td>
            <asp:Button ID="btn_relatorios" runat="server" Text="Relatórios" OnClick="btn_relatorios_Click"  CausesValidation="false" Font-Size="X-Large" />
        </td>
         <td>
            <asp:Button ID="btn_administracao" runat="server" Text="Administração" OnClick="btn_administracao_Click"  CausesValidation="false" Font-Size="X-Large" />
        </td>
        <td>
             <asp:Button ID="Button1" runat="server" Text="Sair" Font-Size="X-Large" OnClick="Button1_Click"  CausesValidation="false" />
        </td>
    </tr>
</table>
