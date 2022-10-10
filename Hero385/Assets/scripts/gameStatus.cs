using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameStatus : MonoBehaviour
{
    public TextMeshProUGUI status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        status.text = "HERO: Drive(" + (gameSystem.isMouse ? "Mouse" : "Key") + ") TouchedEnemy(" + gameSystem.heroCollisions + ")   EGG: OnScreen(" + gameSystem.eggsOnScreen + ")    ENEMY: Count(10) Destroyed(" + gameSystem.enemiesKilled + ")";
    }
}
