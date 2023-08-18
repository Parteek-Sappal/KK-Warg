<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="facultydetail.aspx.cs" Inherits="facultydetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="faculty_detail_top">
<asp:Repeater ID="rptfacultydetail" runat="server" OnItemDataBound="rptfacultydetail_ItemDataBound">
<ItemTemplate>
<asp:Literal ID="litfacultyid" runat="server" Text='<%#Eval("facultyid")%>' Visible="false"></asp:Literal>
<asp:Literal ID="litfimage" runat="server" Text='<%#Eval("limage")%>' Visible="false"></asp:Literal>
            <div class="container">      
                <h2><%#Eval("nprefix")%> <%#Eval("fname")%></h2>
                <h3><%#Eval("designationname")%></h3>
            
            <div class="faculty_detail_mid">
                <div class="row">
                    <div class="col-lg-4">
                        <div class="faculty_detail_mid_left">
                            <figure><img id="img" runat="server" class="img-fluid" alt="faculty image"></figure>
                        </div>
                     <%#Server.HtmlDecode(Eval("fdetail").ToString())%>
                    </div>
                    <div class="col-lg-8">
                        <div class="faculty_detail_mid_right">
                            <div class="qualification-area">
                                <p>Qualification</p>
                                <span><%#Eval("qualification")%></span>
                            </div>
                            <%#Server.HtmlDecode(Eval("patents").ToString())%>
                            <%#Server.HtmlDecode(Eval("research_initiatives").ToString())%>
                            <%#Server.HtmlDecode(Eval("industrial_training").ToString())%>
                            <%#Server.HtmlDecode(Eval("books_published").ToString())%>
                            <%#Server.HtmlDecode(Eval("revenue_earned").ToString())%>
                        </div>
                    </div>
                </div>
            </div>
            </div>
</ItemTemplate>
</asp:Repeater>

        </section>
</asp:Content>

