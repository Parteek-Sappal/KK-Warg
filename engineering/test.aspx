<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="engineering_test" %>
<%@ Register Src="~/engineering/usercontrols/courselevelsearch.ascx" TagName="courselevelsearch" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<uc1:courselevelsearch ID="courselevelsearch1" runat="server" />--%>
<section class="home-academics">
<div class="container">
<div class="row gx-lg-5 gy-5">
<div class="col-lg-8">
<div class="home-academics_right-panel">
<div class="academics-programme">
<h6>Find a programme</h6>
<input type="text" id="myInput" class="form-control" onkeyup="myFunction()" placeholder="Find a programme (e.g. Computer Science)" title="Type in a course"/>
<ul id="myUL" class="form-control" style="display:none">
  <li><a href="#">Diploma in Agriculture Extension Service for Input Dealers </a></li>
  <li><a href="#">Diploma in Yoga </a></li>

  <li><a href="#">PH.D.(Ag.) Agronomy</a></li>
  <li><a href="#">MBA(Human Resource Management)</a></li>

  <li><a href="#">B.Sc. In Fire & Industrial Safety </a></li>
  <li><a href="#">Master of Science - Nursing</a></li>
  <li><a href="#">BCA-MCA Integrated </a></li>
</ul>
</div>
</div> 
</div> 
</div> 
</div> 
</section> 


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
</asp:Content>

