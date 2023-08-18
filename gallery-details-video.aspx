<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="gallery-details-video.aspx.cs" Inherits="gallery_details_video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section class="inner-title">
            <div class="container">
                <div class="section-heading text-center">
                    <h1 class="collection-title"><asp:Literal ID="litalbumtitle" runat="server"></asp:Literal></h1>
                </div>
            </div>
        </section>
        <section class="gallery top-section">
            <div class="container">
                <blockquote class="lead text-center"><asp:Literal ID="litalbumdesc" runat="server"></asp:Literal></blockquote>
                <div class="gallery-detail">
                    <div class="row gy-3 gx-3">

                    <asp:Repeater ID="rptvideo" runat="server" OnItemDataBound="rptvideo_OnItemDataBound">
                    <ItemTemplate>
                    <asp:Literal ID="litvedioid" runat="server" Text='<%#Eval("vedioid") %>' Visible="false"></asp:Literal>
                    <asp:Literal ID="lituploadvedio" runat="server" Text='<%#Eval("uploadvedio") %>' Visible="false"></asp:Literal>
                        <div class="col-lg-4 col-sm-6">
                            <div data-videosrc="<%#Eval("uploadvedio") %>" data-title='<%#Eval("vediotitle") %>' class="wow fadeInUp animated gallery-thumb full-height video">
                                <a id="ank" runat="server">
                                    <figure class="mb-0">
                                        <img class="img-fluid" src="/uploads/vedio/<%#Eval("thumbnailimage") %>" alt="Gallery image">
                                        <figcaption>
                                            <div class="icon">
                                                <img class="img-fluid" src="./images/video-icon-red.svg" />
                                            </div>
                                        </figcaption>
                                    </figure>
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>

                    </div>
                </div>
            </div>
        </section>

    <div class="modal" id="video-modal">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Video Title</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe class="embed-responsive-item" src="" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>

