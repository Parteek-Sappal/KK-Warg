<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hamburger.ascx.cs" Inherits="engineering_usercontrols_hamburger" %>
<div class="desktop-sidebar">
    <div class="full-width px-0">
        <div class="sidebar-content">
            <ul class="list-unstyled mb-0">
                <asp:Repeater ID="rpthamburger" runat="server" OnItemDataBound="rpthamburger_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                        <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                        <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                        <li><a id="ank" runat="server" class="main-link">
                            <%#Eval("linkname")%></a>
                            <div class="submenu" id="submenu" runat="server" visible="false">
                                <asp:Repeater ID="rptinner" runat="server" OnItemDataBound="rptinner_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                        <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                        <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                        <a id="ank" runat="server" href="">
                                            <%#Eval("linkname")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>               
            </ul>
            <button type="button" class="btn sidebar-close-button">
                <img class="img-fluid" src="/engineering/images/cross-icon.svg" alt="cross icon">
            </button>
        </div>
    </div>
</div>
