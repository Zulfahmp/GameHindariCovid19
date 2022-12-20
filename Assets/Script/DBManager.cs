using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string nama;
    public static int score;

    public static bool LoggedIn
    {
        get
        {
            return nama != null;
        }
    }
}
