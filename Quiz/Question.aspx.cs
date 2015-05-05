using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Quiz
{
    public partial class Question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL objquestionlist = new BLL();
                DataTable dtquestion = objquestionlist.GetQuizQuestionList(Convert.ToInt32(Request.QueryString["QuizID"].ToString()));
                Session["QuizQuestionList"] = dtquestion;
                Session["CurrentQuestionIndex"] = "0";
                if (dtquestion != null && dtquestion.Rows.Count > 0)
                {
                    DataTable dtQuestionDetails = objquestionlist.GetQuestionDetails(Convert.ToInt32(dtquestion.Rows[0][0].ToString()));
                    if (dtQuestionDetails != null && dtQuestionDetails.Rows.Count > 0)
                    {
                        qNo.InnerText = "1";
                        qtitle.InnerText = dtQuestionDetails.Rows[0]["Question_Title"].ToString();
                        QDesc.InnerText = dtQuestionDetails.Rows[0]["Question_Desc"].ToString();
                        DataTable dtoption = objquestionlist.GetOptionDetails(Convert.ToInt32(dtQuestionDetails.Rows[0]["Question_Id"].ToString()));
                        if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "MCQ")
                        {
                            MCQ.DataSource = dtoption;
                            MCQ.DataTextField = "Question_Option";
                            MCQ.DataValueField = "Question_Option";
                            MCQ.DataBind();

                        }
                        else if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "TF")
                        {
                            TF.DataSource = dtoption;
                            TF.DataTextField = "Question_Option";
                            TF.DataValueField = "Question_Option";
                            TF.DataBind();

                        }
                        else
                        {
                            SCQ.DataSource = dtoption;
                            SCQ.DataTextField = "Question_Option";
                            SCQ.DataValueField = "Question_Option";
                            SCQ.DataBind();

                        }
                    }
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            GetAnswer(Convert.ToInt32(Session["CurrentQuestionIndex"].ToString()));
            PopulateQuestionDetails(Convert.ToInt32(Session["CurrentQuestionIndex"].ToString()) + 1);
            DataTable dtquestion =(DataTable) Session["QuizQuestionList"];
            if (Convert.ToInt32(Session["CurrentQuestionIndex"].ToString()) + 1 == dtquestion.Rows.Count)
            {
                btnNext.Visible = false;
                btnPrev.Visible = true;
                btnFinish.Visible = true;
            }
            else
            {
                btnPrev.Visible = true;
                btnFinish.Visible = false;
                btnNext.Visible = true;
            }
        }

        protected void PopulateQuestionDetails(int CurrentQuestionIndex)
        {
            BLL objquestionlist = new BLL();
            DataTable dtquestion =(DataTable) Session["QuizQuestionList"];
            DataTable dtAnswer;
            Session["CurrentQuestionIndex"] = CurrentQuestionIndex;
                       if (dtquestion != null && dtquestion.Rows.Count > 0)
            {
                DataTable dtQuestionDetails = objquestionlist.GetQuestionDetails(Convert.ToInt32(dtquestion.Rows[CurrentQuestionIndex][0].ToString()));
                if (dtQuestionDetails != null && dtQuestionDetails.Rows.Count > 0)
                {
                    qNo.InnerText = Convert.ToString(CurrentQuestionIndex + 1);
                    qtitle.InnerText = dtQuestionDetails.Rows[0]["Question_Title"].ToString();
                    QDesc.InnerText = dtQuestionDetails.Rows[0]["Question_Desc"].ToString();
                    DataTable dtoption = objquestionlist.GetOptionDetails(Convert.ToInt32(dtQuestionDetails.Rows[0]["Question_Id"].ToString()));
                    if (Session["dtAnswer"] != null)
                    {
                        dtAnswer = (DataTable)Session["dtAnswer"];
                        DataTable AnsExsit = dtAnswer.AsEnumerable().Where(o => o.Field<string>("QID") == dtQuestionDetails.Rows[0]["Question_Id"].ToString()).AsDataView().ToTable();
                        if (AnsExsit != null && AnsExsit.Rows.Count > 0)
                        {
                            if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "MCQ")
                            {
                                string[] MCQAns = AnsExsit.Rows[0]["AnsOption"].ToString().Split(',');
                                MCQ.Visible = true;
                                MCQ.DataSource = dtoption;
                                MCQ.DataTextField = "Question_Option";
                                MCQ.DataValueField = "Question_Option";
                                MCQ.DataBind();
                                for (int i = 0; i < MCQ.Items.Count; i++)
                                {
                                    foreach (string ans in MCQAns)
                                    {
                                        if (ans != "")
                                        {
                                            if (i == Convert.ToInt32(ans) - 1)
                                            {
                                                MCQ.Items[i].Selected = true;
                                                // MCQAns = MCQAns + "," + Convert.ToString(i + 1);
                                            }
                                        }
                                    }
                                }
                                TF.Visible = false;
                                SCQ.Visible = false;

                            }
                            else if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "TF")
                            {
                                TF.Visible = true;
                                TF.DataSource = dtoption;
                                TF.DataTextField = "Question_Option";
                                TF.DataValueField = "Question_Option";
                                TF.DataBind();
                              //  TF.SelectedItem.Text = AnsExsit.Rows[0]["AnsOption"].ToString();
                                TF.Items.FindByText(AnsExsit.Rows[0]["AnsOption"].ToString().Trim()).Selected = true; 
                                MCQ.Visible = false;
                                SCQ.Visible = false;

                            }
                            else
                            {
                                SCQ.Visible = true;
                                SCQ.DataSource = dtoption;
                                SCQ.DataTextField = "Question_Option";
                                SCQ.DataValueField = "Question_Option";
                                SCQ.DataBind();
                                SCQ.SelectedIndex = Convert.ToInt32(AnsExsit.Rows[0]["AnsOption"].ToString()) - 1;
                                MCQ.Visible = false;
                                TF.Visible = false;

                            }
                        }
                        else
                        {
                            if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "MCQ")
                            {
                                MCQ.Visible = true;
                                MCQ.DataSource = dtoption;
                                MCQ.DataTextField = "Question_Option";
                                MCQ.DataValueField = "Question_Option";
                                MCQ.DataBind();
                                TF.Visible = false;
                                SCQ.Visible = false;

                            }
                            else if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "TF")
                            {
                                TF.Visible = true;
                                TF.DataSource = dtoption;
                                TF.DataTextField = "Question_Option";
                                TF.DataValueField = "Question_Option";
                                TF.DataBind();
                                MCQ.Visible = false;
                                SCQ.Visible = false;

                            }
                            else
                            {
                                SCQ.Visible = true;
                                SCQ.DataSource = dtoption;
                                SCQ.DataTextField = "Question_Option";
                                SCQ.DataValueField = "Question_Option";
                                SCQ.DataBind();
                                MCQ.Visible = false;
                                TF.Visible = false;

                            }
                        }
                    }
                    else
                    {

                        if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "MCQ")
                        {
                            MCQ.Visible = true;
                            MCQ.DataSource = dtoption;
                            MCQ.DataTextField = "Question_Option";
                            MCQ.DataValueField = "Question_Option";
                            MCQ.DataBind();
                            TF.Visible = false;
                            SCQ.Visible = false;

                        }
                        else if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "TF")
                        {
                            TF.Visible = true;
                            TF.DataSource = dtoption;
                            TF.DataTextField = "Question_Option";
                            TF.DataValueField = "Question_Option";
                            TF.DataBind();
                            MCQ.Visible = false;
                            SCQ.Visible = false;

                        }
                        else
                        {
                            SCQ.Visible = true;
                            SCQ.DataSource = dtoption;
                            SCQ.DataTextField = "Question_Option";
                            SCQ.DataValueField = "Question_Option";
                            SCQ.DataBind();
                            MCQ.Visible = false;
                            TF.Visible = false;

                        }
                    }
                }
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            GetAnswer(Convert.ToInt32(Session["CurrentQuestionIndex"].ToString()));
            PopulateQuestionDetails(Convert.ToInt32(Session["CurrentQuestionIndex"].ToString()) - 1);
            if (Convert.ToInt32(Session["CurrentQuestionIndex"].ToString()) == 0)
            {
                btnPrev.Visible = false;
                btnNext.Visible = true;

            }
            else
            {
                btnPrev.Visible = true;
                btnNext.Visible = true;
                btnFinish.Visible = false;
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            BLL objquestionlist = new BLL();
            DataTable dtQuiz = objquestionlist.GetQuizDetails(Convert.ToInt32(Request.QueryString["QuizID"].ToString()));
            int TotalScore = CalScore();
            if (TotalScore >= Convert.ToInt32(dtQuiz.Rows[0]["Quiz_Pass_Marks"].ToString()))
            {
                Response.Redirect(string.Format("Result.aspx?Result={0}","Pass"));
            }
            else
            {
                Response.Redirect(string.Format("Result.aspx?Result={0}","Fail"));
            }
            
        }

        protected void GetAnswer(int QuestionIndex)
        {
            BLL objquestionlist = new BLL();
            DataTable dtAnswer;
            DataTable dtquestion = (DataTable)Session["QuizQuestionList"];
            if (Session["dtAnswer"] != null)
            {
                dtAnswer = (DataTable)Session["dtAnswer"];
            }
            else
            {
                dtAnswer = new DataTable();
                dtAnswer.Columns.Add("QID");
                dtAnswer.Columns.Add("AnsOption");
            }
            
            
            DataTable dtQuestionDetails = objquestionlist.GetQuestionDetails(Convert.ToInt32(dtquestion.Rows[QuestionIndex][0].ToString()));
            DataRow ansrow = dtAnswer.NewRow();
            
            DataTable AnsExsit = dtAnswer.AsEnumerable().Where(o => o.Field<string>("QID") == dtQuestionDetails.Rows[0]["Question_Id"].ToString()).AsDataView().ToTable();
            string MCQAns = "";
            if (AnsExsit != null && AnsExsit.Rows.Count > 0)
            {
                

                if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "MCQ")
                {
                    for (int i = 0; i < MCQ.Items.Count; i++)
                    {
                        if (MCQ.Items[i].Selected)
                        {
                            MCQAns = MCQAns + "," + Convert.ToString(i + 1);
                        }
                    }
                    DataRow[] AnsRow = dtAnswer.Select(string.Format("QID = '{0}'", dtQuestionDetails.Rows[0]["Question_Id"].ToString()));

                    AnsRow[0]["AnsOption"] = MCQAns;
                    
                   
                }
                else if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "TF")
                {
                    DataRow[] AnsRow = dtAnswer.Select(string.Format("QID = '{0}'", dtQuestionDetails.Rows[0]["Question_Id"].ToString()));
                    AnsRow[0]["AnsOption"] = TF.SelectedItem.Text;

                }
                else
                {
                    DataRow[] AnsRow = dtAnswer.Select(string.Format("QID = '{0}'", dtQuestionDetails.Rows[0]["Question_Id"].ToString()));
                    AnsRow[0]["AnsOption"] = SCQ.SelectedIndex + 1;

                }
            }
            else
            {
                ansrow["QID"] = dtQuestionDetails.Rows[0]["Question_Id"].ToString();

                if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "MCQ")
                {
                    for (int i = 0; i < MCQ.Items.Count; i++)
                    {
                        if (MCQ.Items[i].Selected)
                        {
                            MCQAns = MCQAns + "," + Convert.ToString(i + 1);
                        }
                    }

                    ansrow["AnsOption"] = MCQAns;
                }
                else if (dtQuestionDetails.Rows[0]["Question_Type"].ToString() == "TF")
                {
                    ansrow["AnsOption"] = TF.SelectedItem.Text;

                }
                else
                {
                    ansrow["AnsOption"] = SCQ.SelectedIndex + 1;

                }
                dtAnswer.Rows.Add(ansrow);
                Session["dtAnswer"] = dtAnswer;
            }

        }

        protected int CalScore()
        {
            int scoretotal = 0;
            int flagcheckMCQ = 0;
            int totalAnsOption = 0;
            BLL objquestionlist = new BLL();
            DataTable dtAnswer;
            DataTable dtscore = objquestionlist.GetScoreDetails(Convert.ToInt32(Request.QueryString["QuizID"].ToString()));
            if (Session["dtAnswer"] != null)
            {
                dtAnswer = (DataTable)Session["dtAnswer"];
                foreach (DataRow dr in dtAnswer.Rows)
                {
                    DataRow[] AnsRow = dtscore.Select(string.Format("Question_Id = '{0}'", dr["QID"].ToString()));
                    if (AnsRow[0]["Question_Type"].ToString() == "MCQ")
                    {
                        string[] MCQActualAns = AnsRow[0]["Question_Ans"].ToString().Split(',');
                        string[] MCQGivenAns = dr["AnsOption"].ToString().Split(',');
                        foreach (string Aans in MCQActualAns)
                        {
                            if (Aans != "")
                            {
                                totalAnsOption++;
                                foreach (string Gans in MCQGivenAns)
                                {
                                    if (Gans != "")
                                    {
                                        if (Aans == Gans)
                                        {
                                            flagcheckMCQ++;
                                        }
                                    }
                                }
                            }
                        }

                        if (flagcheckMCQ != 0)
                        {
                            if (flagcheckMCQ == totalAnsOption)
                            {
                                scoretotal = scoretotal + Convert.ToInt32(AnsRow[0]["Question_Score"].ToString());
                            }
                        }

                       
                    }
                    else if (AnsRow[0]["Question_Type"].ToString() == "TF")
                    {
                        if (AnsRow[0]["Question_Ans"].ToString() == dr["AnsOption"].ToString())
                        {
                            scoretotal = scoretotal + Convert.ToInt32(AnsRow[0]["Question_Score"].ToString());
                        }

                    }
                    else
                    {

                        if (AnsRow[0]["Question_Ans"].ToString() == dr["AnsOption"].ToString())
                        {
                            scoretotal = scoretotal + Convert.ToInt32(AnsRow[0]["Question_Score"].ToString());
                        }

                    }
                }
            }
            return scoretotal;
        }
    }
}