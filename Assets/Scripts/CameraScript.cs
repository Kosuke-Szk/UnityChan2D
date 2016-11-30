using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    public Text scoreText;
    public GameOverScript gameOverScript;
    private int score = 0;
    private int scoreUpPos = 3;
    private Transform playerTrans;

	void Start () 
    {
        playerTrans = player.GetComponent<Transform>();
        scoreText.text = "Score : 0";
    }
	
	void Update () 
    {
        float playerHeight = playerTrans.position.y;
        float currentCameraHeight = transform.position.y;
        float newHeight = Mathf.Lerp(currentCameraHeight, playerHeight, 0.5f);
        if (playerHeight > currentCameraHeight)
        {
            transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        }

        if (playerTrans.position.y >= scoreUpPos)
        {
            scoreUpPos += 3;
            score += 10;
            scoreText.text = "Score : " + score.ToString();
        }

        if (playerTrans.position.y <= currentCameraHeight - 6)
        {
            gameOverScript.Lose();
            Destroy(player);
        }
	}
}
