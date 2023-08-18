<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="news-details.aspx.cs" Inherits="news_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <section class="happening-details news-details top-section">
        <asp:Repeater ID="rptnewsdetais" runat="server" OnItemDataBound="rptnewsdetais_OnItemDataBound">
        <ItemTemplate>
        <asp:Literal ID="lituploadevents" runat="server" Visible="false" Text='<%#Eval("uploadevents") %>'></asp:Literal>
            <div class="container">
                <div class="happening-heading">
                    <p class="timing"><%#Eval("eventsdate","{0:MMM dd, yyyy}") %></p>
                    <h3 class="happening-title"><%#Eval("eventstitle") %></h3>
                    <blockquote><%#Server.HtmlDecode(Eval("shortdesc").ToString()) %></blockquote>
                    <div class="btns-group">
                        <a href="javascript:void(0)" class="btn btn-circle btn-circle-lg"><img class="img-fluid" src="/images/print-icon.svg" alt="print icon" /></a>
                        <a href="javascript:void(0)" class="btn btn-circle btn-circle-lg"><img class="img-fluid" src="/images/share-icon.svg" alt="share icon" /></a>
                        <a href="javascript:void(0)" class="btn btn-circle btn-circle-lg"><img class="img-fluid" src="/images/pdf-icon.svg" alt="print icon" /></a>
                    </div>
                </div>
            </div>
           
            <div id="divimg" runat="server" visible="false" class="container">
                <div class="container">
                <figure class="happening-banner mb-0">
                    <img src="/uploads/smallimages/<%#Eval("uploadevents") %>" class="img-fluid" alt="unmukt 2022">
                </figure>
                <%#Server.HtmlDecode(Eval("eventsdesc").ToString()) %>
                </div>
            </div>
            
          
        </ItemTemplate>
        </asp:Repeater>
        </section>

         <section class="event-photos bg-prime-dark" id="paneleventsphoto" runat="server" visible="false">
            <div class="container">
                <div class="section-heading text-center">
                    <h3 class="section-title secondary text-white">Event Photos</h3>
                </div>
                <div class="swiper event-photos-slider">
                    <div class="swiper-wrapper">                        
                        <asp:Repeater ID="rptmediaphoto" runat="server">
                        <ItemTemplate>
                        <asp:Literal ID="lituploadevents" runat="server" Text='<%#Eval("photoid") %>' Visible="false"></asp:Literal>
                         <div class="swiper-slide">
                        <div class="slide-item">
                                <figure>
                                    <img class="img-fluid w-100" src="uploads/LargeImages/<%#Eval("uploadphoto") %>">
                                </figure>
                            </div>
                            </div>
                        </ItemTemplate>
                        </asp:Repeater>
                     </div>
                    <div class="swiper-button-next swiper-button-bottom"><img
                            src="/images/right-angle-white.svg" class="img-fluid" alt="right angle"></div>
                    <div class="swiper-button-prev swiper-button-bottom"><img
                            src="/images/left-angle-white.svg" class="img-fluid" alt="right angle"></div>
                </div>
            </div>
        </section>

        <section class="related-news other-news">
            <div class="container">
                <div class="section-heading text-center">
                     <h3 class="section-title secondary">Related News</h3>
                </div>
                
                <div class="row gx-3 gy-4 mt-3">
                <asp:Repeater ID="rptothernews" runat="server" OnItemDataBound="rptothernews_OnItemDataBound" >
                <ItemTemplate>
                <asp:Literal ID="lituploadevents" runat="server" Text='<%#Eval("uploadevents") %>' Visible="false"></asp:Literal>
                <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid") %>' Visible="false"></asp:Literal>                
                    <div id="divwithimage" runat="server" class="col-lg-4 col-md-6" visible="false">
                        <a id="ankwithimage" runat="server" class="happening-thumb with-image">
                            <figure>
                                <img class="img-fluid" src="/uploads/smallimages/<%#Eval("uploadevents") %>" alt="Lorem ipsum dolor sit amet, consectetuer adipiscing elit.">
                            </figure>
                            <div class="happening-content">
                                <span class="timing"><%#Eval("eventsdate", "{0:MMM dd, yyyy}")%></span>
                                <span class="happening-title"><%#Eval("eventstitle") %></span>
                            </div>
                        </a>
                    </div>
                    <div id="divwithoutimage" runat="server" class="col-lg-4 col-md-6" visible="false">
                        <a id="ankwithoutimage" runat="server" class="happening-thumb bg-prime-dark">
                            <div class="happening-content">
                                <span class="timing"><%#Eval("eventsdate", "{0:MMM dd, yyyy}")%></span>
                                <span class="happening-title"><%#Eval("eventstitle") %></span>
                                <span class="happening-desc"><%#Server.HtmlDecode(Eval("shortdesc").ToString()) %></span>
                                <span class="btn btn-circle"><img class="img-fluid" src="/images/right-angle-white.svg" alt="right-angle-white"/></span>
                            </div>
                        </a>
                    </div>
                
            </ItemTemplate>
            </asp:Repeater>
            </div>


            </div>
        </section>


</asp:Content>

