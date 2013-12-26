using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Game : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string requestedGameId = Request.QueryString["gameId"];
        string requestedUserId = Request.QueryString["userId"];
        if (requestedGameId == null)
        {
            //Создание новой игры и первого пользователя
            Guid newGameId = Guid.NewGuid();
            Guid newFirstUserId = Guid.NewGuid();
            DbHelper.ChangeData("Insert into Game values('" + newGameId + "', '" + newFirstUserId + "', null)");
            Response.Redirect("~/Game.aspx?gameId=" + newGameId + "&userId=" +newFirstUserId);
        }
        else if (DbHelper.IsGame(requestedGameId))
        {
            string firstUserId = DbHelper.GetUserIdByGame(requestedGameId, DbHelper.User.First);
            string secondUserId = DbHelper.GetUserIdByGame(requestedGameId, DbHelper.User.Second);
            if (requestedUserId == null && secondUserId == null)
            {
                //Создание второго пользователя и начало игры
                Guid newSecondUserId = Guid.NewGuid();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@gameId", requestedGameId);
                DbHelper.ChangeData("Update Game set secondUserId='"+newSecondUserId+"' where gameId = @gameId", parameters);
            }
            else if (requestedUserId == firstUserId)
            { 
                //Загружаем игру для первого пользователя
            }
            else if (requestedUserId == secondUserId)
            {
                //Загружаем игру для второго пользователя
            }
        }
        
    }
}
