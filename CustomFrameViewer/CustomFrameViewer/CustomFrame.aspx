<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomFrame.aspx.cs" Inherits="CustomFrameViewer.CustomFrame" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Report Viewer</title>
    <style>
        /* Center the report viewer container */
        .report-container {
            width: 80%;  /* You can adjust this value */
            margin: 0 auto;  /* Centers the container horizontally */
            text-align: center;  /* Centers the content inside */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Add the ScriptManager -->
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <div class="report-container">
            <!-- Add ReportViewer Control -->
            <rsweb:ReportViewer 
                ID="ReportViewer1" 
                runat="server" 
                Width="100%" 
                Height="600px" 
                ShowToolBar="True" 
                PrintMode="PrintLayout" 
                RenderingMode="Local">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
