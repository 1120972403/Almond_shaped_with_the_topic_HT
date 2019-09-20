<%@ Page Language="C#" AutoEventWireup="true" CodeFile="get_question_collection.aspx.cs" Inherits="API_get_question_collection" %>

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
                url: "get_question_collection.aspx",//执行插入收藏和错题，也执行取消收藏和删除错题
                type: "post",
                data: {
                    "uid": $(this).val(),
                    "details_id": $(this).val(),
                    "type": $(this).val(), //这里type是指错题或者收藏
                    "error_answer": $(this).val()//记录用户输错的题
                   
                },
                dataType: "json",
                success: function (data) {
                  
                }
         
            });            
        </script>
    </form>
</body>
</html>
