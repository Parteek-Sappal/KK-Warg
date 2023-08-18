<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/Inner.master" AutoEventWireup="true"
    CodeFile="thankyou.aspx.cs" Inherits="thankyou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container thankyou">
        <div class="row">
            <div class="col-md-12">
                <h5>
                    <p class="text-center">
                        <asp:Label ID="lblsuccess" runat="server"></asp:Label></p>
                </h5>
                    <div class="row thank_you_page">
                        <div class="col-12 col-sm-12 col-md-12 offset-lg-4 col-lg-4">
                            <div class="apply tankyou_btn text-center">
                                <a class="submit-btn" href="/"> Continue to Homepage <img src="/images/arrow-2.svg" class="img-fluid" alt="home"></a>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
