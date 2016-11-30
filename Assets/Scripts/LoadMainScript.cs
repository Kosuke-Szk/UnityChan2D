using UnityEngine;
using System.Collections;

public class LoadMainScript : MonoBehaviour 
{
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("Main");
        }
	}
}
