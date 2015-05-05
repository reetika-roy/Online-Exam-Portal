<%@ Page Title="" Language="C#" MasterPageFile="~/QuizMaster.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="Quiz.Welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header">
                    	<p>Welcome to <span id="quizName">Online</span> <span id="Quiztitle" runat="server"></span> Quiz</p>
                    </div>
                    <div class="welcome_text">
                    	<p>Welcome <span id="welcomequiz" runat="server"></span></p>
                     </div>
                     <div class="instruction">
                        	<div class="info_div">Information</div>
                            <div class="border">
                            	
                                	<div class="left_div" >
                                    	<p class="red">Description</p>
                                    	
                                        	<p id="txtdesc" runat="server"></p>
                                        
                                    </div>
                                    <div class="right_div">
                                    	<p>Note</p>
                                    	<ul>
                                        	<li>Click the 'Submit Test' button given in the bottom of this page to Submit your answers.</li>
                                            <li>Don't refresh the page.</li>
                                        </ul>
                                    </div>
                                   <div class="clear"></div>
                            </div>
                            <div class="clear"></div>
                            <div class="button">
                                <div class="test">
                                    
                                    <asp:Button ID="btnStartQuiz" CssClass="take_test" runat="server" 
                                        onclick="btnStartQuiz_Click" />
                                </div>
                            </div>
                        </div>
</asp:Content>
