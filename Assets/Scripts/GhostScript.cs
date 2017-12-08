using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

    //Private
    private int randomizerSpeed;

    // Use this for initialization
    private void Start () {
        randomizerSpeed = Random.Range(1, 10);
    }

    // Update is called once per frame
    private void Update ()
    {
        if (GameObject.Find("Ghosts").GetComponent<GhostsManager>().isGameStarted)
        {
            GhostDeathCheck();
            GhostMovement();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("UI").GetComponent<UIManager>().Score += 10;
            GameObject.Find("UI").GetComponent<UIManager>().ScoreText.text = "Score: " + GameObject.Find("UI").GetComponent<UIManager>().Score;
        }
    }


    private void GhostMovement()
    {
        gameObject.GetComponent<CharacterController>().Move(Vector2.up * randomizerSpeed * Time.deltaTime);
    }

    private void GhostDeathCheck()
    {
            if (gameObject.transform.position.y >= 4.35)
            {
                Destroy(gameObject);
                GameObject.Find("Ghosts").GetComponent<GhostsManager>().numberOfGhosts--;
                GameObject.Find("UI").GetComponent<UIManager>().NumberOfGhostsText.text = "Ghosts: " + GameObject.Find("Ghosts").GetComponent<GhostsManager>().numberOfGhosts;
            }
    }
}
