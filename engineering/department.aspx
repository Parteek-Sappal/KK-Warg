<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/department.master"
    AutoEventWireup="true" CodeFile="department.aspx.cs" Inherits="engineering_department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="department_banner_sec department_top_section" id="panelbanner" runat="server"
        visible="false">
            <div class="full-width px-0">
                <figure class="mb-0">
                <asp:Image ID="img" runat="server" class="img-fluid"/>                    
                </figure>
            </div>
        </section>
    <asp:Literal ID="litdeptshortdesc" runat="server"></asp:Literal>
    <asp:Literal ID="litdeptdesc" runat="server"></asp:Literal>
    <asp:Literal ID="litprogramoffered" runat="server"></asp:Literal>
    <asp:Literal ID="litvission" runat="server"></asp:Literal>
    <asp:Literal ID="litprograms" runat="server"></asp:Literal>
    <section class="bg-light placement" id="panelrecruiter" runat="server" visible="false">
            <div class="container" runat="server" visible="false">
                <div class="row gy-5 gy-lg-0 align-items-end">
                <asp:Literal ID="litplacmenttitle" runat="server"></asp:Literal>
                <div class="col-lg-6">
	<div class="section-heading text-center text-lg-start">
		<span class="heading-top">Placements</span>
		<h3 class="section-title text-lg">
			<span>Stand out from the crowd</span></h3>
	</div>
	<div class="stats stats-lg after-el">
		<span data-count="20">k+</span> <span class="desc">Students Placed in 2021</span></div>
</div>
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
                                <div class="swiper-button-next placement-testimonial-next swiper-button-bottom"><img
                                        src="/images/right-angle-white.svg" class="img-fluid" alt="right angle"></div>
                                <div class="swiper-button-prev placement-testimonial-prev swiper-button-bottom"><img
                                        src="/images/left-angle-white.svg" class="img-fluid" alt="right angle"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
      <asp:Literal ID="litRecruiters" runat="server"></asp:Literal>      
        </section>
    <asp:Literal ID="litInfrastructure" runat="server"></asp:Literal>
    <section class="home-faculty" id="panelfaculty" runat="server" visible="false">
            <div class="container">
                <div class="section-heading text-center">
                    <h3 class="section-title">Faculty</h3>
                </div>
                <div class="distinguished_faculty_sec">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row gy-5">
                               <asp:Repeater ID="rptfaculty" runat="server" OnItemDataBound="rptfaculty_ItemDataBound">
                              <ItemTemplate>
                              <asp:Literal ID="litfaculityid" runat="server" Text='<%#Eval("facultyid")%>' Visible="false"></asp:Literal>
                              <asp:Literal ID="litfimage" runat="server" Text='<%#Eval("fimage")%>' Visible="false"></asp:Literal>
                                <div class="col-lg-3 col-md-6">
                                    <a id="ank" runat="server" class="faculties_box">
                                        <figure class="faculties_img">
                                            <img id="img" runat="server" class="img-fluid w-100" alt='<%#Eval("fname")%>'>
                                        </figure>
                                        <div class="faculties_cont">
                                            <span><%#Eval("nprefix")%> <%#Eval("fname")%></span>
                                            <p><%#Eval("designationname")%></p>
                                            <abbr><%#Eval("qualification")%></abbr>
                                        </div>
                                    </a>
                                </div>
                              </ItemTemplate>
                              </asp:Repeater>                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="happening department-home_happening" id="panelhappening" runat="server" visible="false">
            <div class="container">
                <div class="section-heading text-center text-lg-start">
                    <span class="heading-top">Happenings</span>
                    <h3 class="section-title">Everything that enthuses people at our university.</h3>
                </div>
                <ul class="nav nav-tabs">
                <asp:Repeater ID="rpttab" runat="server" OnItemDataBound="rpttab_OnItemDataBound">
                <ItemTemplate>
                <asp:Literal ID="litntypeid" runat="server" Visible="false" Text='<%#Eval("ntypeid") %>'></asp:Literal>
                    <li class="nav-item"><a id="ank" runat="server"><span><%#Eval("ntype") %></span></a></li>                
                </ItemTemplate>
                </asp:Repeater> 
                    <li class="nav-item"><a data-bs-target=".happening-tab3" data-bs-toggle="tab"><span>Gallery</span></a></li>
                </ul>
            </div>
            <div class="container max-content-lg">
                <div class="tab-content" id="happeningTabs">
                <asp:Repeater ID="rpttabcontent" runat="server" OnItemDataBound="rpttabcontent_OnItemDataBound">
                <ItemTemplate>
                <asp:Literal ID="litntypeid" runat="server" Visible="false" Text='<%#Eval("ntypeid") %>'></asp:Literal>
                    <div id="divmain" runat="server">
                        <div class="panel panel-default">               
                            <div id="happening-collapse1" class="panel-collapse collapse show in"
                                data-bs-parent="#happeningTabs">
                                <div class="panel-body">
                                    <div class="pannel-content">
                                        <div class="row gx-2 gy-2">
                                            <div class="col-xl-2">
                                                <div
                                                    class="news-thumb bg-prime-dark before-el before-prime desktop-only">
                                                </div>
                                            </div>
                                            <asp:Repeater ID="rptnews" runat="server" OnItemDataBound="rptnews_OnItemDataBound">
                                            <ItemTemplate>
                                            <asp:Literal ID="litntypeid" runat="server" Visible="false" Text='<%#Eval("ntypeid") %>'></asp:Literal>   
                                            <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid") %>'></asp:Literal>                                         
                                            <asp:Literal ID="liteventstitle" runat="server" Visible="false" Text='<%#Eval("eventstitle") %>'></asp:Literal>
                                            <div id="div1" runat="server" visible="false" class="col-xl-5 col-lg-8 col-sm-7">
                                                <div class="news-thumb with-image">
                                                    <figure>
                                                        <img class="img-fluid" src='/uploads/smallimages/<%#Eval("uploadevents") %>'
                                                            alt="<%#Eval("eventstitle") %>" />
                                                    </figure>
                                                    <a id="a1" runat="server" class="thumb-text">
                                                        <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle") %></span>
                                                    </a>
                                                </div>
                                            </div>
                                            <div id="div2" runat="server" visible="false" class="col-xl-2 col-lg-4 col-sm-5">
                                                <div class="news-thumb bg-red">
                                                    <a id="a2" runat="server" class="thumb-text">
                                                        <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle") %></span>
                                                        <span class="btn btn-circle btn-white"><img class="img-fluid"
                                                                src="/images/right-angle-white.svg" /></span>
                                                    </a>
                                                </div>
                                            </div>
                                            <div id="div3" runat="server" visible="false" class="col-xl-2 col-lg-4 col-sm-5">
                                                <div class="news-thumb with-image image-small after-el after-prime">
                                                    <figure>
                                                        <img class="img-fluid" src="/uploads/smallimages/<%#Eval("uploadevents") %>"
                                                            alt="<%#Eval("eventstitle") %>" />
                                                    </figure>
                                                    <a id="a3" runat="server" class="thumb-text">
                                                        <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle") %></span>
                                                    </a>
                                                </div>
                                            </div>
                                            <div id="div4" runat="server" visible="false" class="col-xl-5 col-lg-8 col-sm-7">
                                                <div class="news-thumb with-image">
                                                    <figure>
                                                        <img class="img-fluid" src="/uploads/smallimages/<%#Eval("uploadevents") %>"
                                                            alt="<%#Eval("eventstitle") %>" />
                                                    </figure>
                                                    <a id="a4" runat="server" class="thumb-text">
                                                        <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle") %></span>
                                                    </a>
                                                </div>
                                            </div>
                                            <div id="div5" runat="server" visible="false" class="col-xl-2 col-lg-4 col-sm-5">
                                                <div class="news-thumb bg-yellow">
                                                    <a id="a5" runat="server" class="thumb-text">
                                                        <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle") %></span>
                                                        <span class="btn btn-circle btn-white"><img class="img-fluid"
                                                                src="./images/right-angle-white.svg" /></span>
                                                    </a>
                                                </div>
                                            </div>
                                            <div id="div6" runat="server" visible="false" class="col-xl-5 col-lg-8 col-sm-7">
                                                <div class="news-thumb with-image">
                                                    <figure>
                                                        <img class="img-fluid" src="/uploads/smallimages/<%#Eval("uploadevents") %>"
                                                            alt="<%#Eval("eventstitle") %>" />
                                                    </figure>
                                                    <a id="a6" runat="server" class="thumb-text">
                                                        <span class="timing"><%#Eval("eventsdate","{0:dd-MMM-yyyy}")%></span>
                                                        <span class="news-title"><%#Eval("eventstitle") %></span>
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
                    <div class="tab-pane happening-tab3">
                        <div class="panel panel-default">
                            <div id="happening-collapse3" class="panel-collapse collapse show in" data-bs-parent="#happeningTabs">
                                <div class="panel-body">
                                    <div class="pannel-content">
                                        <div class="gallery-list mt-0">
                                            <div class="row gy-3 gx-3">
                                                <asp:Repeater ID="rptgallery" runat="server" OnItemDataBound="rptgallery_OnItemDataBound">
                                                <ItemTemplate>
                                                <asp:Literal id="littypeid" runat="server" Visible="false" Text='<%#Eval("typeid") %>'></asp:Literal>
                                                <asp:Literal id="litalbumid" runat="server" Visible="false" Text='<%#Eval("albumid") %>'></asp:Literal>
                                                
                                                <div class="col-lg-4 col-sm-6">
                                                    <a id="ank" runat="server">
                                                        <figure>
                                                            <img class="img-fluid" src="/uploads/largeimages/<%#Eval("uploadaimage") %>" alt="Gallery image">
                                                            <figcaption>
                                                                <div class="icon">
                                                                    <img src="./images/icon-feather-image.png" alt="image icon">
                                                                </div>
                                                                <span><asp:Label ID="lblcnt" runat="server"></asp:Label></span>
                                                            </figcaption>
                                                        </figure>
                                                        <div class="text">
                                                            <span class="collection-title"><%#Eval("albumtitle")%></span>
                                                        </div>
                                                    </a>
                                                </div>
                                                </ItemTemplate>
                                                </asp:Repeater>
<%--                                                <div class="col-lg-4 col-sm-6">
                                                    <a href="" class="gallery-thumb image">
                                                        <figure>
                                                            <img class="img-fluid" src="./images/gallery-1.jpg" alt="Gallery image">
                                                            <figcaption>
                                                                <div class="icon">
                                                                    <img src="./images/icon-feather-image.png" alt="image icon">
                                                                </div>
                                                                <span>20 Photos</span>
                                                            </figcaption>
                                                        </figure>
                                                        <div class="text">
                                                            <span class="collection-title">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</span>
                                                        </div>
                                                    </a>
                                                </div>
                                                <div class="col-lg-4 col-sm-6">
                                                    <a href="" class="gallery-thumb image full-height">
                                                        <figure>
                                                            <img class="img-fluid" src="./images/gallery-2.jpg" alt="Gallery image">
                                                            <figcaption>
                                                                <div class="icon">
                                                                    <img src="./images/icon-feather-image.png" alt="image icon">
                                                                </div>
                                                                <span>20 Photos</span>
                                                            </figcaption>
                                                        </figure>
                                                        <div class="text">
                                                            <span class="collection-title">Aenean commodo ligula eget dolor. enenatis vitae, justo aenean massa.</span>
                                                        </div>
                                                    </a>
                                                </div>
                                                <div class="col-lg-4 col-sm-6">
                                                    <a href="" class="gallery-thumb video">
                                                        <figure>
                                                            <img class="img-fluid" src="./images/gallery-3.jpg" alt="Gallery image">
                                                            <figcaption>                                        
                                                                <div class="icon">
                                                                    <img src="./images/video-icon-red.svg" alt="image icon">
                                                                </div>
                                                                <span class="">20 Videos</span>
                                                            </figcaption>
                                                        </figure>
                                                        <div class="text">
                                                            <span class="collection-title">Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.</span>
                                                        </div>
                                                    </a>
                                                </div>
                                                <div class="col-lg-4 col-sm-6">
                                                    <a href="" class="gallery-thumb image">
                                                        <figure>
                                                            <img class="img-fluid" src="./images/gallery-4.jpg" alt="Gallery image">
                                                            <figcaption>                                        
                                                                <div class="icon">
                                                                    <img src="./images/icon-feather-image.png" alt="image icon">
                                                                </div>
                                                                <span class="">20 Photos</span>
                                                            </figcaption>
                                                        </figure>
                                                        <div class="text">
                                                            <span class="collection-title">Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.</span>
                                                        </div>
                                                    </a>
                                                </div>
                                                <div class="col-lg-4 col-sm-6">
                                                    <a href="" class="gallery-thumb video">
                                                        <figure>
                                                            <img class="img-fluid" src="./images/gallery-5.jpg" alt="Gallery image">
                                                            <figcaption>                                        
                                                                <div class="icon">
                                                                    <img src="./images/video-icon-red.svg" alt="image icon">
                                                                </div>
                                                                <span class="">20 Videos</span>
                                                            </figcaption>
                                                        </figure>
                                                        <div class="text">
                                                            <span class="collection-title">Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.</span>
                                                        </div>
                                                    </a>
                                                </div>
                                                <div class="col-lg-4 col-sm-6">
                                                    <a href="" class="gallery-thumb image full-height">
                                                        <figure>
                                                            <img class="img-fluid" src="./images/gallery-6.jpg" alt="Gallery image">
                                                            <figcaption>                                        
                                                                <div class="icon">
                                                                    <img src="./images/icon-feather-image.png" alt="image icon">
                                                                </div>
                                                                <span class="">20 Photos</span>
                                                            </figcaption>
                                                        </figure>
                                                        <div class="text">
                                                            <span class="collection-title">Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.</span>
                                                        </div>
                                                    </a>
                                                </div>
--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    <section class="home-testimonials pt-0" id="paneltestimonials" runat="server">
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
</asp:Content>
