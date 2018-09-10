﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication1.Profile" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>

    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" >
    <tr>
        <th colspan="3">
           User Profile</th>
    </tr>
    <tr>
        <td>
            Username
        </td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" ReadOnly="True"  />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                runat="server" />
        </td>
    </tr>
   
   
    <tr>
        <td>
            Email
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail" runat="server" />
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
        </td>
    </tr>
       <tr>
        <td class="auto-style1">
           AddressLine1
        </td>
        <td class="auto-style1">
                
            <asp:TextBox ID="txtAddressLine1" runat="server" ReadOnly="True"></asp:TextBox>
                
        </td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="txtAddressLine1" />
        </td>
    </tr>
                 <tr>
        <td class="auto-style1">
           AddressLine2
        </td>
        <td class="auto-style1">
                
            <asp:TextBox ID="txtAddressLine2" runat="server" ReadOnly="True"></asp:TextBox>
                
        </td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="txtAddressLine2" />
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
          Country
        </td>
        <td class="auto-style1">
                
            <asp:TextBox ID="txtCountry" runat="server" ReadOnly="True"></asp:TextBox>
                
        </td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="txtCountry" />
        </td>
    </tr>
                 <tr>
        <td class="auto-style1">
          State
        </td>
        <td class="auto-style1">        
            <asp:TextBox ID="txtState" runat="server"  ReadOnly="True"></asp:TextBox>
        </td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="txtState" />
        </td>
    </tr>
               <tr>
        <td class="auto-style1">
          City
        </td>
        <td class="auto-style1">
                
            <asp:TextBox ID="txtCity" runat="server" Height="16px" ReadOnly="True"></asp:TextBox>
                
        </td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="txtCity" />
        </td>
    </tr>


    <tr>

        <td>
        </td>
        <td>
            <%--<asp:Button Text="Edit" runat="server" OnClick="Unnamed6_Click" />--%>
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Edit" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Logout" />
        </td>
    </tr>
</table>
           
</div>
        <asp:Label ID="Label1" runat="server" ForeColor="#33CC33" Text="Edit Succesful!" Visible="False"></asp:Label>
    </form>
</body>
</html>
