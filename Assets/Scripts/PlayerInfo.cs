using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInfo
{
    public static string _gameMode;
    public static string _difficulty;
    public static int _levelSelection;
    public static string _prefabSelection;
    
    public static int[] GetDifficulty()
    {
        switch (_difficulty) 
        {
            case "Easy":
                return new int[] {0, 10};                
            case "Normal":
                return new int[] {0, 20};
            case "Hard":
                return new int[] {0, 30};
            default: return new int[] { 0, 10 };

        }        
    }
}
