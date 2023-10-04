<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MainPageMaster.Master" AutoEventWireup="true" CodeBehind="Statistiques.aspx.cs" Inherits="suiveStagaireProject.Views.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <div class="container">

        <%  if (Request.QueryString["do"] != null)
            {

                if (Request.QueryString["do"]=="AllModules")
                {

                }else if (Request.QueryString["do"] == "AllEnseignants")
                {

                }else if (Request.QueryString["do"] == "add")
                {

                }else if (Request.QueryString["do"] == "edit")
                {

                }else if (Request.QueryString["do"] == "delete")
                {

                }


            }
            else
            {
             Response.Redirect("404-page.aspx");            }

            %>


    </div>
</asp:Content>
