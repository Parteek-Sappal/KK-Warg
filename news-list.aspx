<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="news-list.aspx.cs" Inherits="news_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section class="inner-title">
            <div class="container">
                <div class="section-heading text-center">
                    <h1 class="section-title"><%--<asp:Literal ID="litntype" runat="server"></asp:Literal>--%></h1>
                </div>
            </div>
        </section>
        <section class="happening-list news-list top-section">
            <div class="container">
                <div class="form">
                    <div class="row justify-content-center gx-3 gy-3">
                        <div class="col-xl-3 col-md-4 col-6">
                            <div class="form-group">
                    <asp:DropDownList ID="month" runat="server" class="form-select" OnSelectedIndexChanged="month_OnSelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Month</asp:ListItem>
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
                    <asp:DropDownList ID="year" runat="server" class="form-select" OnSelectedIndexChanged="year_OnSelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Year</asp:ListItem>
                    <asp:ListItem Value="2023">2023</asp:ListItem>
                    <asp:ListItem Value="2022">2022</asp:ListItem>
                    <asp:ListItem Value="2021">2021</asp:ListItem>
                    <asp:ListItem Value="2020">2020</asp:ListItem>
                    </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-4 col-sm-6">
                            <div class="form-group">
                                <select class="form-select" name="college">
                                    <option value="">Select College</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-4 col-sm-6">
                            <div class="form-group">
<%--                                <select class="form-select" name="type">
                                    <option value="">Type</option>
                                </select>
--%>                            
                            <asp:DropDownList ID="newstype" runat="server" class="form-select" OnSelectedIndexChanged="newstype_OnSelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container max-content-xl">
                <asp:Repeater ID="rptmainnews" runat="server" OnItemDataBound="rptmainnews_OnItemDataBound">
                <ItemTemplate>
                <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("eventsid")%>' Visible="false"></asp:Literal>
            <asp:Literal ID="litntyepid" runat="server" Text='<%#Eval("ntypeid")%>' Visible="false"></asp:Literal>
                <a  id="ank" runat="server" class="featured-news">
                    <div class="row gx-0">
                        <div class="col-xl-11">
                            <div class="row gx-0 gx-lg-3">                            
                            <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid") %>' Visible="false"></asp:Literal>
                                <div class="col-xl-8">
                                    <figure class="mb-0">
                                        <img src="/uploads/smallimages/<%#Eval("uploadevents") %>" class="img-fluid" alt="featured">
                                    </figure>
                                </div>
                                <div class="col-xl-4">
                                    <div class="news-text">
                                        <span class="timing"><%#Eval("Eventsdate","{0:MMM dd, yyyy}")%></span>
                                        <span class="news-title"><%#Eval("eventstitle")%></span>
                                        <span class="news-desc" ><%#Server.HtmlDecode(Eval("shortdesc").ToString()).Replace("<p>", "").Replace("</p>", "")%></span>
                                        <span class="btn btn-circle btn-prime"><img class="img-fluid" src="./images/right-angle-white.svg"></span>
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

                        <asp:Repeater ID="rptothernews" runat="server" OnItemDataBound="rptothernews_OnItemDataBound">
                        <ItemTemplate>      
                        <asp:Literal ID="litimg" runat="server" Text='<%#Eval("uploadevents") %>' Visible="false"></asp:Literal>
                        <asp:Literal ID="liteventsid" runat="server" Text='<%#Eval("eventsid")%>' Visible="false"></asp:Literal>
                        <asp:Literal ID="litntyepid" runat="server" Text='<%#Eval("ntypeid")%>' Visible="false"></asp:Literal>
                        <asp:Literal ID="litcolorcode" runat="server" Text='<%#Eval("colorcode") %>' Visible="false"></asp:Literal>                 
                        <div id="divwithimage" runat="server" class="col-lg-4 col-md-6" visible="true">
                            <a id="ank1" runat="server" class="happening-thumb with-image">
                                <figure>
                                    <img class="img-fluid" src="/uploads/smallimages/<%#Eval("uploadevents") %>" alt="<%#Eval("eventstitle")%>">
                                </figure>
                                <div class="happening-content">
                                    <span class="timing"><%#Eval("Eventsdate", "{0:MMM dd, yyyy}")%></span>
                                    <span class="happening-title"><%#Eval("eventstitle")%></span>
                                </div>
                            </a>
                        </div>
                        <div id="divwithoutimage" runat="server" class="col-lg-4 col-md-6" visible="false">
                            <a id="ank" runat="server" class="happening-thumb bg-prime-dark">
                                <div class="happening-content" id="panel1" runat="server">
                                    <span class="timing"><%#Eval("Eventsdate", "{0:MMM dd, yyyy}")%></span>
                                    <span class="happening-title"><%#Eval("eventstitle")%></span>
                                    <span class="happening-desc" ><%#Server.HtmlDecode(Eval("shortdesc").ToString()).Replace("<p>", "").Replace("</p>", "")%></span>
                                    <span class="btn btn-circle"><img class="img-fluid" src="./images/right-angle-white.svg"></span>
                                </div>
                            </a>
                        </div>
                        </ItemTemplate>
                        </asp:Repeater>
                        <div class="col-12" id="panelloadmore" runat="server" visible="false">
                            <button type="button" class="btn btn-link view-more">View More <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>

