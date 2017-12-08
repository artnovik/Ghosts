using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsManager : MonoBehaviour {

    //Private
    private float randomizerX,
                  lastRandX;
    private int randomizerSpeed;
    private float yPos = -4.25f;
    private GameObject Ghost;

    //Public
    public int numberOfGhosts = 0;
    public bool isGameStarted = false;
    public GameObject GhostInstance;

    public void CreateGhost()
    {
        if (numberOfGhosts == 10)
            return;
        
        randomizerX = Random.Range(-5.75f, 5.75f);
        while(lastRandX == randomizerX) //Prevent further equal spawns
            randomizerX = Random.Range(-5.75f, 5.75f);
        lastRandX = randomizerX;

        Ghost = Instantiate(GhostInstance as GameObject);
        Ghost.transform.SetParent(transform);
        Ghost.transform.position = Vector2.up * yPos + Vector2.right * randomizerX;

        numberOfGhosts++;

        if (!isGameStarted)
            isGameStarted = true;
    }
    
}
