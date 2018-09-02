using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundDetection : MonoBehaviour {
    public static List<GroundDetection> groundElements = new List<GroundDetection>();

	// Use this for initialization
	void Start () {
        groundElements.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
        bool contacted = false;
        Collider2D blonky = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        for (int i = 0; i < groundElements.Count; i ++){
            Collider2D curr = groundElements[i].GetComponent<Collider2D>();
            if(curr.IsTouching(blonky)){
                contacted = true;
            }
        }

        if (contacted)
        {
            blonky.gameObject.GetComponent<BlonkyMoves>().grounded = true;
        }
        else{
            blonky.gameObject.GetComponent<BlonkyMoves>().grounded = false;
        }
	}
}
