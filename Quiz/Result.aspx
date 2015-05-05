<%@ Page Title="" Language="C#" MasterPageFile="~/QuizMaster.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Quiz.Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                	<div class="header">
                    	<p>Welcome <span id="name">Guest</span></p>
                    </div>
                    <div class="question_block" id="congratulations" visible="false" runat="server">
                    	<div class="congrats_block">
                        <div class="left_border">
                        </div>
                        
                        	<div class="middle_border">
                        		<div class="hori_border"></div>
                                <div class="congratulations">
                                    &nbsp;	
                                </div>
                               	<div class="text_block">
                                    <div class="text">
                                        <p class="con_text">This is to certify that</p>
                                            <p class="name"></p>
                                        <p class="con_text">has succesfully anwered the quiz.</p>
                                    </div>
                            	</div>
                                
                            </div>
                             
                        <div class="right_border">
                        </div>
                        
                        <div class="clear"></div>
                         <div class="hori_border_bottom"></div>   
                        </div>	
                            
                    </div>

                    <div class="question_block" visible="false" id="fail" runat="server">
                    	<div class="congrats_block">
                        <div class="left_border">
                        </div>
                        
                        	<div class="middle_border">
                        		<div class="hori_border"></div>
                                <div class="fail">
                                    &nbsp;	
                                </div>
                               	<div class="text_block">
                                    <div class="text">
                                        <p class="con_text">This is to certify that</p>
                                            <p class="name">Abhinandan Patra</p>
                                        <p class="con_text">has succesfully anwered the quiz.</p>
                                    </div>
                            	</div>
                                
                            </div>
                             
                        <div class="right_border">
                        </div>
                        
                        <div class="clear"></div>
                         <div class="hori_border_bottom"></div>   
                        </div>	
                            
                    </div>
</asp:Content>
