using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Quiz
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateQuizDetails(1);
        }

        protected void btnStartQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("Question.aspx?QuizID={0}",1));
        }

        protected void PopulateQuizDetails(int Quiz_Id)
        {
            BLL objQuiz = new BLL();
            DataTable dtquiz= objQuiz.GetQuizDetails(Quiz_Id);
            if (dtquiz != null && dtquiz.Rows.Count > 0)
            {
                Quiztitle.InnerText = dtquiz.Rows[0]["Quiz_Title"].ToString();
                welcomequiz.InnerText = dtquiz.Rows[0]["Quiz_Title"].ToString();
                txtdesc.InnerText = dtquiz.Rows[0]["Quiz_Desc"].ToString();
            }
        }
    }
}