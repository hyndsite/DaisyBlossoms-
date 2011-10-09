<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DTOS.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Product list</h2>
    <div>
        <div>
            <table>
            <tr>
                <th>Name</th>
                <th>Category</th>
                <th>Price / Sale Price</th>
            </tr>
            </table>
        </div>
        <div>
             <% foreach (var item in Model) { %>
             <div>
                <%: item.Name %>
             </div>
             <div>
                <%: item.Price.ToString("c") %> / <%: item.SalePrice.ToString("c") %>
             </div>
             <div>
                <%: Html.ActionLink("Edit", "Edit", new { id = item.ProductId })%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
             </div>
              <% } %>
        </div>
    </div>
    <p>
        <%: Html.ActionLink("Create New", "Add") %>
    </p>

</asp:Content>

