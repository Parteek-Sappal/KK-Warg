<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="Testimonials.aspx.cs" Inherits="Testimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section class="inner-title">
            <div class="container">
                <div class="section-heading text-center">
                    <%--<h1 class="section-title">Testimonials</h1>--%>
                </div>
            </div>
        </section>
        <section class="testimonials">
            <div class="container">
                <ul class="nav nav-tabs">

<%--                <li class="nav-item"><a class="active" href="javascript:void(0)"><span>Students</span></a></li>
                    <li class="nav-item"><a href="javascript:void(0)"><span>Parents</span></a></li>
                    <li class="nav-item"><a href="javascript:void(0)"><span>Alumni</span></a></li>
                    <li class="nav-item"><a href="javascript:void(0)"><span>Faculty</span></a></li>
                    <li class="nav-item"><a href="javascript:void(0)"><span>Staff</span></a></li>
                    <li class="nav-item"><a href="javascript:void(0)"><span>Recruiters</span></a></li>
--%>
                <asp:Repeater ID="rpttesttype" runat="server" OnItemDataBound="rpttesttype_OnItemDataBound">
                <ItemTemplate>
                <asp:Literal ID="littesid" runat="server" Text='<%#Eval("tesid") %>' Visible="false"></asp:Literal>
                <asp:Label ID="lblcnt" runat="server" visible="false"></asp:Label>
                    <li class="nav-item"><a id="ank" runat="server"><span><%#Eval("testimonialtype")%></span></a></li>
                </ItemTemplate>
                </asp:Repeater>
                
                </ul>
                <div class="testimonials-list">
                    <div class="row gy-4 gx-lg-5">
                    <asp:Repeater ID="rpttestimonials" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-sm-6">
                            <div class="testimonial-thumb image">
                                <figure>
                                    <img class="img-fluid" src="/uploads/testimonialimage/<%#Eval("Uploadphoto") %>" alt="Sukhadev Naik Pic">
                                </figure>
                                <div class="text">
                                    <span class="name"><%#Eval("testimonialname")%></span>
                                    <span class="designation"><%#Eval("desg")%></span>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>


<%--                        <div class="col-lg-4 col-sm-6">
                            <div class="testimonial-thumb image">
                                <figure>
                                    <img class="img-fluid" src="./images/testimonials-1.jpg" alt="Sukhadev Naik Pic">
                                </figure>
                                <div class="text">
                                    <span class="name">Sukhadev Naik</span>
                                    <span class="designation">B.Tech in Computer Engineering</span>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-sm-6">
                            <div class="testimonial-thumb video">
                                <figure>
                                    <img class="img-fluid" src="./images/testimonials-2.jpg" alt="Abdul H. Ansari Pic">
                                    <div class="video-icon">
                                        <img class="img-fluid" src="./images/video-icon-red.svg" />
                                    </div>
                                </figure>
                                <div class="text">
                                    <span class="name">Abdul H. Ansari</span>
                                    <span class="designation">B.Tech in Computer Engineering</span>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-sm-6">
                            <div class="testimonial-thumb video">
                                <figure>
                                    <img class="img-fluid" src="./images/testimonials-3.jpg" alt="Snehal Joshi Pic">
                                    <div class="video-icon">
                                        <img class="img-fluid" src="./images/video-icon-red.svg" />
                                    </div>
                                </figure>
                                <div class="text">
                                    <span class="name">Snehal Joshi</span>
                                    <span class="designation">B.Tech in Computer Engineering</span>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-sm-6">
                            <div class="testimonial-thumb video">
                                <figure>
                                    <img class="img-fluid" src="./images/testimonials-4.jpg" alt="Snehal Joshi Pic">
                                    <div class="video-icon">
                                        <img class="img-fluid" src="./images/video-icon-red.svg" />
                                    </div>
                                </figure>
                                <div class="text">
                                    <span class="name">Snehal Joshi</span>
                                    <span class="designation">B.Tech in Computer Engineering</span>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-sm-6">
                            <div class="testimonial-thumb">
                                <figure>
                                    <img class="img-fluid" src="./images/testimonials-2.jpg" alt="Snehal Joshi Pic">
                                </figure>
                                <div class="text">
                                    <span class="name">Snehal Joshi</span>
                                    <span class="designation">B.Tech in Computer Engineering</span>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-sm-6">
                            <div class="testimonial-thumb">
                                <figure>
                                    <img class="img-fluid" src="./images/testimonials-1.jpg" alt="Snehal Joshi Pic">
                                </figure>
                                <div class="text">
                                    <span class="name">Snehal Joshi</span>
                                    <span class="designation">B.Tech in Computer Engineering</span>
                                </div>
                            </div>
                        </div>
--%>
                        <div class="col-12">
                            <button type="button" class="btn btn-link view-more">View More <span class="btn btn-circle btn-prime"><img class="img-fluid" src="./images/right-angle-white.svg"></span></button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>

