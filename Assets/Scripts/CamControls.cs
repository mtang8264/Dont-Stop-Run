using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControls : MonoBehaviour {
    public Transform blonky;

    private bool vertTiming = false;
    private float vertStart;
    private bool adjusting = false;
    private float startHeight;
    private float track = 0;

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

        if (!adjusting)
        {
            if (blonky.position.y + 2.985 > transform.position.y)
            {
                if (!vertTiming)
                {
                    vertStart = Time.time;
                }
                vertTiming = true;
            }
            else
            {
                vertTiming = false;
            }

            if (vertTiming && Time.time > vertStart + 3f)
            {
                AdjustVert();
            }
        }else{
            Vector3 start = new Vector3(transform.position.x, startHeight,-10);
            Vector3 end = new Vector3(transform.position.x, blonky.position.y,-10);
            transform.position = Vector3.Lerp(start, end, track);
            track += 0.1f;
        }
	}

    public void AdjustVert(){
        adjusting = true;
        startHeight = transform.position.y;
    }

    public void Disasociate(){
        blonky = null;
    }
}
