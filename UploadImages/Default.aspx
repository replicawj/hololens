<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UploadImages.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="defaultcss.css" rel="Stylesheet" type="text/css" />
    <title>Upload/Retrieve Images</title>
  
</head>
<body>
    <form id="form1" runat="server">
        <h2> Uploading of Image / Video</h2>
        <table>
            <tr>

                <td>
                    <asp:RadioButton ID="Img" GroupName="source" runat="server" Text="Image" />
                    <asp:RadioButton ID="Vid" GroupName="source" runat="server" Text="Video" />
                </td>

                <td >
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>

            </tr>

            <!-- New Code - Radio Button for 3x3 Display -->
            <tr>
                <td>
                   <p> Position of Img/Vid </p>
                </td>
                <td>
                    <asp:DropDownList ID="DisplayList" runat="server"> </asp:DropDownList>
                </td>
            </tr>
        </table>

        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"></asp:Button>

        <p>
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True"
                ForeColor="#FF0000"></asp:Label>
        </p>

        <!-- Above is Upload, Below is Retrieve -->

        <h2> Displaying of Image / Video</h2>
        <table>
            <tr>
                <td>
                    <asp:RadioButton ID="RadioButton1" GroupName="source" runat="server" Text="Image" />
                    <asp:RadioButton ID="RadioButton2" GroupName="source" runat="server" Text="Video" />
                </td>
            </tr>
            <tr>
                <td>
                    <p> Image Position <asp:DropDownList ID="DisplayContent" runat="server"> </asp:DropDownList> </p>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button2" runat="server" Text="View" OnClick="Button2_Click"></asp:Button>

        <!-- Image Retrieve codes -->

        <table>
                <tr>
                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image0" runat="server" ImageUrl="placeholder" Height="288px" Width="512px"></asp:image></td>
                </tr>
                <tr>
           
                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image1" runat="server" ImageUrl="placeholder" Height="141px" Width="250px"></asp:image></td>
                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image2" runat="server" ImageUrl="placeholder" Height="141px" Width="250px"></asp:image></td>
                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image3" runat="server" ImageUrl="placeholder" Height="141px" Width="250px"></asp:image></td>
                </tr>

                <tr>

                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image4" runat="server" ImageUrl="placeholder" Height="141px" Width="250px"></asp:image></td>
                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image5" runat="server" ImageUrl="placeholder" Height="141px" Width="250px"></asp:image></td>
                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image6" runat="server" ImageUrl="placeholder" Height="141px" Width="250px"></asp:image></td>
                </tr>

                <tr>

                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image7" runat="server" ImageUrl="placeholder" Height="141px" Width="250px"></asp:image></td>
                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image8" runat="server" ImageUrl="placeholder" Height="141px" Width="250px"></asp:image></td>
                    <td align="center"><asp:image ToolTip="ASP Image Control" ID="Image9" runat="server" ImageUrl="placeholder" Height="141px" Width="250px"></asp:image></td>
                </tr>

        </table>
        
        <!-- Video Retrieve codes -->
        <asp:DataGrid id="FileList" runat="server" AutoGenerateColumns="true" >
            <Columns>
                <asp:TemplateColumn HeaderText="Open Video">
                <ItemTemplate>
                    <a href="VideoHandler.ashx?ID=<%# DataBinder.Eval(Container.DataItem, "ID") %>">View File</a>
                </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>

    </form>

</body>
</html>
