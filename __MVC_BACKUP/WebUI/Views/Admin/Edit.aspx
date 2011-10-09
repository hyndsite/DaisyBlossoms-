<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<DTOS.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ProductId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Category.CategoryId)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Category.CategoryId)%>
                <%: Html.ValidationMessageFor(model => model.Category.CategoryId)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Price) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Price, String.Format("{0:F}", Model.Price)) %>
                <%: Html.ValidationMessageFor(model => model.Price) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SalePrice) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SalePrice, String.Format("{0:F}", Model.SalePrice)) %>
                <%: Html.ValidationMessageFor(model => model.SalePrice) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StockAmt) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StockAmt) %>
                <%: Html.ValidationMessageFor(model => model.StockAmt) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StockLevelWarning) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StockLevelWarning) %>
                <%: Html.ValidationMessageFor(model => model.StockLevelWarning) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Dimensions) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Dimensions) %>
                <%: Html.ValidationMessageFor(model => model.Dimensions) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PriceIncludesTax) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PriceIncludesTax) %>
                <%: Html.ValidationMessageFor(model => model.PriceIncludesTax) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TaxClass) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TaxClass) %>
                <%: Html.ValidationMessageFor(model => model.TaxClass) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ProductWeight) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ProductWeight, String.Format("{0:F}", Model.ProductWeight)) %>
                <%: Html.ValidationMessageFor(model => model.ProductWeight) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CubicWeight) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CubicWeight, String.Format("{0:F}", Model.CubicWeight)) %>
                <%: Html.ValidationMessageFor(model => model.CubicWeight) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PackageDimensions) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PackageDimensions) %>
                <%: Html.ValidationMessageFor(model => model.PackageDimensions) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.IncludeLatestProduct) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.IncludeLatestProduct) %>
                <%: Html.ValidationMessageFor(model => model.IncludeLatestProduct) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

