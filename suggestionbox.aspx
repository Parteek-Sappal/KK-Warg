<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="suggestionbox.aspx.cs" Inherits="suggestionbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function RefreshCaptchanew() {
            var img = document.getElementById("imgCaptchanew");
            img.src = "/Handler.ashx?query=" + Math.random();
        }
    </script>
    <section class="suggestion-box contact-us">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group required">
                        <div class="input-group">
                            <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Name*"
                                autocomplete="none"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname"
                                Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server"
                                Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight1"
                                CssClass="BlockPopup" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group required">
                        <div class="input-group">
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
                                CssClass="BlockPopup" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group required">
                        <div class="input-group">
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
                                CssClass="BlockPopup" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group required">
                        <div class="input-group">
                            <asp:TextBox ID="txttitle" runat="server" class="form-control" placeholder="Title*"
                                autocomplete="none"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttitle"
                                Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight1"
                                CssClass="BlockPopup" />
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group required">
                        <div class="input-group">
                            <asp:TextBox ID="txtmsg" runat="server" class="form-control" placeholder="Description*"
                                autocomplete="none"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmsg"
                                Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
                                Enabled="true" TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight1"
                                CssClass="BlockPopup" />
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group required">
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
                                <div style="margin-left: 10%; margin-top: 10%;">
                                    <asp:Label ID="lblmsg" runat="server" CssClass="notic-box" Text="Captcha Incorrect."
                                        Visible="false"></asp:Label>
                                </div>

                            </figure>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-md-offset-4">
                    <asp:Button ID="btnsubmit" runat="server" class="btn btn-prime px-5" Text="Submit" ValidationGroup="validcontact" OnClick="btnsubmit_Click" />
                </div>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderbot2" runat="Server">
</asp:Content>

