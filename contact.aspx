<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script type="text/javascript">
       function RefreshCaptchanew() {
           var img = document.getElementById("imgCaptchanew");
           img.src = "/Handler.ashx?query=" + Math.random();
       }
    </script>
<section class="contact-us top-section pb-lg-0">
	<div class="container">
		<div class="section-heading text-center">
			<h3 class="section-title">
				K. K. Wagh Education Society</h3>
			<p>
				<span>Admission Helpline</span><a href="tel: +91 253 2512876">+91 253 2512876</a></p>
		</div>
		<div class="row gy-5 gy-lg-0">			
            <asp:Literal ID="litsmalldesc" runat="server"></asp:Literal>
			<div class="col-xxl-3 col-lg-4">
				<div class="form bg-light">
					<div class="form-group required">
						   <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Name*"
                    autocomplete="none"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname"
                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server"
                    Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight1"
                    CssClass="BlockPopup" /></div>
					
                    <div class="form-group required">
						   <asp:TextBox ID="txtmobno" runat="server" MaxLength="10" class="form-control" placeholder="Mobile No.*"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" Display="None" Font-Size="Smaller"
                                    ErrorMessage="Enter Mobile No." ControlToValidate="txtmobno" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" Font-Size="Smaller"
                                Display="None" ErrorMessage="Enter Valid Mobile No." ControlToValidate="txtmobno"
                                ValidationGroup="validcontact" ValidationExpression="^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$"
                                runat="server" />
                            <ajaxToolkit:FilteredTextBoxExtender runat="server" ValidChars="Interger" FilterMode="ValidChars"
                                FilterType="Numbers" ID="filter_txtmobile" TargetControlID="txtmobno">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="server"
                                Enabled="true" TargetControlID="RequiredFieldValidator22" HighlightCssClass="validatorCalloutHighlight1"
                                CssClass="BlockPopup" />
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server"
                                Enabled="true" TargetControlID="RegularExpressionValidator12" HighlightCssClass="validatorCalloutHighlight1"
                                CssClass="BlockPopup" /></div>
				
                	<div class="form-group required">
					  <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="Email*"
                    autocomplete="none"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail"
                    Font-Size="Smaller" Display="None" ErrorMessage="Enter E-mail ID" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter Valid E-mail ID"
                    ControlToValidate="txtemail" ValidationGroup="validcontact" Display="None" Font-Size="Smaller"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                    Enabled="true" TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight1"
                    CssClass="BlockPopup" />
                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                    Enabled="true" TargetControlID="RegularExpressionValidator5" HighlightCssClass="validatorCalloutHighlight1"
                    CssClass="BlockPopup" /></div>

					<div class="form-group required">						
                        <asp:DropDownList ID="ddlcity" runat="server" class="form-select"></asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlcity" InitialValue="0"
                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
                    Enabled="true" TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight1"
                    CssClass="BlockPopup" />
                        </div>
					
                    <div class="form-group required">
						  <asp:TextBox ID="txtmsg" runat="server" class="form-control" placeholder="How can we help?*"
                    autocomplete="none"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmsg"
                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                    Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight1"
                    CssClass="BlockPopup" /></div>
					<div class="captcha">
						    <figure class="captcha_wrap">
							 <asp:TextBox ID="captcha" placeholder="Enter captcha code *" class="form-control"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="None"
                                ControlToValidate="captcha" ValidationGroup="contact1"></asp:RequiredFieldValidator>

                             <div class="captcha-colm">
                            <img src="/Handler.ashx" id="imgCaptchanew" alt="" />

                                <a class="refresh-capcha" href="javascript:void(0)" onclick="javascript:RefreshCaptchanew();">
                                <img src="/images/loader.png" alt="" class="cap-loader" /></a>

                                </div>
                                <div style="margin-left:10%; margin-top:10%;">
                                   <asp:Label ID="lblmsg" runat="server" CssClass="notic-box" Text="Captcha Incorrect."
                        Visible="false"></asp:Label></div>

						</figure>
                        </div>
					<div class="d-flex align-items-center mt-2">
						<div class="form-group required px-2 py-2 me-2">
							&nbsp;</div>
						<span class="small">Indicates mandatory fields</span></div>
					<div class="mt-4">
                      <asp:Button ID="btnsubmit" runat="server" class="btn btn-prime px-5" Text="Submit" ValidationGroup="validcontact" OnClick="btnsubmit_Click" />						
				</div>
			</div>
		</div>
	</div>
</section>
<asp:Literal ID="litpagedesc" runat="server"></asp:Literal>
      
</asp:Content>

