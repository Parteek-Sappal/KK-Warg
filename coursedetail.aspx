<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="coursedetail.aspx.cs" Inherits="engineering_coursedetail" %>
<%@ Register Src="~/engineering/usercontrols/breadcrumbs.ascx" TagName="breadcrumbs" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="inner-title inner-title-2">
            <div class="container">
                <div class="section-heading text-center">
                    <h1 class="section-title"> <asp:Literal ID="litcoursename" runat="server"></asp:Literal> </h1>                  
                           <uc1:breadcrumbs ID="breadcrumbs1" runat="server" />
                </div>
                <div class="course-details-header">
                    <div class="row justify-content-center">
                        <div class="col-xl-10">
                            <div class="row">
                                <div class="col-md-7 col-lg-auto" id="panelcollage" runat="server" visible="false">
                                    <div class="course-header_content">
                                        <img src="/images/faculty-icon.svg" class="img-fluid" alt="icon">
                                        <div class="content-inner">
                                            <h5>Institute</h5>
                                             <p><asp:Literal ID="litcollagename" runat="server"></asp:Literal></p>           
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-lg-auto" id="panelstream" runat="server" visible="false">
                                    <div class="course-header_content">
                                        <img src="/images/stream-icon.svg" class="img-fluid" alt="icon">
                                        <div class="content-inner">
                                            <h5>Stream</h5>
                                            <p><span><asp:Literal ID="litstream" runat="server"></asp:Literal></span></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="courses-details_top-sec top-section">
            <div class="container">
              <asp:Literal ID="litoverview" runat="server"></asp:Literal>
               <asp:Literal ID="litelgibilty" runat="server"></asp:Literal>
               <asp:Literal ID="litfees" runat="server"></asp:Literal>                
            </div>
        </section>
      <asp:Literal ID="litSyllabus" runat="server"></asp:Literal> 
     <asp:Literal ID="litpeo" runat="server"></asp:Literal> 
     <asp:Literal ID="litprogram" runat="server"></asp:Literal> 
     <asp:Literal ID="litcareer" runat="server"></asp:Literal>   
</asp:Content>

