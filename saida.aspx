<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saida.aspx.cs" EnableEventValidation="false" Inherits="gestaostocks.saida" %>

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
            <asp:Label ID="Label2" runat="server" Text="Saída" Font-Bold="true"  ></asp:Label>
        <br />

             <div style="float:right;">
                   <asp:Label ID="Label1" runat="server" Text="Selecionar Produtos" Font-Bold="true" ForeColor="Black"></asp:Label>
            <asp:GridView ID="gv_produto" runat="server"  ShowHeader="false" AlternatingRowStyle-CssClass="even" AutoGenerateColumns="False" DataKeyNames="idprodutos" GridLines="None" HeaderStyle-CssClass="tableHeader" Width="100%" CellPadding="4" OnRowCreated="gv_produto_RowCreated" OnSelectedIndexChanged="gv_produto_SelectedIndexChanged" ForeColor="#333333" Font-Size="Large">
                            <AlternatingRowStyle CssClass="even" BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbSelect" CssClass="gridCB" runat="server" Enabled="false"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="designacao" HeaderText=""></asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle CssClass="tableHeader" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
            </div>


    <div>
      <table>
            <tr>
                <td>
                    Data
                </td>
                <td>
                    <asp:TextBox ID="tb_data" runat="server"   Enabled="false"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ControlToValidate="tb_data"  ErrorMessage="Necessário inserir a data" />
           </td>

                </tr>
          <tr>
              <td>
                  Área destino
              </td>
              <td>
                  <asp:DropDownList ID="ddl_zonas" runat="server">

                  </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="ddl_zonas" InitialValue="0" ErrorMessage="Necessário selecionar a área de destino" />
     
              </td>
          </tr>
            <tr>
              <td>
                 Funcionário
              </td>
                <td>
                     <asp:DropDownList ID="ddl_funcionario" runat="server">
             
                     </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ControlToValidate="ddl_funcionario" InitialValue="0" ErrorMessage="Necessário selecionar o Funcionário" />
     
                </td>
          </tr>
          <tr>
              <td>Requerente</td>
              <td>

                  <asp:TextBox ID="tb_requerente" runat="server" MaxLength="45"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  Produtos
              </td>
              <td>
                   <asp:DataList runat="server" ID="data_list" DataKeyNames="idprodutos" GridLines="Horizontal">
                            <ItemTemplate>
                                 <table ><tr>
                                    <td>
                                        <asp:Label ID="lb_designacao" runat="server" Text='<%# Eval("designacao") %>' Font-Bold="true"></asp:Label>
                                  <asp:Label ID="lb_id_produto" runat="server" Text='<%# Eval("idprodutos") %>' Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                           <asp:TextBox ID="tb_quantidade" runat="server"  ></asp:TextBox>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td colspan="2">
   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"  Font-Size="Medium" ControlToValidate="tb_quantidade" runat="server" ErrorMessage="Deve inserir apenas números" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  Font-Size="Medium" ForeColor="Red" runat="server" ControlToValidate="tb_quantidade"  ErrorMessage="Necessário inserir a quantidade" />
                    
                                    </td>
                                       </tr></table>       </ItemTemplate>
                        </asp:DataList>
              </td>
          </tr>
          </table>


    </div>
   
        <asp:Button ID="btn_gravar" runat="server" Text="Gravar" OnClick="btn_gravar_Click" Font-Size="X-Large" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator_produtos" ForeColor="Red" runat="server" ControlToValidate="ddl_funcionario" InitialValue="0" ErrorMessage="Necessário selecionar no mínimo um produto" />
         
        
    </form>
</body>
</html>
