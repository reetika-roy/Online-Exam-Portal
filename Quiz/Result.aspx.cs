using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Result"].ToString() == "Pass")
            {
                congratulations.Visible = true;
            }
            else
            {
                fail.Visible = true;
            }
        }
    }
}