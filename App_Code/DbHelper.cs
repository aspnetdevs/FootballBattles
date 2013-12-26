﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



public static class DbHelper
{
    public static enum User
    {
        First,
        Second
    }
    private static SqlConnection sqlConnection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

    public static DataTable SelectData(string query, IDictionary<string, string> parameters = null)
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

    public static int ChangeData(string query, IDictionary<string, string> parameters = null)
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

    public static string GetUserIdByGame(string gameId, User user)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("@gameId", gameId);
        string userColumn = user == User.First ? "firstUserId" : "secondUserId";
        var select = SelectData("select " + userColumn + " from Game where gameId = @gameId", parameters);
        return select.Rows.Count > 0 ? select.Rows[0][userColumn].ToString() : null;
    }
    public static bool IsGame(string gameId)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("@gameId", gameId);
        return SelectData("select Id from Game where gameId = @gameId", parameters)
               .Rows.Count > 0 ? true : false;
    }
}