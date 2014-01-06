<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="script/jquery-2.0.0.min.js"></script>
    <script src="script/jquery-migrate-1.2.1.min.js"></script>
    <script src="script/ajaxEngine.js"></script>
    <link href="style/main.css" rel="stylesheet" />
    <script>
        $(function () {
            Engine.ajax.repeatedRequest({
                action: "checkGameStart",
                gameId: "<%=requestedGameId%>"
            }, 3000, function () {
                $("#status").remove();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 id="status" style="text-align: center">Ожидание соперника</h1>
            <div id="htmlGameWrapper">
                
            </div>
        </div>
    </form>
</body>
</html>
