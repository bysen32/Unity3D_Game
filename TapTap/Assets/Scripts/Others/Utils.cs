using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class UI
{
    public static GameObject Root
    {
        get { return GameObject.Find("UI Root"); }
    }
}

public static class GameWorld
{
    public static GameObject Instance
    {
        get { return GameObject.Find("GameWorld"); }
    }
}