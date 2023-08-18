<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/department.master"
    AutoEventWireup="true" CodeFile="newsdept.aspx.cs" Inherits="engineering_newsdept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="happening-list news-list top-section">
            <div class="container" runat="server" visible="false">
                <div class="form">
                    <div class="row justify-content-center gx-3 gy-3">
                        <div class="col-xl-3 col-md-4 col-6">
                            <div class="form-group">
                              <asp:DropDownList ID="ddlmonth" runat="server" class="form-select" OnSelectedIndexChanged="ddlmonthselect" AutoPostBack="true">
                                 <asp:ListItem Value="0">Select Month</asp:ListItem>
                                 <asp:ListItem Value="1">January</asp:ListItem>
                                 <asp:ListItem Value="2">February</asp:ListItem>
                                 <asp:ListItem Value="3">March</asp:ListItem>
                                 <asp:ListItem Value="4">April</asp:ListItem>
                                 <asp:ListItem Value="5">May</asp:ListItem>
                                 <asp:ListItem Value="6">June</asp:ListItem>
                                 <asp:ListItem Value="7">July</asp:ListItem>
                                 <asp:ListItem Value="8">August</asp:ListItem>
                                 <asp:ListItem Value="9">September</asp:ListItem>
                                 <asp:ListItem Value="10">October</asp:ListItem>
                                 <asp:ListItem Value="11">November</asp:ListItem>
                                 <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-4 col-6 ">
                            <div class="form-group">
                                 <asp:DropDownList ID="ddlyear" runat="server" class="form-select" OnSelectedIndexChanged="ddlyearselect" AutoPostBack="true">                                                                  
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-4 col-sm-6">
                            <div class="form-group">
                            <asp:DropDownList ID="ddlcollage" runat="server" class="form-select" OnSelectedIndexChanged="ddlcollageselect" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-4 col-sm-6">
                            <div class="form-group">
                            <asp:DropDownList ID="ddltype" runat="server" class="form-select" OnSelectedIndexChanged="ddltypeselect" AutoPostBack="true"></asp:DropDownList>
                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container max-content-xl">
            <asp:Repeater ID="rptnewstop" runat="server" OnItemDataBound="rptnewstop_OnItemDataBound">
            <ItemTemplate>
            <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid")%>' Visible="false"></asp:Literal>
            <a id="ank" runat="server" class="featured-news">
                    <div class="row gx-0">
                        <div class="col-xl-11">
                            <div class="row gx-0 gx-lg-3">
                                <div class="col-xl-8">
                                    <figure class="mb-0">
                                        <img src="/uploads/SmallImages/<%#Eval("uploadevents")%>" class="img-fluid" alt="featured">
                                    </figure>
                                </div>
                                <div class="col-xl-4">
                                    <div class="news-text">
                                        <span class="timing"><%#Eval("eventsdate","{0:MMM dd, yyyy}")%></span>
                                        <span class="news-title"><%#Eval("eventstitle")%></span>
                                        <span class="news-desc"><%#Server.HtmlDecode(Eval("shortdesc").ToString()).Replace("<p>","").Replace("</p>","")%></span>
                                        <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
            </asp:Repeater>
                
            </div>
            <div class="other-news">
                <div class="container">
                    <div class="row gx-4 gy-4">
                    <asp:Repeater ID="rptnewsevents" runat="server" OnItemDataBound="rptnewsevents_OnItemDataBound">
                    <ItemTemplate>
                     <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid")%>' Visible="false"></asp:Literal>
                     <asp:Literal ID="litcolorcode" runat="server" Text='<%#Eval("colorcode")%>' Visible="false"></asp:Literal>
                     <asp:Literal ID="lituploadevents" runat="server" Text='<%#Eval("uploadevents")%>' Visible="false"></asp:Literal>
                      <div class="col-lg-4 col-md-6">
                            <a id="ank" runat="server" class="happening-thumb with-image">
                                <figure id="fg1" runat="server">
                                    <img class="img-fluid" src="/uploads/SmallImages/<%#Eval("uploadevents")%>" alt="<%#Eval("eventsid")%>">
                                </figure>
                                <div class="happening-content">
                                     <span class="timing"><%#Eval("eventsdate","{0:MMM dd, yyyy}")%></span>
                                    <span class="happening-title"><%#Eval("eventstitle")%></span>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>                      
                    
                        <div class="col-12" id="panelloadmore" runat="server" visible="false">
                            <button type="button" class="btn btn-link view-more">View More <span class="btn btn-circle btn-prime"><img class="img-fluid" src="./images/right-angle-white.svg"></span></button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>
