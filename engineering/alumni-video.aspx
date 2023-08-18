<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master"
    AutoEventWireup="true" CodeFile="alumni-video.aspx.cs" Inherits="alumni_video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
            <div class="container">
                <div class="distinguished_faculty_video">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row gy-5 gx-xl-5">
                            <asp:Repeater ID="rptalumni" runat="server">
                            <ItemTemplate>
                            <asp:Literal ID="litalbumid" runat="server" Text='<%#Eval("albumid")%>' Visible="false"></asp:Literal>
                            <asp:Literal ID="litvedioid" runat="server" Text='<%#Eval("vedioid")%>' Visible="false"></asp:Literal>
                            <div class="col-lg-4 col-md-6">
                                    <a href="javascript:void(0);" data-video="<%#Eval("uploadvedio")%>" class="faculties_box single-video">
                                        <figure class="faculties_img">
                                            <img src="/uploads/vedio/<%#Eval("thumbnailimage")%>" class="img-fluid w-100"
                                                alt="rizwan-khan">
                                        </figure>
                                        <div class="faculties_cont">
                                            <span><%#Eval("vediotitle")%></span>
                                            <p><%#Eval("tagline")%></p>
                                        </div>
                                    </a>
                                </div>
                            </ItemTemplate>
                            </asp:Repeater>                               
                                                         <div id="load" class="load-more">
                                    <button type="button" class="btn btn-link view-more">View More <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </section>
    <div class="modal fade" id="video-modal">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="btn-close" data-bs-dismiss="modal">
                    </button>
                </div>
                <div class="modal-body">
                    <iframe width="100%" src="" title="Sushant Padmanabhi - IT Engineering (Convocation Ceremony 2020)"
                        frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                        allowfullscreen></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
