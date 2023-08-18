<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="careers.aspx.cs" Inherits="careers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:Repeater ID="rptsmalldesc" runat="server">
    <ItemTemplate>
            <%#Server.HtmlDecode(Eval("smalldesc").ToString())%>
            <%#Server.HtmlDecode(Eval("pagedescription").ToString())%>

        </ItemTemplate>
        </asp:Repeater>
        
        <section class="current-openings bg-prime-dark">
            <div class="container">


                <div class="section-heading text-center">
                    <h3 class="section-title">Current Openings</h3>
                </div>

                <div class="row gx-xl-5 gy-4">
                    
                    <asp:Repeater ID="rptjob" runat="server">
                    <ItemTemplate>
                    
                        <div class="col-lg-4 col-sm-6">
                            <div class="opening-thumb h-100">
                                <div class="opening-content">
                                    <span class="job-title"><%#Eval("jobtitle") %></span>
                                    <div class="d-grid">
                                        <span class="heading">Experience</span>
                                        <span class=""><%#Eval("min_expyear")%> - <%#Eval("max_expyear")%> years</span>
                                        <span class="heading">Department</span>
                                        <span class=""><%#Eval("department") %></span>
                                    </div>
                                </div>
                                <a href="" class="apply-now">Apply Now</a>
                            </div>
                        </div> 
                    
                    </ItemTemplate>
                    </asp:Repeater>
                    
                </div>
            </div>
        </section>
</asp:Content>

