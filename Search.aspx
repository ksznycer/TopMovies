﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    search!
    <div>
        <asp:Panel ID="Panel1" runat="server" BackColor="#F9F9F9" BorderStyle="Outset">
            <asp:Label ID="Label1" runat="server" Text="Genre"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Vote"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>

