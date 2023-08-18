<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="press-release.aspx.cs" Inherits="engineering_press_release" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <section class="happening-list press-realese-list top-section">
            <div class="container">
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
                                <%--<select class="form-select" name="year">
                                    <option value="">Select Year</option>
                                </select>--%>
                                  <asp:DropDownList ID="ddlyear" runat="server" class="form-select" OnSelectedIndexChanged="ddlyearselect" AutoPostBack="true">                                                                  
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xl-3 col-md-4 col-6">
                            <div class="form-group">
                                 <asp:DropDownList ID="ddlcollage" runat="server" class="form-select" OnSelectedIndexChanged="ddlcollageselect" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container max-content-lg px-0">
                <div class="press-releases">
                    <div class="container">

                        <asp:Repeater ID="rptfile" runat="server" OnItemDataBound="rptfile_OnItemDataBound">
                        <ItemTemplate>
                        <asp:Literal ID="lituploadfile" runat="server" Text='<%#Eval("uploadfile") %>' Visible="false"></asp:Literal>
                        <a id="ank" runat="server" class="docs docs-grid">
                            <span class="timing"><%#Eval("eventsdate","{0:MMM dd, yyyy}")%></span>
                            <span class="doc-desc"><%#Eval("eventstitle")%></span>                            
                            <img id="img" runat="server" class="img-fluid" src="/images/file-pdf-icon.png" alt="pdf icon">
                        </a>
                        </ItemTemplate>
                        </asp:Repeater>
                        <div id="panelloadmore" runat="server" visible="false">
                            <button type="button" class="btn btn-link view-more">View More <span class="btn btn-circle btn-prime"><img class="img-fluid" src="/images/right-angle-white.svg"></span></button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>

