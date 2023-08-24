<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footermobile.ascx.cs"
    Inherits="engineering_usercontrols_footermobile" %>
    <%@ Register Src="~/engineering/usercontrols/search.ascx" TagName="search" TagPrefix="uc1" %>
<div class="foot-nav mobile-only">
    <div class="row gx-0">
        <div class="col-3">
            <a href="javascript:void(0)" data-target=".courses-mobile">
                <img class="img-fluid" src="/images/book.svg">
                <span>Courses</span> </a>
        </div>
        <div class="col-3">
            <a href="javascript:void(0)" data-target=".admission-mobile">
                <img class="img-fluid" src="/images/academic.svg">
                <span>Admission</span> </a>
        </div>
        <div class="col-3">
            <a href="javascript:void(0)" data-target=".contact-mobile">
                <img class="img-fluid" src="/images/phone.svg">
                <span>Contact</span> </a>
        </div>
        <div class="col-3">
            <a href="javascript:void(0)" data-target=".menu-mobile">
                <img class="img-fluid" src="/images/bars.svg">
                <span>Menu</span> </a>
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
                    
                    <div class="search-course">
                        <uc1:search ID="search1" runat="server" />
                    </div>
                    
                </div>
                <div class="course-list">
                    <a href="" class="bg-prime-dark">Undergraduate Programs <span class="btn btn-circle btn-prime">
                        <img class="img-fluid" src="/images/right-angle-white.svg"></span></a> <a href=""
                            class="bg-red">Postgraduate Programs <span class="btn btn-circle btn-prime">
                                <img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
                    <a href="" class="bg-text">Ph.D Programs <span class="btn btn-circle btn-prime">
                        <img class="img-fluid" src="/images/right-angle-white.svg"></span></a> <a href=""
                            class="bg-yellow">View All Programs <span class="btn btn-circle btn-prime">
                                <img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
                </div>
            </div>
        </div>
    </div>
    <div class="drop-menu admission-mobile">
        <div class="container">
            <div class="drop-menu-inner">
                <span class="drop-menu-heading">Admission 2023</span>
                <div class="top-box text-center">
                    <a href="">Admission Process</a> <a href="">Eligibility</a> <a href="">Required Documents</a>
                    <a href="">Admission Enquiry Form</a> <a href="">Payment Procedure</a> <a href="">Scholarships</a>
                </div>
                <div class="course-list">
                    <a href="" class="bg-yellow justify-content-center">APPLY NOW<span class="btn btn-circle btn-prime"><img
                        class="img-fluid" src="/images/right-angle-white.svg"></span></a>
                </div>
                <div class="menu-contact">
                    <img src="/images/icon-feather-phone.svg" alt="phone" class="img-fluid">
                    <span class="c-heading">Admission Helpline</span>
                    <p>
                        <a href="tel: +91 253 2516671">+91 253 2516671</a></p>
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
                    <a href="tel: +91 253 2512876">+91 253 2512876</a> <a href="tel: +91 253 2512867">+91
                        253 2512867</a>
                </div>
                <div class="menu-contact">
                    <img src="/images/icon-feather-mail.svg" alt="mail" class="img-fluid">
                    <a href="mailto: kkwieer@kkwagh.edu.in">kkwieer@kkwagh.edu.in</a> <a href="mailto: kkwe_office@dataone.in">
                        kkwe_office@dataone.in</a>
                </div>
                <div class="menu-contact">
                    <img src="/images/icon-material-place.svg" alt="place" class="img-fluid">
                    <p class="text-center">
                        Hirabai Haridas Vidyanagari, Amrutdham, Panchavati, Nashik – 422003</p>
                </div>
                <div class="course-list">
                    <a href="" class="bg-yellow justify-content-center">
                        <img class="img-fluid" src="/images/icon-chat.svg">Chat Now</a>
                </div>
            </div>
        </div>
    </div>
    <div class="drop-menu menu-mobile">
        <div class="container">
            <div class="drop-menu-inner">
                <div class="main-menus">
                   <!--  <asp:Repeater ID="rptmobilemenu" runat="server" OnItemDataBound="rptmobilemenu_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                            <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                            <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                            <a id="ank" runat="server">
                                <%#Eval("linkname")%></a>
                        </ItemTemplate>
                    </asp:Repeater> -->
                
<div class="accordion" id="accordionExample">
<div class="accordion-item">
<div class="accordion-header" id="headingOne">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
About Us
</button>
</div>
<div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
<div class="accordion-body">

<div class="accordion" id="sub-accordionExample">

<div class="accordion-item">
<div class="accordion-header" id="sub-headingOne">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-collapseOne" aria-expanded="false" aria-controls="collapseOne">About Institute

</button>
</div>
    <div id="sub-collapseOne" class="accordion-collapse collapse" aria-labelledby="sub-headingOne" data-bs-parent="#sub-accordionExample">
        <div class="accordion-body">
            <div class="accordion" id="sub-leadership">
                <div class="accordion-item">
                <a href="/engineering/cpage.aspx?mpgid=76&pgid1=114&pgidtrail=121">Overview</a>
                <a href="/engineering/cpage.aspx?mpgid=76&pgid1=114&pgidtrail=123">Organization Structure</a>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="accordion-item">
<a href="/engineering/cpage.aspx?mpgid=76&pgidtrail=115">Director's Desk</a>
</div>

<div class="accordion-item">
<div class="accordion-header" id="sub-headingTwo">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Deans

</button>
</div>
<div id="sub-collapseTwo" class="accordion-collapse collapse" aria-labelledby="sub-headingTwo" data-bs-parent="#sub-accordionExample">
<div class="accordion-body">
<div class="accordion" id="sub-leadership">
<div class="accordion-item">
<a href="/engineering/cpage.aspx?mpgid=76&pgid1=116&pgidtrail=124">Administration</a>
<a href="/engineering/cpage.aspx?mpgid=76&pgid1=116&pgidtrail=125">Academics</a>
<a href="/engineering/cpage.aspx?mpgid=76&pgid1=116&pgidtrail=126">Quality</a>
<a href="/engineering/cpage.aspx?mpgid=76&pgid1=116&pgidtrail=127">Research</a>
<a href="/engineering/cpage.aspx?mpgid=76&pgid1=116&pgidtrail=128">Student Affairs</a>
</div>
</div>
</div>
</div>
</div>

<div class="accordion-item">
<div class="accordion-header" id="sub-headingFour">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-collapseFour" aria-expanded="false" aria-controls="collapseFour">K.K. Wagh Education Society
</button>
</div>
<div id="sub-collapseFour" class="accordion-collapse collapse" aria-labelledby="sub-headingFour" data-bs-parent="#sub-accordionExample">
<div class="accordion-body">
<div class="accordion" id="sub-leadership">
<div class="accordion-item">
<a href="/engineering/cpage.aspx?mpgid=76&pgid1=117&pgidtrail=129">Chairman's Message</a>
<a href="/engineering/board-of-directors.aspx?mpgid=76&pgid1=117&pgidtrail=130">Board of Directors</a>
<a href="/engineering/advisory.aspx?mpgid=76&pgid1=117&pgidtrail=131">Advisory Committee</a>
<a href="/engineering/cpage.aspx?mpgid=76&pgid1=117&pgidtrail=132">Golden Jubilee</a>

</div>
</div>
</div>
</div>
</div>

<div class="accordion-item">
<a href="/engineering/cpage.aspx?mpgid=76&pgidtrail=118">Governing Body</a>
</div>


<div class="accordion-item">
<div class="accordion-header" id="sub-headingFive">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-collapseFive" aria-expanded="false" aria-controls="collapseFive">Recognitions and Achievements
</button>
</div>
<div id="sub-collapseFive" class="accordion-collapse collapse" aria-labelledby="sub-headingFive" data-bs-parent="#sub-accordionExample">
<div class="accordion-body">
<div class="accordion" id="sub-leadership">
<div class="accordion-item">
<a href="/engineering/cpage.aspx?mpgid=76&pgid1=119&pgidtrail=155">Institute</a>
<a href="/engineering/cpage.aspx?mpgid=76&pgid1=119&pgidtrail=156">Student</a>


</div>
</div>
</div>
</div>
</div>

<div class="accordion-item">
<a href="/engineering/cpage.aspx?mpgid=76&pgidtrail=120">Mandatory Disclosure</a>
</div>

<!--  <div class="accordion-item">
<div class="accordion-header" id="sub-heading2">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-collapse2" aria-expanded="false" aria-controls="collapse2">
Accordion Item #1
</button>
</div>
<div id="sub-collapse2" class="accordion-collapse collapse" aria-labelledby="sub-heading2" data-bs-parent="#sub-accordionExample">
<div class="accordion-body">
<strong>This is the first item's accordion body.</strong> It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
</div>
</div>
</div> -->
</div>
</div>
</div>

</div>


<div class="accordion-item">
<div class="accordion-header" id="headingThreeFacilities">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThreeFacilities" aria-expanded="false" aria-controls="collapseThreeFacilities">Academics
</button>
</div>
<div id="collapseThreeFacilities" class="accordion-collapse collapse" aria-labelledby="headingThreeFacilities" data-bs-parent="#accordionExample">
<div class="accordion-body">
<a href="/engineering/faculty.aspx?mpgid=77&pgidtrail=147">Faculty</a>
<a href="/engineering/cpage.aspx?mpgid=77&pgidtrail=148">Academic Calendar</a>
<a href="/engineering/cpage.aspx?mpgid=77&pgidtrail=149">Examination</a>
</div>
</div>
</div>

<div class="accordion-item">
<div class="accordion-header" id="headingOneFacilities">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOneFacilities" aria-expanded="false" aria-controls="collapseOneFacilities">Facilities

</button>
</div>
<div id="collapseOneFacilities" class="accordion-collapse collapse" aria-labelledby="headingOneFacilities" data-bs-parent="#accordionExample">
<div class="accordion-body">

<div class="accordion" id="sub-accordionFacilities">

<div class="accordion-item">
<div class="accordion-body">
<a href="/engineering/cpage.aspx?mpgid=79&pgidtrail=109">Hostel Facilities</a>
<a href="/engineering/cpage.aspx?mpgid=79&pgidtrail=110">Campus Facilities</a>
<a href="/engineering/cpage.aspx?mpgid=79&pgidtrail=111">Health Facilities</a>
</div>
</div>

<div class="accordion-item">
<div class="accordion-header" id="sub-headingTwoFacilitiesFacilities">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-collapseTwoFacilities" aria-expanded="false" aria-controls="sub-collapseTwoFacilities">Beyond Academics</button>
</div>
<div id="sub-collapseTwoFacilities" class="accordion-collapse collapse" aria-labelledby="sub-headingTwoFacilities" data-bs-parent="#sub-accordionFacilities">
<div class="accordion-body">
<a href="/engineering/cpage.aspx?mpgid=79&pgid1=112&pgidtrail=137">NSS</a>
<a href="/engineering/cpage.aspx?mpgid=79&pgid1=112&pgidtrail=142">Prayas Student's NGO</a>
<a href="/engineering/cpage.aspx?mpgid=79&pgid1=112&pgidtrail=145">Clubs</a>
<a href="/engineering/cpage.aspx?mpgid=79&pgid1=112&pgidtrail=144">Student Chapter</a>
</div>
</div>
</div>


<div class="accordion-item">
<div class="accordion-body">
<a href="/engineering/cpage.aspx?mpgid=79&pgidtrail=134">Transport Facilities</a>
<a href="/engineering/cpage.aspx?mpgid=79&pgidtrail=135">Sports Facilities</a>
<a href="/engineering/cpage.aspx?mpgid=79&pgidtrail=139">Innovation Center</a>
<a href="/engineering/cpage.aspx?mpgid=79&pgidtrail=157">Centre of Excellence</a>
</div>
</div>


</div>
</div>
</div>

</div>
<div class="accordion-item">
<a href="/engineering/careers.aspx?mpgid=80&pgidtrail=80">Careers</a>
</div>

<div class="accordion-item">
<div class="accordion-header" id="headingTwoFacilities">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwoFacilities" aria-expanded="false" aria-controls="collapseTwoFacilities">Admissions
</button>
</div>
<div id="collapseTwoFacilities" class="accordion-collapse collapse" aria-labelledby="headingTwoFacilities" data-bs-parent="#accordionExample">
<div class="accordion-body">
<div class="accordion" id="sub-accordionlife">


<div class="accordion-item">
<div class="accordion-body">
<a href="/engineering/cpage.aspx?mpgid=81&pgidtrail=177">Overview</a>
</div>
</div>

    <div class="accordion-item">
        <div class="accordion-header" id="sub-headinglifeTwo">
        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-lifeTwo" aria-expanded="false" aria-controls="sub-lifeTwo">Admission Process </button>
        </div>
        <div id="sub-lifeTwo" class="accordion-collapse collapse" aria-labelledby="sub-headinglifeTwo" data-bs-parent="#sub-accordionlife">
            <div class="accordion-body">
            <a href="/engineering/cpage.aspx?mpgid=81&pgid1=178&pgidtrail=181">First Year Under Graduate (B.Tech)</a>
            <a href="/engineering/cpage.aspx?mpgid=81&pgid1=178&pgidtrail=182">Direct Second Year Under Graduate (Lateral Entry) </a>
            <a href="/engineering/cpage.aspx?mpgid=81&pgid1=178&pgidtrail=183">M.Tech Post Graduate </a>
            <a href="/engineering/cpage.aspx?mpgid=81&pgid1=178&pgidtrail=184">MBA Post Graduate </a>            
            <a href="/engineering/cpage.aspx?mpgid=81&pgid1=178&pgidtrail=185">MCA Post Graduate</a>
            <a href="/engineering/cpage.aspx?mpgid=81&pgid1=178&pgidtrail=186">Ph.D </a>
            </div>
        </div>
    </div>
    
    <div class="accordion-item">
<div class="accordion-body">
<a href="/engineering/pdf/kkwagh_engineering_prospectus2023-24final_compressed.pdf" target="_blank">Admission Brochure 2023-24</a>
<a href="/engineering/cpage.aspx?mpgid=81&pgidtrail=180">Admission FAQs</a>
</div>
</div>
    
    
</div>
</div>
</div>
</div>

</div>
</div>


                <div class="secondary-menus">
                    <a href="/engineering/cpage.aspx?mpgid=86&pgidtrail=86">Student Corner</a> 
                    <a href="/engineering/media.aspx?mpgid=105&pgidtrail=105">Media</a> 
                    <a href="/engineering/testimonials.aspx?mpgid=93&pgidtrail=93&tesid=1"> Testimonials</a> 
                    <a href="/engineering/contact.aspx?mpgid=94&pgidtrail=94">Contact</a>                   
                    <a href="/engineering/cpage.aspx?mpgid=82&pgidtrail=82">ERP Login</a>
                </div>
            </div>
        </div>
    </div>
</div>
