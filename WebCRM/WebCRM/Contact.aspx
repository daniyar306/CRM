<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebCRM.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <p>


    </p>
    <h5>
        Список юр. лиц
    </h5>
    <div>
            Фильтр:
   <asp:DropDownList ID="ddList" runat="server"
       ItemType="System.String" SelectMethod="GetCategories" />    
        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="OnFiltered" Width="68px" />
        </div>
          <p>


          </p>
   <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table cellspacing="0" rules="all" border="1">
                <tr>
                    <th scope="col" style="width: 120px">
                        Ид
                    </th>
                    <th scope="col" style="width: 120px">
                        БИН
                    </th>
                    <th scope="col" style="width: 100px">
                        Наименование
                    </th>
                   
                    <th scope="col" style="width: 80px">
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' Visible="true" />
                     <asp:TextBox ID="txtId" runat="server" Width="20" Text='<%# Eval("Id") %>'
                        Visible="false" />
                 </td>
                    <td>  
                    <asp:Label ID="lblIIN" runat="server" Text='<%# Eval("IIN_BIN") %>' />
                    <asp:TextBox ID="txtIIN" runat="server" Width="120" Text='<%# Eval("IIN_BIN") %>'
                        Visible="false" />
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("FullName") %>' />
                    <asp:TextBox ID="txtName" runat="server" Width="120" Text='<%# Eval("FullName") %>'
                        Visible="false" />
                </td>
             
                <td>
                    <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" OnClick="OnEdit" />
                    <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" Visible="false" OnClick="OnUpdate" />
                    <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" Visible="false" OnClick="OnCancel" />
                    <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete" OnClientClick="return confirm('Do you want to delete this row?');" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
        <tr>
            <td style="width: 154px; height: 80px;">
                Ид:<br />
                <asp:TextBox ID="Id" runat="server" Width="140" />
            </td>
            <td style="width: 154px; height: 80px;">
                ИИН:<br />
                <asp:TextBox ID="IIN_BIN" runat="server" Width="140" />
            </td>
            <td style="width: 153px; height: 80px;">
                Наименование:<br />
                <asp:TextBox ID="Name" runat="server" Width="140" />
            </td>
           
            <td style="width: 83px; height: 80px;">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" Width="68px" />
            </td>
        </tr>
    </table>
    
  



</asp:Content>
