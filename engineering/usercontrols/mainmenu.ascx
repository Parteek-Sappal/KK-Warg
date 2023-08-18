<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mainmenu.ascx.cs" Inherits="engineering_usercontrols_mainmenu" %>
<%@ Register Src="~/engineering/usercontrols/search.ascx" TagName="search" TagPrefix="uc1" %>
<header>
<div class="full-width px-0">
<nav class="menubar">
<a href="/engineering" class="navbar-brand"><img class="img-fluid" src="/engineering/images/kk-wagh-logo.png"
alt="KK Wagh logo"></a>
<div class="nav-right">
<div class="nav-right-top">
<ul class="top-menu list-unstyled mb-0">
<li><a href="/">Go to Group Website</a></li>
</ul>
</div>
<div class="nav-right-bottom">
<ul class="desktop-menubar list-unstyled mb-0">
<asp:Repeater ID="rptmainmenu" runat="server" OnItemDataBound="rptmainmenu_ItemDataBound">
<ItemTemplate>
<asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
<asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
<asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
<li id="l1" runat="server" class="menu-item has-submenu"><a id="ank" runat="server" class="menu-link"><%#Eval("linkname")%></a>
<div id="divsubmenu" class="submenu" runat="server" visible="false">
<ul class="mb-0 list-unstyled">
<asp:Repeater ID="rptsubmenu" runat="server" OnItemDataBound="rptsubmenu_OnItemDataBound">
<ItemTemplate>
<asp:Literal ID="litpageid" runat="server" Text='<%#Eval("pageid") %>' Visible="false"></asp:Literal>
<asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
<asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
<li id="lisubmenu" runat="server">
<a id="ank" runat="server"><%#Eval("linkname") %></a>
<div id="divinner" runat="server" class="submenu level2" visible="false">
<ul class="list-unstyled mb-0">
<asp:Repeater ID="rptsubmenuinner" runat="server" OnItemDataBound="rptsubmenuinner_OnItemDataBound">
<ItemTemplate>
<asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
<asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
<asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
<li><a id="ank" runat="server"><%#Eval("linkname") %></a></li>
</ItemTemplate>
</asp:Repeater>
<asp:Repeater ID="rptdepartmentinner" runat="server" OnItemDataBound="rptdepartmentinner_OnItemDataBound">
<ItemTemplate>
<asp:Literal ID="litdeptid" runat="server" Visible="false" Text='<%#Eval("deptid")%>'></asp:Literal>
<asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
<li><a id="ank" runat="server"><%#Eval("deptname")%></a></li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div>
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div>
<div class="mega-menu" id="panelmegamenu" runat="server" visible="false">
<div class="container max-content-lg">
<div class="row justify-content-end">
<div class="col-lg-9">
<div class="mega-menu-right">
<div class="row gy-5">
<div class="col-lg-8">
<asp:Repeater id="rptcourselevel" runat="server" OnItemDataBound="rptcourselevel_ItemDataBound">
<ItemTemplate>
<asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid")%>'></asp:Literal>
<div class="header-program-list">
<span class="program-heading"><%#Eval("levelname")%></span>
<ul class="list-unstyled mb-0">
	<asp:Repeater ID="rptcourselevelinner" runat="server" OnItemDataBound="rptcourselevelinner_ItemDataBound">
	<ItemTemplate>
		<asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid")%>'></asp:Literal>
		<asp:Literal ID="litcourseid" runat="server" Visible="false" Text='<%#Eval("courseid")%>'></asp:Literal>
			 <li><a id="ank" runat="server"><%#Eval("coursename")%></a></li>
	</ItemTemplate>
	</asp:Repeater>                                                                    
</ul>
</div>
</ItemTemplate>
</asp:Repeater>                                                            
</div>
<div class="col-lg-4">
<asp:Repeater id="rptcourseleveldoctor" runat="server" OnItemDataBound="rptcourseleveldoctor_ItemDataBound">
<ItemTemplate>
<asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid")%>'></asp:Literal>
<div class="header-program-list">
<span class="program-heading"><%#Eval("levelname")%></span>
<ul class="list-unstyled mb-0">
	<asp:Repeater ID="rptcourseleveldoctorinner" runat="server" OnItemDataBound="rptcourseleveldoctorinner_ItemDataBound">
	<ItemTemplate>
		<asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid")%>'></asp:Literal>
		<asp:Literal ID="litcourseid" runat="server" Visible="false" Text='<%#Eval("courseid")%>'></asp:Literal>
			 <li><a id="ank" runat="server"><%#Eval("coursename")%></a></li>
	</ItemTemplate>
	</asp:Repeater>                                                                    
</ul>
</div>
</ItemTemplate>
</asp:Repeater> 

</div>
</div>
</div>
</div>
</div>
</div>
</div>

</li>
</ItemTemplate>
</asp:Repeater>
</ul>
<div class="header-toggler-container">
<div class="input-group search-box">
<uc1:search ID="search1" runat="server" />
</div>

<button type="button" class="btn sidebar-toggler">
<img class="img-fluid" src="/engineering/images/bars-white.svg" alt="bars icon">
</button>
</div>
</div>
</div>
</nav>
</div>
</header>
