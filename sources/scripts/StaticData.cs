using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData //: MonoBehaviour
{
    //currently playing
    public static int playingLevel = 0;
    
    //For level completion
    public static int maxLevelCompleted = 0;

    //For level statistics
    public static int actualLevel = 0;
    public static int watermelonCollected = 0;
    public static int watermelonTotal = 0;
    public static int chickCollected = 0;
    public static int chickTotal = 0;
    public static int death = 0;
    public static float time = 0;

    //For Fox Alert image
    public static bool[] foxIsClose = new bool[3];

    public static bool shouldAlertBeVisible()
    {
        return (foxIsClose[0] || foxIsClose[1] || foxIsClose[2]);
    }

    public static int calculateScore()
    {
        float score = 10000;

        score = score - time * 5;

        score = score - 150 * (watermelonTotal - watermelonCollected);

         score = score - 400 * death;

        if(score < 0)
        {
            return 0;
        }

        return (int) score;

    }

    public static void updateMaxLevelCompleted()
    {
        if(actualLevel > maxLevelCompleted)
        {
            maxLevelCompleted = actualLevel;
        }
    }

}
