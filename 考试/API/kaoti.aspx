<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kaoti.aspx.cs" Inherits="API_kaoti" %>

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
                url: "kaoti.aspx",
                type: "GET",
                data: {
                    "type": $(this).val(),
                    "chapter_id": $(this).val(),
                    "bank_id": $(this).val(),
                },
                dataType: "json",
                success: function (data) {
                  
                }
         
            });            
        </script>
    </form>
</body>
</html>
