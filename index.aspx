<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/usercontrols/mainmenu.ascx" TagName="mainmenu" TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/mobilefooter.ascx" TagName="mobilefooter" TagPrefix="uc3" %>
<%@ Register Src="~/usercontrols/homebanner.ascx" TagName="homebanner" TagPrefix="uc4" %>
<%@ Register Src="~/usercontrols/seosection.ascx" TagName="seosection" TagPrefix="uc5" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta name="google-site-verification" content="LnGOuTMt7ojCrCxhoCcpzhK9K5WOn2a_eBSXeFsMBPc" />
    <title></title>
    <uc5:seosection ID="seosection1" runat="server" />
    <link rel="stylesheet" type="text/css" href="/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="/css/swiper.min.css">
    <link rel="stylesheet" type="text/css" href="/css/owl.carousel.min.css">
    <link rel="stylesheet" type="text/css" href="/css/animate.css">
    <link rel="stylesheet" type="text/css" href="/css/common.css">
    <link rel="stylesheet" type="text/css" href="/css/header.css">
    <link rel="stylesheet" type="text/css" href="/css/footer.css">
    <link rel="stylesheet" type="text/css" href="/css/home-page.css">
    <link rel="stylesheet" type="text/css" href="/css/home-responsive.css">
<!-- Google Tag Manager -->

<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':

new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],

j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=

'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);

})(window,document,'script','dataLayer','GTM-T438RXXF');</script>

<!-- End Google Tag Manager -->
</head>
<body>
<!-- Google Tag Manager (noscript) -->

<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-T438RXXF"

height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>

<!-- End Google Tag Manager (noscript) -->
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference Name="MicrosoftAjax.js" />
                <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" />
                <asp:ScriptReference Name="Common.Common.js" Assembly="AjaxControlToolkit" />
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <uc1:mainmenu ID="mainmenu1" runat="server" />
    <main>
    <uc4:homebanner ID="homebanner1" runat="server" />
        <section class="py-4 notices">
            <div class="container">
                <div class="notices">
                    <h5 class="mb-0">Notice &amp; Announcements</h5>
                    <div class="swiper notice-slider">
                        <div class="swiper-wrapper">
                        <asp:Repeater ID="rptnotice" runat="server" OnItemDataBound="rptnotice_OnItemDataBound">
                        <ItemTemplate>
                        <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid")%>' Visible="false"></asp:Literal>
                        <asp:Literal ID="lituploadfile" runat="server" Text='<%#Eval("uploadfile")%>' Visible="false"></asp:Literal>
                        <div class="swiper-slide">
                                <div class="slide-item">
                                    <a id="ank" runat="server"><%#Eval("eventstitle")%></a>
                                </div>
                            </div>
                        </ItemTemplate>
                        </asp:Repeater>
                        </div>
                        <div class="swiper-button-next notice-next"><img src="/images/right-angle-white.svg"
                                class="img-fluid" alt="right angle"></div>
                        <div class="swiper-button-prev notice-prev"><img src="/images/left-angle-white.svg"
                                class="img-fluid" alt="right angle"></div>
                    </div>
                </div>
            </div>
        </section>
        <section class="bg-light home-academics">
            <asp:Literal ID="litacademics" runat="server"></asp:Literal>
        </section>
        <section class="lifeAtKKWagh">
        <asp:Literal ID="litlifeatkkwarg" runat="server"></asp:Literal>            
        </section>
        <section class="facilities pb-lg-0">
            <div class="container container-lg-fluid px-lg-0">
                <div class="facility-inner">
                    <div class="container facility-inner-container">
                        <div class="facility-heading">
                         <asp:Literal ID="litsmalldesc" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="tab-content tab-accordian" id="facilityTab">
                    <asp:Repeater ID="rptfacilitydetail" runat="server" OnItemDataBound="rptfacilitydetail_ItemDataBound">
                    <ItemTemplate>
                     <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                     <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                     <asp:Literal ID="litpageid" runat="server" Text='<%#Eval("pageid")%>' Visible="false"></asp:Literal>
                        <div id="panel1" runat="server">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a id="ank" runat="server" data-bs-toggle="collapse" data-bs-target=".facility-collapse1"
                                            aria-expanded="true"><%#Eval("linkname")%><span
                                                class="btn btn-circle btn-white"><img class="img-fluid"
                                                    src="/images/right-angle-white.svg"></span></a>
                                    </h4>
                                </div>
                                <div id="panel2" runat="server" data-bs-parent="#facilityTab">
                                    <div class="panel-body">
                                        <figure>
                                            <img class="img-fluid" src="uploads/banner/<%#Eval("uploadbanner")%>"
                                                alt="academic-facility" />
                                        </figure>
                                        <div class="pannel-content">
                                            <div class="container">
                                                <h5><%#Eval("linkname")%></h5>
                                               <%#Server.HtmlDecode(Eval("smalldesc").ToString())%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>                    
                    </div>
                </div>
                <div class="container d-none d-lg-block">
                    <ul class="nav nav-tabs tab-accordian-tabs">
                     <asp:Repeater ID="rptfacilities" runat="server" OnItemDataBound="rptfacilities_ItemDataBound">
                     <ItemTemplate>                       
                        <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                        <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                     <asp:Literal ID="litpageid" runat="server" Text='<%#Eval("pageid")%>' Visible="false"></asp:Literal>
                        <li class="nav-item"><a id="ank" runat="server" data-bs-toggle="tab"><span><%#Eval("linkname")%></span></a></li>
                     </ItemTemplate>
                     </asp:Repeater>
                    </ul>
                </div>
            </div>
        </section>
        <section class="bg-light placement">
            <div class="container">
                <div class="row gy-5 gy-lg-0 align-items-end">
                   <asp:Literal id="litplacement" runat="server"></asp:Literal>   
                    <div class="col-lg-6">
                        <div class="placement-testimonials-container">
                            <figure>
                                <img class="img-fluid quote-icon" src="/images/quote-icon.svg" alt="quote-icon" />
                            </figure>
                            <div class="swiper placement-testimonial-slider">
                                <div class="swiper-wrapper">
                                    <asp:Repeater ID="rptplacement" runat="server">
                                    <ItemTemplate>
                                    <asp:Literal id="litspid" runat="server"  Visible="false" Text='<%#Eval("spid")%>'></asp:Literal>
                                    <div class="swiper-slide">
                                        <div class="slide-item">
                                            <blockquote>
                                              <%#Server.HtmlDecode(Eval("shortdesc").ToString())%>
                                            </blockquote>
                                            <span class="person-name"><%#Eval("name")%></span>
                                            <span class="designation"><%#Eval("branch")%></span>
                                        </div>
                                    </div>
                                    </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="swiper-button-next placement-testimonial-next swiper-button-bottom">
                                <img src="/images/right-angle-white.svg" class="img-fluid" alt="right angle"></div>
                                <div class="swiper-button-prev placement-testimonial-prev swiper-button-bottom">
                                <img src="/images/left-angle-white.svg" class="img-fluid" alt="right angle"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="recruiters">
            <asp:Literal id="litrecruiters" runat="server"></asp:Literal>                
            </div>
        </section>
        <section class="quality-education">
            <asp:Literal ID="litabout" runat="server"></asp:Literal>
        </section>
     
             <section class="happening pt-0" id="panelhappping" runat="server" visible="true">
            <div class="container">
                <div class="section-heading">
                    <span class="heading-top">Happenings</span>
                    <h3 class="section-title">Everything that enthuses people at our university.</h3>
                </div>
                <ul class="nav nav-tabs">
                <asp:Repeater ID="rptmediatype" runat="server" OnItemDataBound="rptmediatype_OnItemDataBound">
                <ItemTemplate>
                   <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                    <li class="nav-item"><a id="ank" runat="server" data-bs-toggle="tab"><span><%#Eval("ntype")%></span></a></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul>
            </div>
            <div class="container max-content-lg">
                <div class="tab-content" id="happeningTabs">
                <asp:Repeater ID="rptmediadetail" runat="server" OnItemDataBound="rptmediadetail_OnItemDataBound">
                <ItemTemplate>
                <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                
                    <div id="panel1" runat="server">
                        <div class="panel panel-default">                          
                            <div class="panel-collapse collapse show in happening-collapse1"
                                data-bs-parent="#happeningTabs">
                             
                                <div class="panel-body">
                                    <div class="pannel-content">
                                        <div class="row gx-2 gy-2">
                                            <div class="col-xl-2">
                                                <div
                                                    class="news-thumb bg-prime-dark before-el before-prime desktop-only">

                                                </div>
                                            </div>
                                            <!-- 1 -->
                                            <asp:Repeater ID="rpteventsone" runat="server" OnItemDataBound="rptevenstone_OnItemDataBound">
                                            <ItemTemplate>
                                            <asp:Literal id="liteventsid" runat="server"  Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                              <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <div class="col-xl-5 col-lg-8 col-sm-7">
                                                <div class="news-thumb with-image">
                                                    <figure id="fg1" runat="server">
                                                        <img class="img-fluid" src="/uploads/smallimages/<%#Eval("uploadevents")%>"
                                                            alt="<%#Eval("eventsid")%>" />
                                                    </figure>
                                                    <a id="ank" runat="server" class="thumb-text">
                                                        <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle")%></span>
                                                    </a>
                                                </div>
                                            </div>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                            
                                            <!-- 2 -->
                                               <asp:Repeater ID="rpteventstwo" runat="server" OnItemDataBound="rptevensttwo_OnItemDataBound">
                                            <ItemTemplate>
                                            <asp:Literal id="liteventsid" runat="server"  Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                              <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <div class="col-xl-2 col-lg-4 col-sm-5">
                                                <div class="news-thumb bg-red">
                                                    <a id="ank" runat="server" class="thumb-text">
                                                        <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle")%></span>
                                                        <span class="btn btn-circle btn-white"><img class="img-fluid"
                                                                src="/images/right-angle-white.svg" /></span>
                                                    </a>
                                                </div>
                                            </div>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                            <!-- 3 -->
                                              <asp:Repeater ID="rptevenstthree" runat="server" OnItemDataBound="rptevenstthree_OnItemDataBound">
                                            <ItemTemplate>
                                            <asp:Literal id="liteventsid" runat="server"  Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                              <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <div class="col-xl-2 col-lg-4 col-sm-5">
                                                <div class="news-thumb with-image image-small after-el after-prime">
                                                    <figure id="fg1" runat="server">
                                                        <img class="img-fluid" src="/uploads/smallimages/<%#Eval("uploadevents")%>"
                                                            alt="<%#Eval("eventsid")%>" />
                                                    </figure>
                                                    <a id="ank" runat="server" class="thumb-text">
                                                          <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle")%></span>
                                                    </a>
                                                </div>
                                            </div>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                            <!-- 4 -->
                                                   <asp:Repeater ID="rpteventsfour" runat="server" OnItemDataBound="rpteventsfour_OnItemDataBound">
                                            <ItemTemplate>
                                            <asp:Literal id="liteventsid" runat="server"  Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                            <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <div class="col-xl-5 col-lg-8 col-sm-7">
                                                <div class="news-thumb with-image">
                                                    <figure id="fg1" runat="server">
                                                        <img class="img-fluid" src="/uploads/smallimages/<%#Eval("uploadevents")%>"
                                                            alt="<%#Eval("eventsid")%>" />
                                                    </figure>
                                                    <a id="ank" runat="server" class="thumb-text">
                                                           <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle")%></span>
                                                    </a>
                                                </div>
                                            </div>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                            <!-- 5 -->
                                               <asp:Repeater ID="rpteventsfive" runat="server" OnItemDataBound="rptevenstfive_OnItemDataBound">
                                            <ItemTemplate>
                                            <asp:Literal id="liteventsid" runat="server"  Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                            <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <div class="col-xl-2 col-lg-4 col-sm-5">
                                                <div class="news-thumb bg-yellow">
                                                    <a id="ank" runat="server" class="thumb-text">
                                                         <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle")%></span>
                                                        <span class="btn btn-circle btn-white"><img class="img-fluid"
                                                                src="./images/right-angle-white.svg" /></span>
                                                    </a>
                                                </div>
                                            </div>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                            <!-- 6 -->
                                              <asp:Repeater ID="rpteventssix" runat="server" OnItemDataBound="rpteventssix_OnItemDataBound">
                                            <ItemTemplate>
                                            <asp:Literal id="liteventsid" runat="server"  Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                            <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <div class="col-xl-5 col-lg-8 col-sm-7">
                                                <div class="news-thumb with-image">
                                                    <figure id="fg1" runat="server">
                                                        <img class="img-fluid" src="/uploads/smallimages/<%#Eval("uploadevents")%>"
                                                            alt="<%#Eval("eventsid")%>" />
                                                    </figure>
                                                    <a id="ank" runat="server" class="thumb-text">
                                                           <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle")%></span>
                                                    </a>
                                                </div>
                                            </div>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                        
                                
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                </div>
            </div>
        </section>
        <section class="home-testimonials pt-0">
            <div class="container">
                <div class="section-heading text-center">
                    <h2 class="fw-bold">Testimonials</h2>
                </div>
                <ul class="nav nav-tabs mx-auto">
                <asp:Repeater ID="rpttestimonials" runat="server" OnItemDataBound="rpttestimonials_ItemDataBound">
                <ItemTemplate>                
                <asp:Literal id="littesid" runat="server"  Visible="false" Text='<%#Eval("tesid")%>'></asp:Literal>
                    <li class="nav-item"><a id="ank" runat="server" data-bs-toggle="tab"><span><%#Eval("testimonialtype")%></span></a></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul>
                <div class="tab-content" id="testimonialsTabs">
                <asp:Repeater ID="rpttestimonialsdetail" runat="server" OnItemDataBound="rpttestimonialsdetail_ItemDataBound">
                <ItemTemplate>
                <asp:Literal id="littesid" runat="server"  Visible="false" Text='<%#Eval("tesid")%>'></asp:Literal>
                    <div id="panel1" runat="server">
                        <div class="panel panel-default">
                            <div class="swiper testimonialsTab1-slider">
                                <div class="swiper-wrapper">
                                <asp:Repeater ID="rptinner" runat="server">
                                <ItemTemplate>
                                <asp:Literal id="littesid" runat="server"  Visible="false" Text='<%#Eval("tesid")%>'></asp:Literal>
                                <asp:Literal id="littestimonialid" runat="server"  Visible="false" Text='<%#Eval("testimonialid")%>'></asp:Literal>
                                <div class="swiper-slide">
                                        <div class="row gx-0 ">
                                            <div class="col-lg-6 order-lg-2">
                                                <figure class="testimonials-image py-lg-4">
                                                    <img class="img-fluid" src="uploads/TestimonialImage/<%#Eval("uploadphoto")%>" alt="testimonials">
                                                </figure>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="testimonials-content">
                                                    <figure>
                                                        <img class="img-fluid quote-icon" src="/images/quote-icon.svg" alt="quote-icon">
                                                    </figure>
                                                    <%#Server.HtmlDecode(Eval("testimonialdesc").ToString())%>
                                                    <div class="quote-footer text-center">
                                                        <span class="person-name"><%#Eval("testimonialname")%></span>
                                                        <span class="designation"><%#Eval("desg")%></span>
														<a class="btn btn-circle btn-prime mx-auto" href="javascript:void(0)"><img class="img-fluid" src="./images/right-angle-white.svg"></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                </asp:Repeater>
                                    
                                    
                                </div>
                                <div class="swiper-button-next swiper-button-bottom"><img
                                        src="./images/right-angle-white.svg" class="img-fluid" alt="right angle"></div>
                                <div class="swiper-button-prev swiper-button-bottom"><img
                                        src="./images/left-angle-white.svg" class="img-fluid" alt="right angle"></div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                
                 
                </div>
            </div>
        </section>
    </main>
    <uc2:footer ID="footer1" runat="server" />
    <uc3:mobilefooter ID="monilefooter1" runat="server" />
    <script src="/js/jquery-3.5.1.min.js"></script>
    <script src="/js/bootstrap.bundle.min.js"></script>
    <script src="/js/swiper-bundle.js"></script>
	<script src="/js/owl.carousel.min.js"></script>
    <script src="/js/aos.js"></script>
    <script src="/js/main.js"></script>
    </form>
</body>
</html>
