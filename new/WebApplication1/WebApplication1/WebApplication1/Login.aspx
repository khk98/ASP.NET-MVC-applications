<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <form id="form1" runat="server">
        <div>
            <table border="0" >
    <tr>
        <th colspan="3">
            Login
        </th>
    </tr>
    <tr>
        <td>
            Email-id
        </td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Password
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                runat="server" />
        </td>
    </tr>

   

              
   
      
         


    <tr>

        <td>
        </td>
        <td>
            
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
            
        </td>
        <td>
            
            <asp:Label ID="Label3" runat="server" ForeColor="#00CC00" Text="Login succesful" Visible="False"></asp:Label>
            
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Unsuccesful" Visible="False"></asp:Label>
        </td>
    </tr>
</table>
           
</div>
        
    </form>
</body>
</html>
