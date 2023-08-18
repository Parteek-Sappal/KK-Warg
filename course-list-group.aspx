<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="course-list-group.aspx.cs" Inherits="course_list_group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-------------------courses top start---------------->
<%--    <section class="inner-title">
        <div class="container">
            <div class="section-heading text-center">
                <h1 class="section-title">Courses Offered</h1>
            </div>
        </div>
    </section>--%>
    <section class="courses_offered_top_sec top-section">
        <div class="container">
            <asp:Repeater ID="rptcoursecms" runat="server">
            <ItemTemplate>
                <blockquote><%#Eval("smalldesc")%></blockquote>
                <figure>
                    <img src="/uploads/banner/<%#Eval("uploadbanner") %>" class="img-fluid" alt="course-list-bnr">
                </figure>
            </ItemTemplate>
            </asp:Repeater>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="course-select-panel">
                <div class="row gy-4 gy-lg-0">
                    <div class="col-md-6 ">
                         <asp:DropDownList ID="dpid" class="form-select" runat="server" OnSelectedIndexChanged="dpid_OnSelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <asp:DropDownList ID="courselevel_master" class="form-select" runat="server" OnSelectedIndexChanged="courselevel_master_OnSelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="divcoursetitle" runat="server" class="courses_listing_title">
                <div class="row">
                    <div class="col-lg-6 d-none d-lg-flex">
                        <h2>Courses</h2>
                    </div>
                    <div class="col-lg-6 d-none d-lg-flex">
                        <h2>Colleges</h2>
                    </div>
                    <div class="col-12 d-lg-none">
                        <h2>Courses &amp; Colleges</h2>
                    </div>
                </div>
            </div>
            <div class="course_listing">
            <asp:Repeater ID="rptcourse" runat="server" OnItemDataBound="rptcourse_OnItemDataBound">
            <ItemTemplate>
            <asp:Literal ID="litcourseid" runat="server" Text='<%#Eval("courseid") %>' Visible="false"></asp:Literal>
                <div class="course-offered">
                    <div class="row gx-0">
                        <div class="col-lg-6">
                            <div class="course_name">
                            <a id="ank" runat="server">
                                <h3><%#Eval("coursename") %></h3>
                              <p id="pduration" runat="server" visible="false"><strong>Duration </strong><span> <%#Eval("noofsemestor")%> Years<span></p>
                                    <p id="pstream" runat="server" visible="false"><strong>Stream </strong> <span><%#Eval("dpname")%><span></p>
                            </a>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="course_content">
                                <div class="row gx-0">
                                <asp:Repeater ID="rptcollege" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-6">
                                        <div class="college-list">
                                            <p><%#Eval("collagename") %></p>
                                            <a href="javascript:void();">Enquire Now</a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            </asp:Repeater>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>

