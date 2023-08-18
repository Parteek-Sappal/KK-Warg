<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="mediadetail.aspx.cs" Inherits="engineering_mediadetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="gallery top-section">
            <div class="container">
                <blockquote class="lead text-center"> <asp:Label ID="lbltitle" runat="server"></asp:Label> </blockquote>
                <div class="gallery-detail">
                    <div class="row gy-3 gx-3">
                    <asp:Repeater ID="rptalbumdetail" runat="server">
                    <ItemTemplate>
                    <asp:Literal id="litalbumid" runat="server"  Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                        <div class="col-lg-4 col-sm-6">
                            <a href="/Uploads/LargeImages/<%#Eval("uploadphoto")%>" data-lightbox="imagegallery" data-title='<%#Eval("phototitle")%>' class="wow fadeInUp animated gallery-thumb full-height image">
                                <figure class="mb-0">
                                    <img class="img-fluid" src="/Uploads/LargeImages/<%#Eval("uploadphoto")%>" alt="Gallery image">
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

