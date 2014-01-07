<%@ WebHandler Language="C#" Class="AjaxEngineHandler" %>

using System;
using System.Web;

public class AjaxEngineHandler : IHttpHandler {
    
    //Если запрос повторяющийся, тогда для его остановки нужно возвращать "stop"
    public void ProcessRequest (HttpContext context) {
        var requestedParams = context.Request.Params;
        bool repeatedRequest = Convert.ToBoolean(requestedParams["repeated"]);
        string action = requestedParams["action"];
        switch (action)
        { 
            case "checkGameStart":
                CheckStartGame(requestedParams["gameId"], context);
                break;
        }
    }
    private void CheckStartGame(string gameId, HttpContext context)
    {
        string firstUserId = DbHelper.GetUserIdByGame(gameId, DbHelper.User.First);
        string secondUserId = DbHelper.GetUserIdByGame(gameId, DbHelper.User.Second);
        if (firstUserId != null && secondUserId != null)
            context.Response.Write("stop");
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}