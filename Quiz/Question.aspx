<%@ Page Title="" Language="C#" MasterPageFile="~/QuizMaster.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="Quiz.Question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="header">
                    	<p>Welcome <span id="name">Guest</span></p>
                    </div>
                    <div class="question_block">
                    	<p class="question"><span class="questionNo" id="qNo" runat="server"></span><span class="question" id="qtitle" runat="server"></span></p>
                        <br />
                        <p><span class="questionNo" id="QDesc" runat="server"></span></p>
                        <br />
                        	<div class="options">
                            	       	
                                    	<asp:RadioButtonList ID="SCQ" runat="server" />
                                        <asp:CheckBoxList ID="MCQ" runat="server" />
                                        <asp:RadioButtonList ID="TF" runat="server" />
                            </div>
                            <div class="button_below">
                            	 <asp:Button ID="btnPrev" CssClass="prev" Visible="false" border="0" runat="server" 
                                     onclick="btnPrev_Click" />
                                 <asp:Button ID="btnNext" CssClass="next"  border="0" runat="server" 
                                     onclick="btnNext_Click" />
                                 <asp:Button ID="btnFinish" CssClass="finish" Visible="false" border="0" 
                                     runat="server" onclick="btnFinish_Click" />
                            </div>
                    </div>
</asp:Content>
