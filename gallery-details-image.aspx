<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="gallery-details-image.aspx.cs" Inherits="gallery_details_image" %>

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

                    <asp:Repeater ID="rptimage" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-sm-6">
                            <a href="/uploads/largeimages/<%#Eval("uploadphoto") %>" data-lightbox="imagegallery" data-title="Collection Title" class="wow fadeInUp animated gallery-thumb full-height image">
                                <figure class="mb-0">
                                    <img class="img-fluid" src="/uploads/largeimages/<%#Eval("uploadphoto") %>" alt="Gallery image">
                                </figure>
                            </a>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>

