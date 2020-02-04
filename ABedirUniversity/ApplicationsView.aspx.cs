using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABedirUniversity
{
    public partial class ApplicationsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationsGridView.DataSource = SqliteDataAccess.LoadApplications();
            ApplicationsGridView.DataBind();

        }
    }
}