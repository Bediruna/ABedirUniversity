using ABedirUniversity.CSharp;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABedirUniversity.WebForms.AdminForms
{
    public partial class StudentApplicationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/WebForms/AdminLogin.aspx");
            }
            else
            {
                ApplicationsGridView.DataSource = SQLDataAccess.GetStudentApplications();
                ApplicationsGridView.DataBind();
                Session["TaskTable"] = ApplicationsGridView;
            }
        }
        protected void ApplicationsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "location.href = 'StudentApplicationDetailView.aspx?applicationid=" + e.Row.Cells[0].Text + "';";
                e.Row.ToolTip = "Click to view details";
            }
        }

        protected void ApplicationsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = Session["TaskTable"] as DataTable;

            if (dt != null)
            {
                string sortColumn = e.SortExpression;
                string sortDirection = GetSortDirection(e.SortExpression);
                string sortExpression = sortColumn + " " + sortDirection;
                Session["SortExpression"] = sortExpression;
                dt.DefaultView.Sort = sortExpression;


                ApplicationsGridView.DataSource = Session["TaskTable"];
                ApplicationsGridView.DataBind();
            }
        }
        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";

            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if (lastDirection != null && lastDirection == "ASC")
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            ApplicationsGridView.DataSource = SQLDataAccess.SearchApplicationsByName(InputSearch.Value);
            ApplicationsGridView.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void ExportBtn_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename=StudentApplications.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            ApplicationsGridView.AllowPaging = false;
            ApplicationsGridView.DataBind();

            ApplicationsGridView.HeaderRow.Style.Add("background-color", "#ffffff");

            ApplicationsGridView.HeaderRow.Cells[0].Style.Add("background-color", "#e4e4e4");
            ApplicationsGridView.HeaderRow.Cells[1].Style.Add("background-color", "#e4e4e4");
            ApplicationsGridView.HeaderRow.Cells[2].Style.Add("background-color", "#e4e4e4");
            ApplicationsGridView.HeaderRow.Cells[3].Style.Add("background-color", "#e4e4e4");
            ApplicationsGridView.HeaderRow.Cells[4].Style.Add("background-color", "#e4e4e4");

            ApplicationsGridView.HeaderRow.Cells[0].Text = "ID";
            ApplicationsGridView.HeaderRow.Cells[1].Text = "Application Status";
            ApplicationsGridView.HeaderRow.Cells[2].Text = "First Name";
            ApplicationsGridView.HeaderRow.Cells[3].Text = "Last Name";
            ApplicationsGridView.HeaderRow.Cells[4].Text = "User Create Date";

            ApplicationsGridView.RenderControl(hw);

            string style = @"<style> .textmode { mso-number-format:\@; } </style>";

            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        //protected void ResetBtn_Click(object sender, EventArgs e)
        //{
        //    ApplicationsGridView.DataSource = SQLDataAccess.GetStudentApplications();
        //    ApplicationsGridView.DataBind();
        //}
    }
}