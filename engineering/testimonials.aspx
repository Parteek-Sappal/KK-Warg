<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="testimonials.aspx.cs" Inherits="engineering_testimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="testimonials">
            <div class="container">
               <ul class="nav nav-tabs mx-auto">
                <asp:Repeater ID="rpttestimonials" runat="server" OnItemDataBound="rpttestimonials_ItemDataBound">
                <ItemTemplate>                
                <asp:Literal id="littesid" runat="server"  Visible="false" Text='<%#Eval("tesid")%>'></asp:Literal>
                    <li class="nav-item"><a id="ank" runat="server"><span><%#Eval("testimonialtype")%></span></a></li>
                </ItemTemplate>
                </asp:Repeater>
                </ul>
                <div class="testimonials-list">
                    <div class="row gy-4 gx-lg-5">
                    <asp:Repeater ID="rpttestimonialsdetail" runat="server" OnItemDataBound="rpttestimonialsdetail_ItemDataBound">
                    <ItemTemplate>
                    <asp:Literal id="littesid" runat="server"  Visible="false" Text='<%#Eval("tesid")%>'></asp:Literal>
                    <asp:Literal id="littestimonialid" runat="server"  Visible="false" Text='<%#Eval("testimonialid")%>'></asp:Literal>
                        <div class="col-lg-4 col-sm-6">
                            <div class="testimonial-thumb image">
                                <figure>
                                    <img class="img-fluid" src="/uploads/TestimonialImage/<%#Eval("uploadphoto")%>" alt="Sukhadev Naik Pic">
                                </figure>
                                <div class="text">
                                   <span class="name"><%#Eval("testimonialname")%></span>
                                    <span class="designation"><%#Eval("desg")%></span>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>
                        <div class="col-12" id="btnload" runat="server" visible="false">
                            <button type="button" class="btn btn-link view-more">View More <span class="btn btn-circle btn-prime"><img class="img-fluid" src="./images/right-angle-white.svg"></span></button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>

