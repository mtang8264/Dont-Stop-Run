using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {
    private Transform blonky;

	// Use this for initialization
	void Start () {
        blonky = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if(blonky.position.x - 22.5f - 11.25f > transform.position.x){
            transform.Translate(new Vector3(67.5f, 0f, 0f));
        }else if(blonky.position.x + 22.5f + 11.25f < transform.position.x){
            transform.Translate(new Vector3(-67.5f, 0f, 0f));
        }

        if(blonky == null){
            Destroy(this);
        }
	}
}
