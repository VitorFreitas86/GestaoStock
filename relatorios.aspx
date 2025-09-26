<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relatorios.aspx.cs" Inherits="gestaostocks.relatorios" %>

<%@ Register Src="~/header.ascx" TagPrefix="uc1" TagName="header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:whitesmoke;font-size:x-large;">
    <form id="form1" runat="server">
        <uc1:header runat="server" ID="header" />
         <div style="float:right;">
             <asp:Panel ID="Panel_saidas" runat="server"  Visible="false">
                 <asp:Label ID="Label2" runat="server" Text="Data inicio"></asp:Label>&nbsp;

                    <asp:TextBox ID="tb_inicio_saida" runat="server" Width="125" ReadOnly="false" TextMode="Date"  ></asp:TextBox>
                                                            
    &nbsp;<asp:Label ID="Label3" runat="server" Text="Fim"></asp:Label>&nbsp;
                             <asp:TextBox ID="tb_fim_saida" runat="server" Width="125" ReadOnly="false" TextMode="Date"  ></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="Pesquisar" OnClick="Button3_Click" Font-Size="X-Large" />
                 <br />
                 <asp:Button ID="Button4" runat="server" Text="Exportar" Width="100%" OnClick="Button4_Click" Visible="false" Font-Size="X-Large" />
       
                          <asp:GridView ID="GridView3" runat="server"  AutoGenerateColumns="False"  DataKeyNames="idsaida" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="GridView3_RowDataBound">
                    <Columns>
                            <asp:BoundField DataField="data_saida"  HeaderText="Data" />
                              <asp:BoundField DataField="funcionario"  HeaderText="Funcionário" />
                        <asp:BoundField DataField="designacao_destino"  HeaderText="Destino" />
                        <asp:BoundField DataField="requerente"  HeaderText="Requerente" />
                            <asp:TemplateField>
                        <ItemTemplate>
                            <tr > <td colspan="100%" >
                                <div style="float:right;">
                                <asp:GridView ID="GridView_produtos_saidas"  runat="server"  AutoGenerateColumns="False" DataKeyNames="idprodutos" CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
             
            <Columns>
                <asp:BoundField DataField="designacao" HeaderText="Designação" />
               
                 <asp:BoundField DataField="tipo"  HeaderText="Qt" />
                     <asp:BoundField DataField="quantidade_saida"  HeaderText="." />
            </Columns>
               <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
               <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
               <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
               <RowStyle BackColor="White" ForeColor="#003399" />
               <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
               <SortedAscendingCellStyle BackColor="#EDF6F6" />
               <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
               <SortedDescendingCellStyle BackColor="#D6DFDF" />
               <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
                               </div>  </td></tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                     
                     
                      <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                     <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                     <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                     <RowStyle BackColor="White" ForeColor="#003399" />
                     <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                     <SortedAscendingCellStyle BackColor="#EDF6F6" />
                     <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                     <SortedDescendingCellStyle BackColor="#D6DFDF" />
                     <SortedDescendingHeaderStyle BackColor="#002876" />
                 </asp:GridView>
 
            </asp:Panel>


        <asp:Panel ID="panel_entradas" runat="server" Visible="false">
           
                <asp:Label ID="Label4" runat="server" Text="Data inicio"></asp:Label>&nbsp;

                    <asp:TextBox ID="tb_data_inicio" runat="server" Width="125" ReadOnly="false" TextMode="Date"  ></asp:TextBox>
                                                            
    &nbsp;<asp:Label ID="Label1" runat="server" Text="Fim"></asp:Label>&nbsp;
                             <asp:TextBox ID="tb_data_fim" runat="server" Width="125" ReadOnly="false" TextMode="Date"  ></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Pesquisar" OnClick="Button1_Click" Font-Size="X-Large" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Exportar" OnClick="Button2_Click" Width="100%" Visible="false" Font-Size="X-Large"/>
                      
            <asp:GridView ID="GridView2" Width="100%" runat="server" AutoGenerateColumns="False"  DataKeyNames="identrada" OnRowDataBound="GridView2_RowDataBound" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                     <asp:BoundField DataField="numero_fatura"  HeaderText="Nº Fatura" />
                     <asp:BoundField DataField="data_entrada"  HeaderText="Data" />
                     <asp:BoundField DataField="funcionario"  HeaderText="Funcionário" />
                     <asp:BoundField DataField="nome"  HeaderText="Fornecedor" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr > <td colspan="100%" >
                                <div style="float:right;">
                                <asp:GridView ID="GridView_produtos"  runat="server"  AutoGenerateColumns="False" DataKeyNames="idprodutos" CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
             
            <Columns>
                <asp:BoundField DataField="designacao" HeaderText="Designação" />
               
                 <asp:BoundField DataField="tipo"  HeaderText="Qt" />
                     <asp:BoundField DataField="quantidade_entrada"  HeaderText="." />
            </Columns>
               <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
               <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
               <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
               <RowStyle BackColor="White" ForeColor="#003399" />
               <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
               <SortedAscendingCellStyle BackColor="#EDF6F6" />
               <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
               <SortedDescendingCellStyle BackColor="#D6DFDF" />
               <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
                               </div>  </td></tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
                 </asp:Panel>
            
        <asp:Panel ID="panel_stock" runat="server" Visible="false">
             <asp:Button ID="btn_export_stock" runat="server" Text="Exportar" OnClick="btn_export_stock_Click" Width="100%" visible="false" Font-Size="X-Large"/>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idprodutos" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
            <Columns>
                
                <asp:BoundField DataField="designacao" HeaderText="Designação" />
                <asp:BoundField DataField="quantidade"  HeaderText="Qt" />
                 <asp:BoundField DataField="tipo"  HeaderText="" />
                     

                <asp:TemplateField HeaderText="Confirmação Mensal">
                        <ItemTemplate>
                            </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
               <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
               <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
               <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
               <RowStyle BackColor="White" ForeColor="#003399" />
               <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
               <SortedAscendingCellStyle BackColor="#EDF6F6" />
               <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
               <SortedDescendingCellStyle BackColor="#D6DFDF" />
               <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        </asp:Panel>
              </div>
    <div>
    <table>
        <tr>
            <td>
                <asp:Button ID="btn_r_entrada" runat="server" Text="Relatório Entrada" Width="227px" OnClick="btn_r_entrada_Click" Font-Size="X-Large" />
            </td>
        </tr>
                <tr>
            <td>
                <asp:Button ID="btn_r_saida" runat="server" Text="Relatório Saída" Width="227px" OnClick="btn_r_saida_Click" Font-Size="X-Large"/>
            </td>
        </tr>
            <tr>
            <td>
                <asp:Button ID="btn_r_stock" runat="server" Text="Relatório Stock" Width="227px" OnClick="btn_r_stock_Click" Font-Size="X-Large"/>
            </td>
        </tr>
    </table>
    </div>
       
    </form>
</body>
</html>
