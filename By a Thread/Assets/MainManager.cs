using UnityEngine;

// for maintaining state between scenes
public static class MainManager
{
    public static int lastLevelUnlocked = 1;

    public static void setLastLevelUnlocked(int level)
    {
        lastLevelUnlocked = level;
    }

}