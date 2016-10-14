<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadProgress.aspx.cs" Inherits="MyHttpHandlers.UploadProgress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function uploadProgress(){
            var elmBar = document.getElementById("barCell");
            var elmPercent = document.getElementById("lblPercent");
            var uploadId = document.getElementById("DiskFileUpload_GUID").value;

            alert(uploadId);
            var timerid= window.setInterval(
                function () {
                    var xhr;
                    if (window.ActiveXObject)
                        xhr = new ActiveXObject("Microsoft.XMLHTTP");
                    else xhr = new XMLHttpRequest();

                    xhr.open("get", "JsonHandler.ashx?DiskFileUpload_GUID=" + uploadId, false);
                    xhr.send(null);

                    if (xhr.readyState == 4) {
                        if (xhr.status = 200) {
                            var result = eval("(" + xhr.responseText + ")");
                            elmBar.style.width = result.Percent + "%";
                            elmPercent.innerHTML = result.Percent + "%";
                        }
                    }
                }
                ,1000);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="DiskFileUpload_GUID" runat="server" ClientIDMode="Static" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button"  OnClientClick="uploadProgress();"/>
        <br />
        <span id="barCell">
           <input id="lblPercent" value="Progress"  type="text" />
        </span>

    
    </div>
    </form>
</body>
</html>
