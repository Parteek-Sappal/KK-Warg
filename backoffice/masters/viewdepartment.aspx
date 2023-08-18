<%@ Page Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true"  CodeFile="viewdepartment.aspx.cs" Inherits="backoffice_masters_viewdepartment" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h2>  View/Edit Departments</h2>
<div class="content-panel">
<table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td class="head1" style="width: 29%">
              
            </td>
            <td align="right" style="width: 80%">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="h_dot_line">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingtext" colspan="2">
                <div class="error" align="left" id="trerror" runat="server">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </div>
                <div class="success" align="left" id="trsuccess" runat="server">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                </div>
                <div class="notice" align="left" id="trnotice" runat="server">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblnotice" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal"
                    HorizontalAlign="Center" Width="100%" AllowPaging="true" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <HeaderStyle HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                     
                         <asp:TemplateField HeaderText="Department" ItemStyle-Width="25%">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <%#Eval("deptname")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="top" Width="2%" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="Status">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                              <asp:TextBox ID="txtstatus" runat="server" Text='<%# Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#Eval("deptid")%>'
                                    CommandName="lnkstatus"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("deptid")%>'
                                    CommandName="redit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle HorizontalAlign="Right" />
                    <PagerStyle HorizontalAlign="Right" />
                </asp:GridView>
            </td>
        </tr>
       
        <tr>
            <td align="center" colspan="2">
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

