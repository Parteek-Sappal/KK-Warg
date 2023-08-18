<%@ Control Language="C#" AutoEventWireup="true" CodeFile="search.ascx.cs" Inherits="usercontrols_search" %>

<asp:Panel ID="Panel1" runat="server" CssClass="search" DefaultButton="LinkButton1">
            <asp:TextBox ID="txtsearch" runat="server"  class="form-control" placeholder="Search..." ontextchanged="txtsearch_TextChanged"></asp:TextBox>	
                    <div class="input-group-append">	 
           <asp:LinkButton ID="LinkButton1" runat="server" class="btn mainSearchBtn" OnClick="LinkButton1_Click" CausesValidation="false"><span><img src="/images/search-icon.png" class="img-fluid" alt="header-search"></span></asp:LinkButton>
		      
		  </div>
</asp:Panel>