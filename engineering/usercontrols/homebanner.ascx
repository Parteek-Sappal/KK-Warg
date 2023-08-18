<%@ Control Language="C#" AutoEventWireup="true" CodeFile="homebanner.ascx.cs" Inherits="engineering_usercontrols_homebanner" %>
        <section class="py-0">
            <div class="swiper home-banner-slider">
                <div class="swiper-wrapper">
                <asp:Repeater ID="rptbanner" runat="server">
                <ItemTemplate>
                <asp:Literal ID="litbid" runat="server" Visible="false" Text='<%#Eval("bid")%>'></asp:Literal>
                <div class="swiper-slide">
                    <div class="slide-item">
                        <figure>
                            <img class="img-fluid" src="/uploads/banner/<%#Eval("bannerimage")%>">
                        </figure>
                        <div class="slide-content">
                            <div class="container">
                                <%#Server.HtmlDecode(Eval("tagline1").ToString())%>
                            </div>
                        </div>
                    </div>
                </div>
                </ItemTemplate>
                </asp:Repeater>
                </div>
                <div class="swiper-pagination home-banner-pagination"></div>
            </div>
        </section>