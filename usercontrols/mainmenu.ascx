<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mainmenu.ascx.cs" Inherits="usercontrols_mainmenu" %>
<%@ Register Src="~/usercontrols/topmenu.ascx" TagName="topmenu" TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/search.ascx" TagName="search" TagPrefix="uc2" %>
<header>
        <div class="container full-width px-0">
            <nav class="menubar">
                <a href="/" class="navbar-brand"><img class="img-fluid" src="/images/kk-wagh-logo.png" alt="KK Wagh logo"></a>
                <div class="nav-right">
                  <uc1:topmenu ID="topmenu1" runat="server" />
                    <div class="nav-right-bottom">
                        <ul class="desktop-menubar list-unstyled mb-0">
                        <asp:Repeater ID="rptmainmenu" runat="server" OnItemDataBound="rptmainmenu_ItemDataBound">
                        <ItemTemplate>
                        <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                        <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                        <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                           <li id="l1" runat="server">
                           <a id="ank" runat="server" class="menu-link"><%#Eval("linkname")%></a>                        
                           <div class="submenu" id="submenu" runat="server" visible="false">
                                    <ul class="mb-0 list-unstyled">
                                    <asp:Repeater ID="rptinner" runat="server" OnItemDataBound="rptinner_ItemDataBound">
                                    <ItemTemplate>
                                    <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                   <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                   <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                    <li id="l1" runat="server">
                                            <a id="ank" runat="server"><%#Eval("linkname")%></a>
                                            <div class="submenu level2" id="submenu2" runat="server" visible="false">
                                                <ul class="list-unstyled mb-0">
                                                  <asp:Repeater ID="rptinner2" runat="server" OnItemDataBound="rptinner2_ItemDataBound">
                                                     <ItemTemplate>
                                                     <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                                    <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                                    <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                                    <li><a id="ank" runat="server"><%#Eval("linkname")%></a></li>
                                                    </ItemTemplate>
                                                  </asp:Repeater>
                                                </ul>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                    </asp:Repeater>
									</ul>
								</div>
                              <%#Server.HtmlDecode(Eval("megamenu").ToString())%>
                           </li>
                        </ItemTemplate>
                        </asp:Repeater>
                        </ul>
                        <div class="input-group search-box">
                        <uc2:search ID="search1" runat="server" />
                           </div>
                      
                </div>
                </div>
            </nav>
        </div>
    </header>
