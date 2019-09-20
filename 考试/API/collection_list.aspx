<%@ Page Language="C#" AutoEventWireup="true" CodeFile="collection_list.aspx.cs" Inherits="API_store_list" %>

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
                url: "collection_list.aspx",//执行查询错题和查询收藏
                type: "GET",
                data: {
                    "uid": $(this).val(),
                    "type": $(this).val(), //这里type是指错题或者收藏
                },
                dataType: "json",
                success: function (data) {
                  
                }
         
            });            
        </script>
    </form>
</body>
</html>
