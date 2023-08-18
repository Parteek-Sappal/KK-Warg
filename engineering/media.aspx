<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="media.aspx.cs" Inherits="engineering_media" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="gallery">
            <div class="container">
                <ul class="nav nav-tabs">
                    <asp:Repeater ID="rptmediatype" runat="server" OnItemDataBound="rptmediatype_ItemDataBound">
                    <ItemTemplate>
                    <asp:Literal id="littypeid" runat="server"  Visible="false" Text='<%#Eval("typeid")%>'></asp:Literal>
                    <li class="nav-item"><a id="ank" runat="server" href="javascript:void(0)"><span><%#Eval("typename")%></span></a></li>
                    </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="gallery-list">
                    <div class="row gy-5 gx-3">
                      <asp:Repeater ID="rptalbum" runat="server" OnItemDataBound="rptalbum_ItemDataBound">
                      <ItemTemplate>
                      <asp:Literal id="littypeid" runat="server"  Visible="false" Text='<%#Eval("typeid")%>'></asp:Literal>
                      <asp:Literal id="litalbumid" runat="server"  Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                        <div class="col-lg-4 col-sm-6">
                            <a id="ank" runat="server">
                                <figure>
                                    <img class="img-fluid" src="/Uploads/LargeImages/<%#Eval("uploadaimage")%>" alt="Gallery image">
                                    <figcaption>
                                        <div class="icon">
                                            <img id="img" runat="server" src="/images/icon-feather-image.png" alt="image icon">
                                        </div>
                                        <span><asp:Label ID="lblcount" runat="server"></asp:Label></span>
                                    </figcaption>
                                </figure>
                                <div class="text">
                                    <span class="collection-title"><%#Eval("albumtitle")%></span>
                                </div>
                            </a>
                        </div>
                      </ItemTemplate>
                      </asp:Repeater>
                        <div class="col-12" id="panelloadmore" runat="server" visible="false">
                            <button type="button" class="btn btn-link view-more">View More <span class="btn btn-circle btn-prime"><img class="img-fluid" src="./images/right-angle-white.svg"></span></button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>

