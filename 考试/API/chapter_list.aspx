﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chapter_list.aspx.cs" Inherits="API_chapter_list" %>

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
                url: "chapter_list.aspx",
                type: "GET",
                data: {

                },
                dataType: "json",
                success: function (data) {
                  
                }
         
            });            
        </script>
    </form>
</body>
</html>
