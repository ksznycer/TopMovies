<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TopGenre.aspx.cs" Inherits="TopGenre" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" Visible="True">
    top genre!
    <div id="chart" style="width:500px;height:400px">
        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Palette="Excel" Height="800px" Width="800px">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" BackImageTransparentColor="Transparent" Font="Microsoft Sans Serif, 8.25pt"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>

</asp:Content>

