<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="story-detail.aspx.cs" Inherits="engineering_story_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="top-section">
    <asp:Repeater ID="rprdetail" runat="server">
    <ItemTemplate>
       <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid")%>' Visible="false"></asp:Literal>
    <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <figure class="mb-0">
                        <img src="/uploads/largeimages/<%#Eval("largeimage")%>" class="img-fluid w-100" alt="<%#Eval("eventsid")%>">
                    </figure>
                </div>
              <%#Server.HtmlDecode(Eval("shortdesc").ToString())%>
            </div>
        <%#Server.HtmlDecode(Eval("eventsdesc").ToString())%>
        </div>
    </ItemTemplate>
    </asp:Repeater>
        
    </section>
</asp:Content>

