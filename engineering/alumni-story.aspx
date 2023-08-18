<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="alumni-story.aspx.cs" Inherits="engineering_alumni_story" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<section>
            <div class="container">
                <div class="distinguished_faculty_video">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row gy-5 gx-xl-5">
                            <asp:Repeater ID="rptstory" runat="server" OnItemDataBound="rptstory_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid")%>' Visible="false"></asp:Literal>
                              <div class="col-lg-4 col-md-6">
                                    <a id="ank" runat="server" class="faculties_box single-video">
                                        <figure class="faculties_img">
                                            <img src="/uploads/smallimages/<%#Eval("uploadevents")%>" class="img-fluid w-100"
                                                alt="rizwan-khan">
                                        </figure>
                                        <div class="faculties_cont">
                                            <span><%#Eval("eventstitle")%></span>
                                            <p><%#Eval("tagline")%></p>
                                        </div>
                                    </a>
                                </div>              
                            </ItemTemplate>
                            </asp:Repeater>
                                                
                                
                                
                                <div id="load" class="col-12 load-more">
                                    <button type="button" class="btn btn-link view-more">View More <span
                                            class="btn btn-circle btn-prime"><img class="img-fluid"
                                                src="./images/right-angle-white.svg"></span></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </section>
        
</asp:Content>

