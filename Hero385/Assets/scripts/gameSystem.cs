using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class gameSystem
{
    public static int eggsOnScreen = 0;
    public static int enemiesKilled = 0;
    public static int heroCollisions = 0;
    public static bool isMouse = true;
    public static void spawnEgg(GameObject e, Vector3 pos, Vector3 up) 
    {
        e.transform.position = pos;
        e.transform.up = up;
        eggsOnScreen++;
    }


    public static void decreaseEggCount() {
        eggsOnScreen--;
    }

    public static void increaseDefeated() {
        enemiesKilled++;
    }

    public static void increaseCollisions() {
        heroCollisions++;
    }

}
