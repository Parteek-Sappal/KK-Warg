<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true"
    CodeFile="faculty.aspx.cs" Inherits="faculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .cevents
        {
            display: none;
        }
    </style>
  
    <section class="faculty-top top-section">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                  
                  <ul class="filter-abc wow fadeInUp" data-wow-delay=".5s">
                   <asp:Repeater ID="repftype" runat="server" OnItemDataBound="repftype_OnItemDataBound" OnItemCommand="repftype_ItemCommand" >
                        <ItemTemplate>
                       <li runat="server" id="liclass">
                            <asp:LinkButton ID="lnkfid" CommandName="cmdfid" CommandArgument='<%#Eval("fid")%>'
                                runat="server"><%#Eval("facultytype")%></asp:LinkButton>
                        </li>
                            <asp:Literal ID="lifid" runat="server" Visible="false" Text='<%#Eval("fid")%>'></asp:Literal>
                            
                        </ItemTemplate>
                        </asp:Repeater>
                  </ul>
                        <ul class="filter-abc wow fadeInUp" data-wow-delay=".5s">
                         



                        <asp:Repeater ID="rptalpha" runat="server" OnItemDataBound="rptalpha_OnItemDataBound" OnItemCommand="rptalpha_ItemCommand">
                        <ItemTemplate>
                       <li runat="server" id="liclass">
                            <asp:LinkButton ID="lnkalpha" CommandName="cmdalpha" CommandArgument='<%#Eval("alpha")%>'
                                runat="server"><%#Eval("alpha")%></asp:LinkButton>
                        </li>
                            <asp:Literal ID="litalpha" runat="server" Visible="false" Text='<%#Eval("alpha")%>'></asp:Literal>
                          
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
                              <asp:Literal ID="litfname" runat="server" Text='<%#Eval("fname")%>' Visible="false"></asp:Literal>
                                <div class="col-lg-4 col-md-6 cevents">
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

                               <div class="col-12" id="divloadcurrent" runat="server" visible="false">
                                    <button type="button" class="btn btn-link view-more" id="loadMorecurrentevents">View More <span
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderbot2" runat="Server">
<script>

    $(document).ready(function () {
        $(".cevents").slice(0, 12).show();
        $("#loadMorecurrentevents").on("click", function (e) {
            e.preventDefault();
            $(".cevents:hidden").slice(0, 12).slideDown();
            if ($(".cevents:hidden").length == 0) {
                $("#loadMorecurrentevents").text("").addClass("noContent");
            }
        });
    })
    </script>
</asp:Content>
