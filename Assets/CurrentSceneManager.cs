using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentSceneManager
{
    static public int PlayerMaxHealth = 5;
    static public int PlayerHealth = 5;
    public static void ResetHealth()
    {
        PlayerHealth = PlayerMaxHealth;
    }
}
