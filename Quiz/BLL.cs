using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Quiz
{
    public class BLL
    {
        public DataTable GetQuizDetails(int Quiz_Id)
        {
            DLL objdatacon = new DLL();
            string query = "select * from Quiz  where Quiz_Id=" + Quiz_Id + "";
            return objdatacon.Getdataset(query).Tables[0];

        }

        public DataTable GetQuizQuestionList(int Quiz_Id)
        {
            DLL objdatacon = new DLL();
            string query = "select Question_Id from Quiz_Question_Bank where Quiz_Id=" + Quiz_Id + "";
            return objdatacon.Getdataset(query).Tables[0];
        }

        public DataTable GetQuestionDetails(int Question_ID)
        {
            DLL objdatacon = new DLL();
            string query = "select * from Question_Bank where Question_ID=" + Question_ID + "";
            return objdatacon.Getdataset(query).Tables[0];

        }

        public DataTable GetOptionDetails(int Question_ID)
        {
            DLL objdatacon = new DLL();
            string query = "select * from Question_Option where Question_ID=" + Question_ID + "";
            return objdatacon.Getdataset(query).Tables[0];

        }

        public DataTable GetScoreDetails(int Quiz_Id)
        {
            DLL objdatacon = new DLL();
            string query = "SELECT Question_Type, A.Question_Id, Question_Score, Question_Ans FROM Quiz_Question_Bank A, Question_Bank B WHERE A.Question_Id=B.Question_ID AND A.Quiz_Id=" + Quiz_Id + "";
            return objdatacon.Getdataset(query).Tables[0];

        }


    }
}