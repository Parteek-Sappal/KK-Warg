<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="course.aspx.cs" Inherits="engineering_course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel runat="server">
    <ContentTemplate>
    <section class="courses_offered_top_sec top-section">
        <div class="container">
           <asp:Literal ID="litsmalldesc" runat="server"></asp:Literal>
            <figure>
                <img src="images/course-list-bnr.jpg" class="img-fluid" alt="course-list-bnr">
            </figure>
            <div class="course-select-panel" id="course-select-panel">
                <div class="row gy-4 gy-lg-0">
                    <div class="col-md-6 ">              
                        <asp:DropDownList ID="ddlstream" runat="server" class="form-select" aria-label="Default select example" OnSelectedIndexChanged="ddlstreamsearch" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                         <asp:DropDownList ID="ddllevel" runat="server" class="form-select" aria-label="Default select example" OnSelectedIndexChanged="ddllevelsearch" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="course_listing">
             <asp:Repeater ID="rptcourse" runat="server" OnItemDataBound="rptcourse_ItemDataBound">
             <ItemTemplate>
             <asp:Literal ID="litcourseid" runat="server" Visible="false" Text='<%#Eval("courseid")%>'></asp:Literal>
             <div class="course-offered">
                    <div class="row gx-0">
                        <div class="col-lg-12">
                            <div class="course_name">
                                <div class="text">
                                    <h3><%#Eval("coursename")%></h3>
                                    <p id="pduration" runat="server" visible="false"><strong>Duration </strong><span> <%#Eval("noofsemestor")%> Years<span></p>
                                    <p id="pstream" runat="server" visible="false"><strong>Stream </strong> <span><%#Eval("dpname")%><span></p>
                                </div>
                                <a id="ank" runat="server">Enquire Now</a>
                            </div>
                        </div>
                    </div>
                </div>
             </ItemTemplate>
             </asp:Repeater>
           </div>
        </div>
    </section>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

