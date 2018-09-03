using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour {
    public static List<WallDetection> wallsRight = new List<WallDetection>();
    public static List<WallDetection> wallsLeft = new List<WallDetection>();
    public bool left = false;

	// Use this for initialization
	void Start () {
        if(left){
            wallsLeft.Add(this);
        }else{
            wallsRight.Add(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
