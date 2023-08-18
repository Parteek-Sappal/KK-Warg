<%@ Control Language="C#" AutoEventWireup="true" CodeFile="breadcrumbs.ascx.cs" Inherits="usercontrols_breadcrumbs" %>

     
      
     <ul class="breadcrumb list-unstyled mb-0 justify-content-center">
                        <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>

                          <asp:Repeater ID="rptBread" runat="server" OnItemDataBound="rptBread_ItemDataBound">
                <ItemTemplate>
                    <asp:Label ID="lblpageid" runat="server" Text='<%#Eval("pageid")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lblrewrite" runat="server" Text='<%#Eval("rewriteurl")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lblPageUrl" runat="server" Text='<%#Eval("PageUrl")%>' Visible="false"></asp:Label>
                    <li class="breadcrumb-item" aria-current="page">
                    <a id="ancher" runat="server">
                        <%#Eval("PageName")%></a>
                        </li> 
                </ItemTemplate>              
            </asp:Repeater>                                
                        <li class="breadcrumb-item active" area-current="page"> <asp:Literal ID="lblcoursename" runat="server"></asp:Literal>  </li>
                    </ul>

