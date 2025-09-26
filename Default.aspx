<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="gestaostocks.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .wrp { width: 100%; text-align: center; }
    .frm { text-align: left; width: 751px; margin: auto; border: 1px solid black; }
    .fldLbl { white-space: nowrap; }
</style>
</head>
<body style="background-color:white;font-size:x-large;">
    <form id="form1" runat="server">
          
        <div class="wrp">
            <asp:Image ID="Image1" runat="server" Width="100%" ImageUrl="~/simbolo_da_escola.png" /><br /><br />
    <div class="frm">
         
    <div>
     
       <%-- <br />
        <br />--%>

    <table style="width:100%;">
        <tr >
            <td colspan="2" style="text-align:center; border-bottom:1px solid black; background-color:whitesmoke;">
              <b>  Software Gestão de Stocks</b>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td align="right">
                Nome Utilizador
            </td>
            <td>
                 <asp:TextBox ID="tb_user" runat="server" MaxLength="45"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Palavra-Chave
            </td>
            <td>
                <asp:TextBox ID="tb_pwd" runat="server" TextMode="Password" MaxLength="45"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <asp:Button ID="Button1" runat="server" Text="Autenticar" OnClick="Button1_Click" Font-Size="X-Large" Width="297px" /><br />
                <asp:Label ID="lb_erro" runat="server" Text="O nome de utilizador e/ou palavra-chave incorrecta." ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
        <br />
        <br />
        <br />
        <asp:Panel ID="panel_btn" runat="server" Visible="false" >
            
        <asp:Label ID="Label1" runat="server" Text="&nbsp; Selecione o armanzém:" Font-Size="X-Large" Font-Bold="true" Width="100%" BackColor="WhiteSmoke"  BorderWidth="1" BorderColor="Black"  ></asp:Label>
        <table >
            <tr>
                <td style="border:1px solid black;">
                  
                    <asp:ImageButton ID="ib_material_apoio" runat="server" Width="244px" Height="244px"  OnClick="ib_material_apoio_Click" ImageUrl="~/apoio.jpg" ToolTip="Armanzém de material de apoio" />
                </td>
                <td style="border:1px solid black;">
                     <asp:ImageButton ID="ib_material_limpeza" runat="server"  Width="244px" Height="244px" OnClick="ib_material_limpeza_Click" ImageUrl="~/limpeza.jpg" ToolTip="Armanzém de material de limpeza"/>
                </td>
                <td style="border:1px solid black;">
                     <asp:ImageButton ID="ib_material_limpeza_lajes" runat="server"   Width="244px" Height="244px" OnClick="ib_material_limpeza_lajes_Click" ImageUrl="~/limpeza_lajes.jpg" ToolTip="Armanzém de material de limpeza da escola das lajes"/>
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>
    </div>
            </div>
    </form>
</body>
</html>
