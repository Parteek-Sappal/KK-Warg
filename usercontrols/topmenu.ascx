<%@ Control Language="C#" AutoEventWireup="true" CodeFile="topmenu.ascx.cs" Inherits="usercontrols_topmenu" %>
  <div class="nav-right-top">
                        <ul class="top-menu list-unstyled mb-0">
                          <asp:Repeater ID="rpttopmenu" runat="server" OnItemDataBound="rpttopmenu_ItemDataBound">
                          <ItemTemplate>
                               <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                        <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                        <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                          <li id="l1" runat="server">
                            <a id="ank" runat="server"><%#Eval("linkname")%></a></li>
                          </ItemTemplate>
                          </asp:Repeater>
                        </ul>
                    </div>