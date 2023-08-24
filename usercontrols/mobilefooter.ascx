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
<a href="/cpage.aspx?mpgid=70&pgidtrail=70">
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
<a href="/course-list-group.aspx?mpgid=30&pgidtrail=30#course_listing" class="bg-prime-dark">Undergraduate Programs <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
<a href="/course-list-group.aspx?mpgid=30&pgidtrail=30&levelid=2#course_listing" class="bg-red">Postgraduate Programs <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
<a href="/course-list-group.aspx?mpgid=30&pgidtrail=30&levelid=3#course_listing" class="bg-text">Ph.D Programs <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
<a href="/course-list-group.aspx?mpgid=30&pgidtrail=30" class="bg-yellow">View All Programs <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></a>
</div>
</div>
</div>
</div>
<!-- <div class="drop-menu admission-mobile">
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
</div> -->
<div class="drop-menu contact-mobile">
<div class="container">
<div class="drop-menu-inner">
<span class="drop-menu-heading">Contact</span>
<div class="menu-contact">
<img src="/images/icon-feather-phone.svg" alt="phone" class="img-fluid">
<a href="tel: +912532512876" class="cta__number">+91 253 2512876</a>
<a href="tel: +912532512867" class="cta__number">+91 253 2512867</a>
</div>
<div class="menu-contact">
<img src="/images/icon-feather-mail.svg" alt="mail" class="img-fluid">
<a href="mailto: kkwieer@kkwagh.edu.in" class="cta__email">kkwieer@kkwagh.edu.in</a>
<a href="mailto: kkwe_office@dataone.in" class="cta__email">kkwe_office@dataone.in</a>
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
<!-- <asp:Repeater ID="rptmobilemenu" runat="server" OnItemDataBound="rptmobilemenu_ItemDataBound">
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
About KK Wagh
</button>
</div>
<div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
<div class="accordion-body">

<div class="accordion" id="sub-accordionExample">
<div class="accordion-item">
<a href="/cpage.aspx?mpgid=2&pgidtrail=187">Overview</a>
<a href="/cpage.aspx?mpgid=2&pgidtrail=4">Milestones</a>
<a href="/cpage.aspx?mpgid=2&pgidtrail=5">Our Legacy</a>
<a href="/cpage.aspx?mpgid=2&pgidtrail=6">Our Inspiration</a>
</div>
<div class="accordion-item">
<div class="accordion-header" id="sub-headingOne">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-collapseOne" aria-expanded="false" aria-controls="collapseOne">Our Leadership / About Chairman

</button>
</div>
<div id="sub-collapseOne" class="accordion-collapse collapse" aria-labelledby="sub-headingOne" data-bs-parent="#sub-accordionExample">
<div class="accordion-body">
<div class="accordion" id="sub-leadership">
<div class="accordion-item">
<a href="/cpage.aspx?mpgid=2&pgid1=9&pgidtrail=188">Hon. Chairman's Profile</a>
<a href="/cpage.aspx?mpgid=2&pgid1=9&pgidtrail=189">Hon. Chairman's Message</a>
</div>
</div>
</div>
</div>
</div>
<div class="accordion-item">
<a href="/cpage.aspx?mpgid=2&pgidtrail=10">People and Messages</a>
<a href="/board-of-directors.aspx?mpgid=2&pgidtrail=11">Board Of Directors</a>
<a href="/advisory.aspx?mpgid=2&pgidtrail=12">Advisory Committee</a>
<a href="/cpage.aspx?mpgid=2&pgidtrail=13">Accreditation & Rankings</a>
<a href="/cpage.aspx?mpgid=2&pgidtrail=15">Sponsored Awards</a>
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
<div class="accordion-header" id="headingThree">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
Infrastructure
</button>
</div>
<div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#accordionExample">
<div class="accordion-body">
<div class="accordion" id="sub1-accordionExample">
<div class="accordion-item">
<div class="accordion-header" id="sub1-headingOne">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub1-collapseOne" aria-expanded="false" aria-controls="collapse1One">Campuses

</button>
</div>
<div id="sub1-collapseOne" class="accordion-collapse collapse" aria-labelledby="sub1-headingOne" data-bs-parent="#sub1-accordionExample">
<div class="accordion-body">
<a href="/cpage.aspx?mpgid=214&pgidtrail=213">Nashik City</a>
<a href="/cpage.aspx?mpgid=214&pgidtrail=214">Niphad Tehsil</a>
<a href="/cpage.aspx?mpgid=219&pgidtrail=219">Upcoming</a>

</div>
</div>
</div>
<div class="accordion-item">
<div class="accordion-header" id="sub2-heading2">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub2-collapse2" aria-expanded="false" aria-controls="collapse22">Agri Farms
</button>
</div>
<div id="sub2-collapse2" class="accordion-collapse collapse" aria-labelledby="sub2-heading2" data-bs-parent="#sub1-accordionExample">
<div class="accordion-body">
<a href="/cpage.aspx?mpgid=218&pgidtrail=218#makhamalabad">Makhamalabad</a>
<a href="/cpage.aspx?mpgid=218&pgidtrail=218#kasbe">Kasbe-Sukene</a>
<a href="/cpage.aspx?mpgid=218&pgidtrail=218#vilholi">Vilholi</a>
<a href="/cpage.aspx?mpgid=218&pgidtrail=218#puriya">Puriya Park</a>
<a href="/cpage.aspx?mpgid=218&pgidtrail=218#shivangaon">Shivangaon</a>
<a href="/cpage.aspx?mpgid=218&pgidtrail=218#babhleshwar">Babhleshwar</a>
</div>
</div>
</div>
</div>
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
<div class="accordion-header" id="sub-headingOneFacilities">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-collapseOneFacilities" aria-expanded="false" aria-controls="collapseOneFacilities">Academic Facilities
</button>
</div>
<div id="sub-collapseOneFacilities" class="accordion-collapse collapse" aria-labelledby="sub-headingOneFacilities" data-bs-parent="#sub-accordionFacilities">
<div class="accordion-body">
<a href="/cpage.aspx?mpgid=22&pgid1=23&pgidtrail=165">Innovation Center</a>
<a href="/cpage.aspx?mpgid=22&pgid1=23&pgidtrail=202">Engineering Workshop</a>
<a href="/cpage.aspx?mpgid=22&pgidtrail=201">Training & Placement Cell</a>
<a href="/cpage.aspx?mpgid=22&pgid1=23&pgidtrail=164">Kusumagraj Central Library</a>
<a href="/cpage.aspx?mpgid=22&pgid1=23&pgidtrail=203">ERP</a>
<a href="/cpage.aspx?mpgid=22&pgid1=23&pgidtrail=207">Classrooms</a>
<a href="/cpage.aspx?mpgid=22&pgid1=23&pgidtrail=204">Laborataries</a>
<a href="/cpage.aspx?mpgid=22&pgid1=23&pgidtrail=208">Auditorium/Seminar Halls</a>
<a href="/cpage.aspx?mpgid=205&pgidtrail=205">E-Resources</a>
<a href="/cpage.aspx?mpgid=22&pgid1=23&pgidtrail=209">Kala Academy</a>
<a href="/cpage.aspx?mpgid=22&pgid1=23&pgidtrail=206">GRE-TOEFL, IELTS Exam Center</a>
</div>
</div>
</div>
<div class="accordion-item">
<div class="accordion-header" id="sub-headingTwoFacilitiesFacilities">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-collapseTwoFacilities" aria-expanded="false" aria-controls="sub-collapseTwoFacilities">Sports Facilities</button>
</div>
<div id="sub-collapseTwoFacilities" class="accordion-collapse collapse" aria-labelledby="sub-headingTwoFacilities" data-bs-parent="#sub-accordionFacilities">
<div class="accordion-body">
<a href="/cpage.aspx?mpgid=22&pgid1=24&pgidtrail=212">Overview</a>
<a href="/cpage.aspx?mpgid=22&pgid1=24&pgidtrail=215">K K Wagh College of Education</a>
<a href="/cpage.aspx?mpgid=22&pgidtrail=216">K K Wagh Schools</a>
<a href="/cpage.aspx?mpgid=22&pgid1=24&pgidtrail=217">K.K.Wagh Arts, Commerce, Science & Computer Science College</a>
<a href="/cpage.aspx?mpgid=22&pgid1=24&pgidtrail=220">K K Wagh Agriculture & Allied Colleges</a>
</div>
</div>
</div>
<div class="accordion-item">
<div class="accordion-body">
<a href="/cpage.aspx?mpgid=22&pgidtrail=25">Medical Facilities</a>
<a href="/cpage.aspx?mpgid=22&pgidtrail=26">Transport Facilities</a>
<a href="/cpage.aspx?mpgid=22&pgidtrail=27">Hostel Facilities</a>
<a href="/cpage.aspx?mpgid=22&pgidtrail=28">Services</a>
<a href="/cpage.aspx?mpgid=22&pgidtrail=29">Other Facilities</a>
</div>
</div>
</div>
</div>
</div>

</div>
<div class="accordion-item">
<a href="/course-list-group.aspx?mpgid=30&pgidtrail=30">Courses</a>
</div>
<div class="accordion-item">
<div class="accordion-header" id="headingTwoFacilities">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwoFacilities" aria-expanded="false" aria-controls="collapseTwoFacilities">Life@KKWagh
</button>
</div>
<div id="collapseTwoFacilities" class="accordion-collapse collapse" aria-labelledby="headingTwoFacilities" data-bs-parent="#accordionExample">
<div class="accordion-body">
<div class="accordion" id="sub-accordionlife">
<div class="accordion-item">
<div class="accordion-header" id="sub-headinglifeOne">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-lifeOne" aria-expanded="false" aria-controls="collapseLifeOne">Happenings

</button>
</div>
<div id="sub-lifeOne" class="accordion-collapse collapse" aria-labelledby="sub-headinglifeOne" data-bs-parent="#sub-accordionlife">
<div class="accordion-body">
<a href="/news-list.aspx?mpgid=31&pgid1=32&pgidtrail=34">Events</a>
<a href="/cpage.aspx?mpgid=31&pgid1=32&pgidtrail=35">Industry Linkage</a>
<a href="/cpage.aspx?mpgid=31&pgid1=32&pgidtrail=36">Community Engagement</a>
<a href="/cpage.aspx?mpgid=31&pgid1=32&pgidtrail=37">Dignitary Visits</a>
<a href="/media.aspx?mpgid=31&pgid1=32&pgidtrail=38&typeid=0">Media Coverage</a>
<a href="/press-release.aspx?mpgid=31&pgid1=32&pgidtrail=74">Press-Release</a>
</div>
</div>
</div>
<div class="accordion-item">
<div class="accordion-header" id="sub-headinglifeTwo">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sub-lifeTwo" aria-expanded="false" aria-controls="sub-lifeTwo">Beyond Academics </button>
</div>
<div id="sub-lifeTwo" class="accordion-collapse collapse" aria-labelledby="sub-headinglifeTwo" data-bs-parent="#sub-accordionlife">
<div class="accordion-body">
<a href="/cpage.aspx?mpgid=31&pgid1=39&pgidtrail=40">Tree Plantation</a>
<a href="/cpage.aspx?mpgid=31&pgid1=39&pgidtrail=41">Clubs </a>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<div class="accordion-item">
<div class="accordion-header" id="headingThreeFacilities">
<button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThreeFacilities" aria-expanded="false" aria-controls="collapseThreeFacilities">Placement
</button>
</div>
<div id="collapseThreeFacilities" class="accordion-collapse collapse" aria-labelledby="headingThreeFacilities" data-bs-parent="#accordionExample">
<div class="accordion-body">
<a href="/cpage.aspx?mpgid=44&pgidtrail=45">Overview</a>
<a href="/cpage.aspx?mpgid=44&pgidtrail=46">Career Counseling</a>
<a href="/cpage.aspx?mpgid=44&pgidtrail=47">Placement Policy</a>
<a href="/cpage.aspx?mpgid=44&pgidtrail=48">Placement Records</a>
<a href="/cpage.aspx?mpgid=44&pgidtrail=49">Student Development</a>
<a href="/cpage.aspx?mpgid=44&pgidtrail=50">Our Recruiters</a>
<a href="/cpage.aspx?mpgid=44&pgidtrail=55">Career Academy</a>
<a href="/cpage.aspx?mpgid=44&pgidtrail=56">Placement Gallery</a>
<a href="/cpage.aspx?mpgid=44&pgidtrail=58&tesid=6">FAQ's</a>
</div>
</div>
</div>
</div>
</div>
<div class="secondary-menus">
<a href="/contact.aspx?mpgid=64&pgidtrail=64">Contact</a>
<a href="/careers.aspx?mpgid=69&pgidtrail=69">Careers</a>
<a href="https://erp.kkwagh.edu.in/" target="_blank">ERP Login</a>
</div>
</div> 
</div>				

</div>

</div>


<script>
var collapseElementList = [].slice.call(document.querySelectorAll('.collapse'))
var collapseList = collapseElementList.map(function (collapseEl) {
collapseEl.addEventListener('hidden.bs.collapse', function () {
let children = this.querySelectorAll('.collapse.show');
children.forEach((c)=>{
var collapse = bootstrap.Collapse.getInstance(c)
collapse.hide()
})
})
})
</script>