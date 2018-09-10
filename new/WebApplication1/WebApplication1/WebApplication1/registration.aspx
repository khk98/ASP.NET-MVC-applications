<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="WebApplication1.registration" %>

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
            Registration
        </th>
    </tr>
    <tr>
        <td>
            Username
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
            Confirm Password
        </td>
        <td>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
        </td>
        <td>
            <asp:CompareValidator ErrorMessage="Passwords don't match." ForeColor="Red" ControlToCompare="txtPassword"
                ControlToValidate="txtConfirmPassword" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Email
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" />
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
                
            <asp:TextBox ID="txtAddressLine1" runat="server"></asp:TextBox>
                
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
                
            <asp:TextBox ID="txtAddressLine2" runat="server"></asp:TextBox>
                
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
                
           
                
            <asp:DropDownList ID="dropdownCountry" runat="server">
                <asp:ListItem>Country1</asp:ListItem>
                <asp:ListItem>Country2</asp:ListItem>
                <asp:ListItem>Country2</asp:ListItem>
                <asp:ListItem>Country3</asp:ListItem>
                <asp:ListItem>Country4</asp:ListItem>
            </asp:DropDownList>
                
           
                
        </td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="dropdownCountry" />
        </td>
    </tr>
                 <tr>
        <td class="auto-style1">
          State
        </td>
        <td class="auto-style1">
                
           
                
            <asp:DropDownList ID="dropdownState" runat="server">
                <asp:ListItem>State1</asp:ListItem>
                <asp:ListItem>State2</asp:ListItem>
                <asp:ListItem>State3</asp:ListItem>
                <asp:ListItem>State4</asp:ListItem>
            </asp:DropDownList>
                
           
                
        </td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="dropdownState" />
        </td>
    </tr>
               <tr>
        <td class="auto-style1">
          City
        </td>
        <td class="auto-style1">
                
           
                
            <asp:DropDownList ID="dropdownCity" runat="server">
                <asp:ListItem>City1</asp:ListItem>
                <asp:ListItem>City2</asp:ListItem>
                <asp:ListItem>City3</asp:ListItem>
                <asp:ListItem>City4</asp:ListItem>
            </asp:DropDownList>
                
           
                
        </td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="dropdownCity" />
        </td>
    </tr>


    <tr>

        <td>
        </td>
        <td>
            <asp:Button Text="Submit" runat="server" OnClick="Unnamed6_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
           
</div>
        <asp:Label ID="Label1" runat="server" ForeColor="#33CC33" Text="Registration Succesful!" Visible="False"></asp:Label>
    </form>
</body>
</html>
