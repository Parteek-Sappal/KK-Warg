<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master"
    AutoEventWireup="true" CodeFile="newsdetail.aspx.cs" Inherits="engineering_newsdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="happening-details news-details top-section">
 <asp:Repeater ID="rptnewdetail" runat="server" OnItemDataBound="rptnewdetail_OnItemDataBound">
 <ItemTemplate>
   <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid")%>' Visible="false"></asp:Literal>
   <asp:Literal ID="litlargeimage" runat="server" Text='<%#Eval("largeimage")%>' Visible="false"></asp:Literal>
   <div class="container">
                <div class="happening-heading">
                    <p class="timing"><%#Eval("eventsdate","{0:MMM dd, yyyy}")%></p>
                    <h3 class="happening-title"><%#Eval("eventstitle")%></h3>
                    <blockquote><%#Server.HtmlDecode(Eval("shortdesc").ToString())%></blockquote>
                    <div class="btns-group">
                        <a href="javascript:void(0)" class="btn btn-circle btn-circle-lg"><img class="img-fluid" src="/images/print-icon.svg" alt="print icon" /></a>
                        <a href="javascript:void(0)" class="btn btn-circle btn-circle-lg"><img class="img-fluid" src="/images/share-icon.svg" alt="share icon" /></a>
                        <a href="javascript:void(0)" class="btn btn-circle btn-circle-lg"><img class="img-fluid" src="/images/pdf-icon.svg" alt="print icon" /></a>
                    </div>
                </div>
            </div>
<div class="container">
            <div class="container max-content-lg" id="panleimage" runat="server" visible="false">
                <figure class="happening-banner mb-0">
                    <img src="/uploads/largeimages/<%#Eval("largeimage")%>" class="img-fluid" alt="<%#Eval("eventsid")%>">
                </figure>
           
                        <%#Server.HtmlDecode(Eval("eventsdesc").ToString())%>
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
                        <div class="swiper-slide">
                        <asp:Repeater ID="rptmediaphoto" runat="server">
                        <ItemTemplate>
                        <asp:Literal ID="lituploadevents" runat="server" Text='<%#Eval("photoid") %>' Visible="false"></asp:Literal>
                        <div class="slide-item">
                                <figure>
                                    <img class="img-fluid" src="uploads/LargeImages/<%#Eval("uploadphoto") %>">
                                </figure>
                            </div>
                        </ItemTemplate>
                        </asp:Repeater>
                            
                        </div>                     
                    </div>
                    <div class="swiper-button-next swiper-button-bottom"><img
                            src="./images/right-angle-white.svg" class="img-fluid" alt="right angle"></div>
                    <div class="swiper-button-prev swiper-button-bottom"><img
                            src="./images/left-angle-white.svg" class="img-fluid" alt="right angle"></div>
                </div>
            </div>
        </section>
    <section class="related-news other-news pt-0">
            <div class="container">
                <div class="section-heading text-center">
                    <h3 class="section-title secondary">Related News</h3>
                </div>
                <div class="row gx-3 gy-4 mt-3">
                <asp:Repeater ID="rptewlatednews" runat="server" OnItemDataBound="rptewlatednews_OnItemDataBound">
                <ItemTemplate>
                <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid")%>' Visible="false"></asp:Literal>
                <asp:Literal ID="lituploadevents" runat="server" Text='<%#Eval("uploadevents")%>' Visible="false"></asp:Literal>
                <asp:Literal ID="litcolorcode" runat="server" Text='<%#Eval("colorcode")%>' Visible="false"></asp:Literal>
                <div class="col-lg-4 col-md-6">
                        <a id="ank" runat="server" class="happening-thumb with-image">
                            <figure id="fg1" runat="server">
                                <img class="img-fluid" src="/uploads/SmallImages/<%#Eval("uploadevents")%>" alt="<%#Eval("eventsid")%>">
                            </figure>
                            <div class="happening-content">
                                <span class="timing"><%#Eval("eventsdate","{0:MMM dd, yyyy}")%></span>
                                <span class="happening-title"><%#Eval("eventstitle")%></span>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                    
                    
                </div>
            </div>
        </section>
</asp:Content>
