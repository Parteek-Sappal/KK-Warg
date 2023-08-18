<%@ Page Title="" Language="C#" MasterPageFile="~/engineering/layouts/inner.master" AutoEventWireup="true" CodeFile="testpp.aspx.cs" Inherits="engineering_testpp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
           <span>Enter Name: </span>
<asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Text" DataValueField="Value" EnableFilterSearch="true" FilterType="StartsWith"></asp:DropDownList>
       </div>

<div class="form-group-inner">
    <div class="row">
        <div class="">
            <div class="input-group mg-b-pro-edt">
                <span class="input-group-addon"><i class="fa fa-sticky-note-o"
                    aria-hidden="true"></i></span>
                <asp:TextBox ID="txName" runat="server" CssClass="form-control"
                    placeholder="Search Names" AutoPostBack="true" OnTextChanged ="TextChanged"></asp:TextBox>
                    
            </div>
        </div>
    </div>
</div>
<hr />
<asp:ListBox runat="server" ID="lstCustomers"></asp:ListBox>
 
<div>    
<table>
  <tr>
    <td colspan="2">OnTextChanged and AutoPostBack</td>
  </tr>           
  <tr>
    <td class="lbl">Enter Value 1 : </td>
    <td>
      <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></td> </tr>
  <tr>
    <td class="lbl">Enter Value 2 :</td>
    <td>
     <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    </td> </tr>
  <tr>
    <td>&nbsp;</td>
    <td>
     <asp:Label ID="lblsum" runat="server" ></asp:Label> </td> </tr>            
 </table>    
</div>

</asp:Content>

