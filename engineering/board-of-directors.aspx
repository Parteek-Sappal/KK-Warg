<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="board-of-directors.aspx.cs" Inherits="engineering_board_of_directors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="top-section bord-of-directors">
	<div class="container">
		<div class="row">
        <asp:Repeater ID="rptboard" runat="server">
        <ItemTemplate>
        <asp:Literal ID="litteamid" runat="server" Text='<%#Eval("teamid")%>' Visible="false"></asp:Literal>
        	<div class="col-lg-4 col-sm-6">
				<div class="faculties_box" data-bs-target="#facultyDetails1<%#Eval("teamid")%>" data-bs-toggle="modal">
					<figure class="faculties_img">
						<img alt="<%#Eval("teamid")%>" class="img-fluid w-100" src="/uploads/SmallImages/<%#Eval("uploadphoto")%>" /></figure>
					<div class="faculties_cont">
						<span><%#Eval("name")%></span> <abbr><%#Eval("designation")%></abbr></div>
				</div>
				<div class="modal facultymodal" id="facultyDetails1<%#Eval("teamid")%>">
					<div class="modal-dialog modal-lg modal-dialog-centered">
						<div class="modal-content">
							<div class="modal-header">
								<button class="btn-close" data-bs-dismiss="modal" type="button"></button></div>
							<div class="modal-body">
								<div class="faculty-details">
									<div class="row">
										<div class="col-lg-5">
											<figure class="mb-0">
												<img alt="" class="img-fluid" src="/uploads/SmallImages/<%#Eval("uploadphoto")%>" /></figure>
										</div>
										<div class="col-lg-7">
											<div class="faculty-text">
												<div class="faculty-heading">
													<h5 class="fsize-6 text-prime font-heading">
														<%#Eval("name")%></h5>
                                                        	<p class="fsize-8">
														<%#Eval("designation")%></p>
												</div>
												<%#Server.HtmlDecode(Eval("shortdesc").ToString())%>
													
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>

          
        </ItemTemplate>
        </asp:Repeater>
		
			
		</div>
	</div>
</section>
</asp:Content>

