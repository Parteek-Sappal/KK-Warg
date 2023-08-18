<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="faculty.aspx.cs" Inherits="faculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="faculty-top top-section">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <ul class="filter-abc wow fadeInUp" data-wow-delay=".5s">
                          <asp:Repeater ID="rptalpha" runat="server" OnItemDataBound="rptalpha_OnItemDataBound" OnItemCommand="rptalpha_ItemCommand">
                        <ItemTemplate>
                       <li runat="server" id="liclass">
                            <asp:LinkButton ID="lnkalpha" CommandName="cmdalpha" CommandArgument='<%#Eval("alpha")%>'
                                runat="server"><%#Eval("alpha")%></asp:LinkButton>
                        </li>
                        <asp:Literal ID="litalpha" runat="server" Visible="false" Text='<%#Eval("alpha")%>'></asp:Literal>
                            </li>
                        </ItemTemplate>
                        </asp:Repeater>
                        </ul>
                    </div>
                </div>

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
                                            <p><%#Eval("fdesignation")%></p>
                                            <abbr><%#Eval("qualification")%></abbr>
                                        </div>
                                    </a>
                                </div>
                              </ItemTemplate>
                              </asp:Repeater>
                              
                              
                                <div class="col-12">
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

