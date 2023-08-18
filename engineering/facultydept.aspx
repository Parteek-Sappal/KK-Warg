<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/department.master" AutoEventWireup="true" CodeFile="facultydept.aspx.cs" Inherits="engineering_facultydept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="faculty-top top-section">
            <div class="container">
                

                <div class="distinguished_faculty_sec">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row gy-5 gx-xl-5">
                              <asp:Repeater ID="rptfaculty" runat="server" OnItemDataBound="rptfaculty_ItemDataBound">
                              <ItemTemplate>
                              <asp:Literal ID="litfaculityid" runat="server" Text='<%#Eval("facultyid")%>' Visible="false"></asp:Literal>
                              <asp:Literal ID="litfimage" runat="server" Text='<%#Eval("fimage")%>' Visible="false"></asp:Literal>
                                <div class="col-lg-4 col-md-6">
                                    <a id="ank" runat="server" class="faculties_box">
                                        <figure class="faculties_img">
                                            <img id="img" runat="server" class="img-fluid w-100" alt='<%#Eval("fname")%>'>
                                        </figure>
                                        <div class="faculties_cont">
                                            <span><%#Eval("nprefix")%> <%#Eval("fname")%></span>
                                            <p><%#Eval("designationname")%></p>
                                            <abbr><%#Eval("qualification")%></abbr>
                                        </div>
                                    </a>
                                </div>
                              </ItemTemplate>
                              </asp:Repeater>
                              
                              
                                <div class="col-12" id="panelloadmore" runat="server" visible="false">
                                    <button type="button" class="btn btn-link view-more">View More <span
                                            class="btn btn-circle btn-prime"><img class="img-fluid"
                                                src="/images/right-angle-white.svg"></span></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </section>

</asp:Content>

