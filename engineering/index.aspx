<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="engineering_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/engineering/usercontrols/mainmenu.ascx" TagName="mainmenu" TagPrefix="uc1" %>
<%@ Register Src="~/engineering/usercontrols/hamburger.ascx" TagName="hamburger" TagPrefix="uc2" %>
<%@ Register Src="~/engineering/usercontrols/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="~/engineering/usercontrols/footermobile.ascx" TagName="footermobile" TagPrefix="uc4" %>
<%@ Register Src="~/engineering/usercontrols/seosection.ascx" TagName="seosection" TagPrefix="uc5" %>
<%@ Register Src="~/engineering/usercontrols/homebanner.ascx" TagName="homebanner" TagPrefix="uc6" %>
<%@ Register Src="~/engineering/usercontrols/courselevelsearch.ascx" TagName="courselevelsearch" TagPrefix="uc7" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <uc5:seosection ID="seosection1" runat="server" />
    <link rel="stylesheet" type="text/css" href="/engineering/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="/engineering/css/swiper.min.css">
    <link rel="stylesheet" type="text/css" href="/engineering/css/owl.carousel.min.css">
    <link rel="stylesheet" href="https://unpkg.com/aos@next/dist/aos.css" />
    <link rel="stylesheet" type="text/css" href="/engineering/css/animate.css">
    <link rel="stylesheet" type="text/css" href="/engineering/css/common.css">
    <link rel="stylesheet" type="text/css" href="/engineering/css/header.css">
    <link rel="stylesheet" type="text/css" href="/engineering/css/footer.css">
    <link rel="stylesheet" type="text/css" href="/engineering/css/home-page.css">
    <link rel="stylesheet" type="text/css" href="/engineering/css/home-responsive.css">
    <link href="../css/dynamic.css" rel="stylesheet" type="text/css" />


<script>
    function myFunction() {
        var input, filter, ul, li, a, i, txtValue;
        input = document.getElementById("myInput");
        filter = input.value.toUpperCase();
        ul = document.getElementById("myUL");
        document.getElementById("myUL").style.display = "";
        if (document.getElementById("myInput").value == "") {
            document.getElementById("myUL").style.display = "none";
            return;
        }
        li = ul.getElementsByTagName("li");
        for (i = 0; i < li.length; i++) {
            a = li[i].getElementsByTagName("a")[0];
            txtValue = a.textContent || a.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                li[i].style.display = "";
            } else {
                li[i].style.display = "none";
            }
        }
    }
</script>


</head>
<body>
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
 <uc2:hamburger ID="hamburger1" runat="server" />    
    <main>
       <uc6:homebanner ID="homebanner1" runat="server" />
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
                        <div class="swiper-button-next notice-next"><img src="./images/right-angle-white.svg"
                                class="img-fluid" alt="right angle"></div>
                        <div class="swiper-button-prev notice-prev"><img src="./images/left-angle-white.svg"
                                class="img-fluid" alt="right angle"></div>
                    </div>
                </div>
            </div>
        </section>

        <section class="home-academics">
            <div class="container">
                <div class="row gx-lg-5 gy-5">
                    <div class="col-lg-4">
                        <div class="home-academics_left-panel">
                            <div class="section-heading">
                                <h3 class="section-title text-lg">Learn At The Leading Institute of India</h3>
                            </div>
                            <ul class="courses-browse list-unstyled">
                                <li><a id="ankallcourse" runat="server">Browse All Course</a></li>
                                <li><a id="ankdeptcourse" runat="server">Browse by Department</a></li>
                            </ul>
                            <a href="/engineering/cpage.aspx?mpgid=81&pgidtrail=177" class="btn btn-xl btn-white"><asp:Literal ID="litadmission" runat="server"></asp:Literal>
                                <span class="btn btn-circle btn-prime"><img class="img-fluid"
                                        src="/images/right-angle-white.svg" /></span></a>
                        </div>
                    </div>
                    <div class="col-lg-8">
                        <div class="home-academics_right-panel">
                         <uc7:courselevelsearch ID="cousrelevelsearch1" runat="server" />                  
                            
                            <div class="row gy-5 gy-lg-0">
                                <asp:Repeater ID="rptcourses" runat="server" OnItemDataBound="rptcourses_OnItemDataBound">
                                <ItemTemplate>
                                <asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid") %>'></asp:Literal>
                                <div class="col-lg-4">
                                    <div id ="divcourse" runat="server" class="academics-bachelor-thumb blue_border">
                                        <a id="ank" runat="server"><h4><%#Eval("levelname")%></h4></a>
                                        <p><%#Server.HtmlDecode(Eval("details").ToString()) %></p>
                                    </div>
                                </div>
                                </ItemTemplate>
                                </asp:Repeater>

                               <div class="col-lg-4">
                                    <div class="academics-bachelor-thumb yellow_border">
                                        <h4>Other Programs</h4>
                                        <ul class="list-unstyled">
                                        <asp:Repeater ID="rptothercourses" runat="server" OnItemDataBound="rptothercourses_OnItemDataBound">
                                        <ItemTemplate>
                                        <asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid") %>'></asp:Literal>
                                            <li><a id="ank" runat="server"><%#Eval("levelname")%><img src="images/right-angle-white.svg"
                                                        alt="icon"></a></li>

                                        </ItemTemplate>
                                        </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="department bg-light">
            <div class="container full-width-xl px-0">
                <div class="section-heading text-center"  data-aos="fade-up"
                data-aos-anchor-placement="">
                    <h3 class="fw-bold">Departments at Institute of Engineering Education & Research</h3>
                </div>
                <div class="row gx-0 justify-content-end">
                    <div class="max-content-xl ms-auto">
                        <div class="department-inner" data-aos="fade-up"
                        data-aos-anchor-placement="">
                            <asp:Literal ID="litdepartmenttile" runat="server"></asp:Literal>
                            <div class="department-content bg-white">
                            <asp:Literal ID="littitle" runat="server"></asp:Literal>   
                                <div class="course-list">
                                    <div class="row gx-md-5">
                                        <div class="col-md-12">
                                            <ul class="list-unstyled mb-0" data-aos="fade-up"
                                            data-aos-anchor-placement="">
                                            <asp:Repeater ID="rptdepartmentleft" runat="server" OnItemDataBound="rptdepartmentleft_ItemDataBound">
                                            <ItemTemplate>
                                            <asp:Literal ID="litdeptid" runat="server" Text='<%#Eval("deptid")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="litcampusid" runat="server" Text='<%#Eval("campusid")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="litcollageid" runat="server" Text='<%#Eval("schoolid")%>' Visible="false"></asp:Literal>
                                                <li><a id="ank" runat="server"><%#Eval("deptname")%></a></li>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                            </ul>
                                        </div>
                                        <div class="col-md-12">
                                            <ul class="list-unstyled mb-0" data-aos="fade-up"
                                            data-aos-anchor-placement="" runat="server" visible="false">
                                               <asp:Repeater ID="rptdepartmentright" runat="server">
                                            <ItemTemplate>
                                            <asp:Literal ID="litdeptid" runat="server" Text='<%#Eval("deptid")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="litcampusid" runat="server" Text='<%#Eval("campusid")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="litcollageid" runat="server" Text='<%#Eval("schoolid")%>' Visible="false"></asp:Literal>
                                                <li><a href=""><%#Eval("deptname")%></a></li>
                                            </ItemTemplate>
                                            </asp:Repeater>
                                            </ul>
                                            <a href="/engineering/department-list.aspx?mpgid=77&pgidtrail=146"
                                                class="btn btn-white d-flex align-items-center px-0 mt-3 fw-bold" data-aos="fade-up">View
                                                All Departments <span class="btn btn-circle btn-prime"><img
                                                        class="img-fluid"
                                                        src="/images/right-angle-white.svg"></span></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        
            <asp:Literal ID="lithome" runat="server"></asp:Literal>
        
        <section class="bg-light placement">
            <div class="container">
                <div class="row gy-5 gy-lg-0 align-items-end">
                  <asp:Literal ID="litplacement" runat="server"></asp:Literal>
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
        <asp:Literal ID="litrec" runat="server"></asp:Literal>
        </section>
       <asp:Literal ID="litabouthome" runat="server"></asp:Literal>
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
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                              <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
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
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                              <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
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
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                              <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
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
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
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
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
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
                                            <asp:Literal id="litntypeid" runat="server"  Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <asp:Literal id="lituploadevents" runat="server"  Visible="false" Text='<%#Eval("uploadevents")%>'></asp:Literal>
                                            <asp:Literal id="litcolorcode" runat="server"  Visible="false" Text='<%#Eval("colorcode")%>'></asp:Literal>
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
        <section class="home-testimonials pt-0" id="paneltestimonials" runat="server" visible="false">
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
                                                    <img class="img-fluid" src="/uploads/TestimonialImage/<%#Eval("uploadphoto")%>" alt="testimonials">
                                                </figure>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="testimonials-content">
                                                    <figure>
                                                        <img class="img-fluid quote-icon" src="/images/quote-icon.svg" alt="quote-icon">
                                                    </figure>
                                                    <%#Server.HtmlDecode(Eval("testimonialdesc").ToString())%>
                                                    <div class="quote-footer">
                                                        <span class="person-name"><%#Eval("testimonialname")%></span>
                                                        <span class="designation"><%#Eval("desg")%></span>
                                                    </div>
                                                </div>
                                            </div>
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
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                
                 
                </div>
            </div>
        </section>
    </main>
  <uc3:footer ID="footer1" runat="server" />
  <uc4:footermobile ID="footermobile1" runat="server" />

    <script src="/engineering/js/jquery-3.5.1.min.js"></script>
    <script src="/engineering/js/bootstrap.bundle.min.js"></script>
    <script src="/engineering/js/swiper-bundle.js"></script>
    <script src="/engineering/js/owl.carousel.min.js"></script>
    <script src="/engineering/js/main.js"></script>
    <script src="/engineering/js/aos.js"></script>
    </form>
</body>
</html>
