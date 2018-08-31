using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControls : MonoBehaviour {
    public Transform blonky;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (blonky != null)
        {
            if (blonky.position.x > transform.position.x + 6f)
            {
                transform.position = new Vector3(blonky.position.x - 6f, transform.position.y, transform.position.z);
            }
            else if (blonky.position.x < transform.position.x - 6f)
            {
                transform.position = new Vector3(blonky.position.x + 6f, transform.position.y, transform.position.z);
            }
        }
	}

    public void Disasociate(){
        blonky = null;
    }
}
