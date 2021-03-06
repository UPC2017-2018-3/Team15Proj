﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatestudentpass.aspx.cs" Inherits="updatestudentpass" StylesheetTheme="Blue" %>
<head runat="server">
    <title>无标题页</title>
    <link href="link.css" rel="stylesheet" type="text/css" />
    <link href="../link.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" style="background-color: #99ccff">
            <tr>
                <td colspan="2" style="text-align: center; height: 39px;">
                    <strong><span style="color: #ff0099; font-family: 仿宋_GB2312">修改我的密码</span></strong></td>
                <td colspan="1" style="width: 166px; height: 39px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: right;">
                    <span style="font-size: 10pt; color: #0000ff"><strong>
                    原密码</strong></span></td>
                <td style="width: 143px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="118px" TextMode="Password"></asp:TextBox></td>
                <td style="width: 166px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="不能为空" Font-Bold="True" Font-Size="10pt"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: right;">
                    <span style="font-size: 10pt; color: #0000ff"><strong>
                    新密码</strong></span></td>
                <td style="width: 143px">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="117px"></asp:TextBox></td>
                <td style="width: 166px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="不能为空" Font-Bold="True" Font-Size="10pt"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: right;">
                    <strong><span style="font-size: 10pt; color: #0000ff">
                    重复一次</span></strong></td>
                <td style="width: 143px">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="116px"></asp:TextBox></td>
                <td style="width: 166px">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2"
                        ControlToValidate="TextBox3" ErrorMessage="两次新密码输入不相同" Font-Bold="True" Font-Size="10pt"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交" />
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    <input type ="reset"  ID="Button2" runat="server" Text="重置" /></td>
                <td colspan="1" style="width: 166px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
