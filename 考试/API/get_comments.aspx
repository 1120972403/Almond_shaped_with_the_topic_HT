<%@ Page Language="C#" AutoEventWireup="true" CodeFile="get_comments.aspx.cs" Inherits="API_get_comments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <script type="text/javascript">
            $.ajax({
                url: "get_comments.aspx",
                type: "post",
                data: {
                    "uid": $(this).val(),
                    "opinion": $(this).val(),
                    "contant": $(this).val(),
                    "type": $(this).val(),
                    "details_id": $(this).val(),
                    
                },
                dataType: "json",
                success: function (data) {
                  
                }
         
            });            
        </script>
    </form>
</body>
</html>
