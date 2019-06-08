using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager 
{
    public static string username;
    public static string position;
    public static int tasks_solved;

    public static bool LoggedIn { get { return username != null && position != null; } }

    public static void LogOut()
    {
        username = null;
        position = null;
    }
}
