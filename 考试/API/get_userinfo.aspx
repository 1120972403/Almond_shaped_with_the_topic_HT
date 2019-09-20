<%@ Page Language="C#" AutoEventWireup="true" CodeFile="get_userinfo.aspx.cs" Inherits="API_get_userinfo" %>

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
                url: "get_userinfo.aspx",
                type: "POST",
                data: {
                    "openid": $(this).val(),
                    "nickName": $(this).val(),
                    "avatarUrl": $(this).val(),
                    "province": $(this).val(),
                    "city": $(this).val(),
                },
                dataType: "json",
                success: function (data) {
                   
                }
         
            });            
        </script>
    </form>
</body>
</html>
