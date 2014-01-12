using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public static class DbHelper
{
    public enum User
    {
        First,
        Second
    }
    private static string connectionString = 
        ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

    public static DataTable SelectData(string query, IDictionary<string, string> parameters = null)
    {
        using (SqlConnection sqlConnection =
            new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
            sqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            sqlConnection.Close();
            return dt;
        }
    }

    public static int ChangeData(string query, IDictionary<string, string> parameters = null)
    {
        using (SqlConnection sqlConnection =
            new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
            sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return rowsAffected;
        }
    }

    public static string GetUserIdByGame(string gameId, User user)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("@gameId", gameId);
        string userColumn = user == User.First ? "firstUserId" : "secondUserId";
        string userId = SelectData("select " + userColumn + " from Game where Id = @gameId", parameters).Rows[0][userColumn].ToString();
        return userId != string.Empty ? userId.ToLower() : null;
    }
    public static bool IsGame(string gameId)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("@gameId", gameId);
        return SelectData("select Id from Game where Id = @gameId", parameters)
               .Rows.Count > 0 ? true : false;
    }
    public static bool IsUserInGame(string gameId, string userId)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("@gameId", gameId);
        parameters.Add("@firstUserId", userId);
        parameters.Add("@secondUserId", userId);
        return SelectData("select Id from Game where Id = @gameId AND (firstUserId = @firstUserId OR secondUserId = @secondUserId)", parameters).Rows.Count > 0;
    }
    public static bool IsFirstUser(string gameId, string userId)
    {
        if (!IsUserInGame(gameId, userId))
            throw new Exception();
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("@gameId", gameId);
        parameters.Add("@firstUserId", userId);
        return SelectData("select * from Game where Id = @gameId AND firstUserId = @firstUserId", parameters).Rows.Count > 0;
    }
    public static bool ExistsUserMove(string gameId, string userId)
    { 
        if (!IsUserInGame(gameId, userId))
            throw new Exception();
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("@gameId", gameId);
        parameters.Add("@userId", userId);
        return SelectData("select * from Move where GameId = @gameId AND UserId = @userId", parameters).Rows.Count > 0;
    }

    public static void SetMoveMetadata(string gameId, string userId, string metadata, int currentMoveNumber)
    {
        currentMoveNumber++;
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("@gameId", gameId);
        parameters.Add("@userId", userId);
        parameters.Add("@metadata", metadata);
        parameters.Add("@currentMoveNumber", currentMoveNumber.ToString());
        if (!ExistsUserMove(gameId, userId))
        {
            ChangeData("insert into Move values (NEWID(), @gameId, @userId, @metadata, @currentMoveNumber)", parameters);
        }
        else 
        {
            ChangeData("update Move set Metadata = @metadata, CurrentNumber = @currentMoveNumber where GameId = @gameId AND UserId = @userId", parameters);
        }
    }
    public static string GetOpponentIdByUserId(string gameId, string userId)
    {
        if (!IsGame(gameId))
            throw new Exception();
        string opponentId;
        if (IsFirstUser(gameId, userId))
            opponentId = GetUserIdByGame(gameId, User.Second);
        else
            opponentId = GetUserIdByGame(gameId, User.First);
        return opponentId;
    }
    public static bool IsEndOpponentMove(string gameId, string userId)
    {
        //Убрать привязку к IsReaded.
        if (!ExistsUserMove(gameId, userId))
            throw new Exception();
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("@gameId", gameId);
        parameters.Add("@userId", userId);
        parameters.Add("@opponentId", GetOpponentIdByUserId(gameId, userId));
        var result = SelectData("select * from Move where GameId = @gameId AND (UserId = @userId OR UserId = @opponentId)", parameters);
        if (result.Rows.Count != 2)
            return false;
        else
        {
            int firstMoveNumber = Convert.ToInt32(result.Rows[0]["CurrentNumber"]);
            int secondMoveNumber = Convert.ToInt32(result.Rows[1]["CurrentNumber"]);
            if (firstMoveNumber == secondMoveNumber)
                return true;
            else
                return false;
        }
    }
}
