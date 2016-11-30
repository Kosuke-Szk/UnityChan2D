using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {
    bool gameOverFlag = false;

    void Start () 
    {
        gameObject.GetComponent<Text>().enabled = false;
	}
	
	
	void Update () 
    {
        if (gameOverFlag == true && Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("Title");
        }
	}

    public void Lose()
    {
        gameObject.GetComponent<Text>().enabled = true;
        gameOverFlag = true;
    }
}
