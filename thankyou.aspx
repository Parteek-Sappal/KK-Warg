<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/Inner.master" AutoEventWireup="true"
    CodeFile="thankyou.aspx.cs" Inherits="thankyou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="thankyou">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h5 class="text-center mb-0">
                        <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                </h5>
                    <div class="row thank_you_page">
                        <div class="col-12 text-center">
                            <div class="apply tankyou_btn">
                                <a class="submit-btn" href="/"> Continue to Homepage </a>
                            </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>
