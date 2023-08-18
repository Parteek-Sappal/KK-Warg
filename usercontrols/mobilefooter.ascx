<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mobilefooter.ascx.cs" Inherits="usercontrols_mobilefooter" %>
<%@ Register Src="~/usercontrols/search.ascx" TagName="search" TagPrefix="uc1" %>
<div class="foot-nav mobile-only">
        <div class="row gx-0">
            <div class="col-3">
                <a href="javascript:void(0)" data-target=".courses-mobile">
                    <img class="img-fluid" src="/images/book.svg">
                    <span>Courses</span>
                </a> 
            </div>
            <div class="col-3">
                <a href="javascript:void(0)" data-target=".admission-mobile">
                    <img class="img-fluid" src="/images/academic.svg">
                    <span>Admission</span>
                </a> 
            </div>
            <div class="col-3">
                <a href="javascript:void(0)" data-target=".contact-mobile">
                    <img class="img-fluid" src="/images/phone.svg">
                    <span>Contact</span>
                </a> 
            </div>
            <div class="col-3">
                <a href="javascript:void(0)" data-target=".menu-mobile">
                    <img class="img-fluid" src="/images/bars.svg">
                    <span>Menu</span>
                </a> 
            </div>
        </div>
    </div>
    <div class="mobile-menu-container">
        <div class="drop-menu courses-mobile">
            <div class="container">
                <div class="drop-menu-inner">
                    <span class="drop-menu-heading">Courses</span>
                    <div class="top-box">                        
                        <span class="drop-sub-heading">Search for a course</span>
                        <form action="">
                            <div class="search-course">
                             <uc1:search ID="search1" runat="server" />
                            </div>
                        </form>
                    </div>
                    <div class="course-list">
                        <a href="" class="bg-prime-dark">Undergraduate Programs <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
                        <a href="" class="bg-red">Postgraduate Programs <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
                        <a href="" class="bg-text">Ph.D Programs <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
                        <a href="" class="bg-yellow">View All Programs <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
                    </div>
                </div>
            </div>
        </div>
        <div class="drop-menu admission-mobile">
            <div class="container">
                <div class="drop-menu-inner">
                    <span class="drop-menu-heading">Admission 2023</span>
                    <div class="top-box text-center">
                        <a href="">Admission Process</a>
                        <a href="">Eligibility</a>
                        <a href="">Required Documents</a>
                        <a href="">Admission Enquiry Form</a>
                        <a href="">Payment Procedure</a>
                        <a href="">Scholarships</a>
                    </div>
                    <div class="course-list">
                        <a href="" class="bg-yellow justify-content-center">APPLY NOW<span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
                    </div>
                    <div class="menu-contact">
                        <img src="/images/icon-feather-phone.svg" alt="phone" class="img-fluid">
                        <span class="c-heading">Admission Helpline</span>
                        <p><a href="tel: +91 253 2516671">+91 253 2516671</a></p>
                    </div>
                </div>
            </div>
        </div>
        <div class="drop-menu contact-mobile">
            <div class="container">
                <div class="drop-menu-inner">
                    <span class="drop-menu-heading">Contact</span>
                    <div class="menu-contact">
                        <img src="/images/icon-feather-phone.svg" alt="phone" class="img-fluid">
                        <a href="tel: +91 253 2512876">+91 253 2512876</a>
                        <a href="tel: +91 253 2512867">+91 253 2512867</a>
                    </div>
                    <div class="menu-contact">
                        <img src="/images/icon-feather-mail.svg" alt="mail" class="img-fluid">
                        <a href="mailto: kkwieer@kkwagh.edu.in">kkwieer@kkwagh.edu.in</a>
                        <a href="mailto: kkwe_office@dataone.in">kkwe_office@dataone.in</a>
                    </div>
                    <div class="menu-contact">
                        <img src="/images/icon-material-place.svg" alt="place" class="img-fluid">
                        <p class="text-center">Hirabai Haridas Vidyanagari, Amrutdham, Panchavati, Nashik – 422003</p>
                    </div>
                    <div class="course-list">
                        <a href="" class="bg-yellow justify-content-center"><img class="img-fluid" src="/images/icon-chat.svg">Chat Now</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="drop-menu menu-mobile">
            <div class="container">
                <div class="drop-menu-inner">
                    <div class="main-menus">
                      <asp:Repeater ID="rptmobilemenu" runat="server" OnItemDataBound="rptmobilemenu_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                            <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                            <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                            <a id="ank" runat="server">
                                <%#Eval("linkname")%></a>
                        </ItemTemplate>
                    </asp:Repeater>
                    </div>
                    <div class="secondary-menus">
                        <a href="">Placements</a>
                        <a href="">Contact</a>
                        <a href="">Happenings</a>
                        <a href="">Testimonials</a>
                        <a href="">Careers</a>
                        <a href="">Contact</a>
                        <a href="">Get Social</a>
                        <a href="">ERP Login</a>
                    </div>
                </div>
            </div>
        </div>
    </div>