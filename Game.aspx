<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="script/jquery-2.0.0.min.js"></script>
    <script src="script/jquery-migrate-1.2.1.min.js"></script>
    <script src="script/ajaxEngine.js"></script>
    <script src="script/Silverlight.js"></script>
    <link href="style/main.css" rel="stylesheet" />
    <script>
        <% if (requestedGameId != null && isRequestedGame && requestedUserId != null)
           {%>
        $(function () {
            Engine.ajax.repeatedRequest({
                action: "checkGameStart",
                gameId: "<%=requestedGameId%>"
            }, 3000, function () {
                $("#waitOpponentStatus").remove();
                Silverlight.createObject(
                    "ClientBin/GamePlugin.xap",
                    $("#gamePluginPanel")[0],
                    "gamePlugin",
                    {
                        version: '2.0'
                    });
            });
        });
        <% } %>
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 id="waitOpponentStatus" runat="server">Ожидание соперника</h1>
            <div id="gamePluginPanel" />
        </div>
    </form>
</body>
</html>
