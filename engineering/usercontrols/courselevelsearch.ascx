<%@ Control Language="C#" AutoEventWireup="true" CodeFile="courselevelsearch.ascx.cs" Inherits="usercontrols_courselevelsearch" %>


<style>
.home-academics_right-panel .academics-programme.txtsearchnew ul.wordWheel {
    width: 100%;
    z-index: 1 !important;
    top: 13%;
}
ul.wordWheel {
	background-color: #fff;
	text-align: left;
	overflow-y: scroll;
	font-size: 12px;
	color: #000;
	vertical-align: top;
	margin: 0;
	height: 250px;
	padding: 0;
	border: 1px solid #dedede;
	cursor: pointer;
	position: absolute;
	width: 95%;
	z-index: 1;
	top: 42%;
}
ul.wordWheel li {
	list-style: none;
	padding:8px 10px;
	margin: 0;
	border-bottom: 1px solid #dedede;
	-webkit-transition: all 0.32s ease-out;
	-moz-transition: all 0.32s ease-out;
	-o-transition: all 0.32s ease-out;
	transition: all 0.32s ease-out;
}
ul.wordWheel li:hover {
	background: #73a9df;	
}

</style>

<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>


<script type="text/javascript">
    $(document).ready(function () {
        $('.close').click(function () {
            $("#clearmySound").attr('src', '');
        });
        $('.txtsearchnew').keyup(function () {

            Getmobileprogram11();
        });
        $('html').click(function () {
            $("#courselist4").attr("style", "display:none");
        });
    });
    function graduate3(e) {
        $("#txtcoursesearch11").val(e.text())
        $("#courselist4").attr("style", "display:none");
        document.all('<%=LinkButton5.ClientID  %>').click();
    }
    function SearchTerm1() {
        return jQuery.trim($("[id*=txtcoursesearch11]").val());
    };
    function Getmobileprogram11() {
        $.ajax({
            type: "POST",
            url: "/engineering/index.aspx/Getmobileprogram",
            data: '{prefixText: "' + SearchTerm1() + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {

            },
            error: function (response) {
                alert("Error : " + response.d);
            }
        });
    }
    var row;
    function OnSuccess(response) {
    
        var row = 0;
        var xmlDoc = $.parseXML(response.d);
        var xml = $(xmlDoc);
        var customers = xml.find("Customers");
        if (customers.length > 0) {
            $("#courselist4").removeAttr("style");
            $('#courselist4 li').remove();
            $.each(customers, function () {
            
                row = row + 1;
                var list = $("#courselist4");
               //  list.append('<li onClick="graduate3($(this))" id="' + row + '" >' + $(this).find("coursename").text() + '</li>');
                list.append('<li onClick="graduate3($(this))" id="' + row + '" ><a  href="' + $(this).find("urlgo").text() + '">' + $(this).find("coursename").text() + '</a></li>');
            });
        }
        else {
            $('#courselist4 li').remove();
            $("#courselist4").removeAttr("style");
            var list = $("#courselist4");
            list.append('<li id="' + row + '" >There are no programmes found.</li>');

        }
    };
   </script>

      <div class="academics-programme txtsearchnew pt-0">         
          <asp:TextBox  ID="txtcoursesearch11" runat="server" class="form-control"  placeholder="Find a programme (e.g. Computer Science)" autocomplete="off"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ErrorMessage="Required"
                                            ValidationGroup="csnew" ControlToValidate="txtcoursesearch11"></asp:RequiredFieldValidator>
                  <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server"
                                            TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight2"
                                            CssClass="BlockPopup" />
                 <ul id='courselist4' class="wordWheel listMain" style="display:none" onClick="check();">
                 </ul>        
          <asp:LinkButton ID="LinkButton5" CssClass="btn" ValidationGroup="csnew"  OnClick="LinkButton5_click"  runat="server" Visible="false"><img src="/images/search-icon.svg" alt="search-icon"></asp:LinkButton>
      </div>
      <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

  