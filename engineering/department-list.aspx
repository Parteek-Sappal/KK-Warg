<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="department-list.aspx.cs" Inherits="engineering_department_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="top-section bord-of-directors">
	<div class="container">
		<div class="row">
        <asp:Repeater ID="rptboard" runat="server" OnItemDataBound="rptboard_OnItemDataBound">
        <ItemTemplate>
        <asp:Literal ID="litdeptid" runat="server" Text='<%#Eval("deptid")%>' Visible="false"></asp:Literal>
        	<div class="col-lg-4 col-sm-6">
				<div class="faculties_box">
					<a id="ank" runat="server"><figure class="faculties_img">
						<img alt="<%#Eval("deptid")%>" class="img-fluid w-100" src="/uploads/banner/<%#Eval("admissionimg")%>" /></figure>
					<div class="faculties_cont">
						<span><%#Eval("deptname")%></span></div></a>
				</div>				
			</div>

          
        </ItemTemplate>
        </asp:Repeater>
		
			
		</div>
	</div>
</section>
</asp:Content>

