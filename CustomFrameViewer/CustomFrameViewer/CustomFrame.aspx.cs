using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

namespace CustomFrameViewer
{
    public partial class CustomFrame : System.Web.UI.Page
    {
        DataTable table = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadreport();
            }
        }

        void loadreport()
        {
            try
            {
                string rpttype = Request.QueryString["RptType"];
                string DocEntry = Request.QueryString["DocEntry"];

                string sql = "";
                string rpturl = "";
                string displayname = "";

                if (rpttype == "1")
                {
                    sql = "exec ICC_FORM_PR_BOQ '" + DocEntry + "'";
                    rpturl = "PRForm.rdlc";
                    displayname = "Purchase Request";
                }else if (rpttype == "2")
                {
                    sql = "exec ICC_FORM_PO '" + DocEntry + "'";
                    rpturl = "PO_Form.rdlc";
                    displayname = "Purchase Order";
                }
                else if (rpttype == "3")
                {
                    sql = "exec ICC_FORM_GRPO_BOQ '" + DocEntry + "'";
                    rpturl = "GRPOForm.rdlc";
                    displayname = "Goods Receipt PO";
                }
                else if (rpttype == "4")
                {
                    sql = "exec ICC_FORM_Goods_Return_BOQ '" + DocEntry + "'";
                    rpturl = "GRForm.rdlc";
                    displayname = "Goods Return";
                }
                else if (rpttype == "5")
                {
                    sql = "exec ICC_FORM_Goods_Issue_BOQ '" + DocEntry + "'";
                    rpturl = "GoodsIssue.rdlc";
                    displayname = "Goods Issue";
                }
                else if (rpttype == "6")
                {
                    sql = "exec ICC_FORM_Goods_Receipt_BOQ '" + DocEntry + "'";
                    rpturl = "GoodsReceipt.rdlc";
                    displayname = "Goods Receipt";
                }
                else if (rpttype == "50")
                {
                    string moduletype = Request.QueryString["moduletype"];
                    string project = Request.QueryString["project"];
                    string status = Request.QueryString["status"];
                    string fromdate = Request.QueryString["fromdate"];
                    string todate = Request.QueryString["todate"];
                    sql = $@"exec ICC_Report_Item_Stock '{moduletype}', '{status}', '{project}', '{fromdate}', '{todate}'";
                    rpturl = "Item_Stock_Report.rdlc";
                    displayname = "Item Trasaction Report";
                }

                Page.Title = displayname;

                ReportDataSource source = null;
                source = new ReportDataSource("DataSet1", gettbl(sql));
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/" + rpturl);

                //For load Image 
                ReportViewer1.LocalReport.EnableExternalImages = true;

                // ReportViewer1.ShowToolBar = true;
                ReportViewer1.ShowPrintButton = true;

                ReportViewer1.LocalReport.DisplayName = displayname;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex) { }
        }
        public DataTable gettbl(string sqltext)
        {
            table = new DataTable();
            try
            {
                SqlDataAdapter dap = new SqlDataAdapter(sqltext, ConfigurationManager.AppSettings["sql"]);
                dap.SelectCommand.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["contimeout"]);
                dap.Fill(table);
            }
            catch (Exception ex) { }
            return table;
        }
    }
}