using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlonkyMoves : MonoBehaviour {
    //-1 is left, 0 is not moving, 1 is right
    private int movingDir = 0;
    private float speed = 0f;
    private bool started = false;
    private bool timing = false;
    private float timer = 0f;

    public float acceleration = 0.1f;
    public float speedMultiplier = 0.1f;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        //Direction selection
        if (Input.GetKey(KeyCode.RightArrow)){
            if (!started)
                started = true;
            movingDir = 1;
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!started)
                started = true;
            movingDir = -1;
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }
        else{
            movingDir = 0;
        }

        //Speed curve
        if (movingDir == 1 && speed < Mathf.PI/2){
            speed += acceleration;
        }else if(movingDir == -1 && speed > -Mathf.PI/2){
            speed -= acceleration;
        }else{
            if(speed > 0){
                speed -= acceleration;
            }else if(speed < 0){
                speed += acceleration;
            }
        }

        //Speed zeroing
        if(speed < 0.01f && speed > -0.01f){
            speed = 0f;
        }
        //Transformation
        transform.Translate(new Vector3(Mathf.Sin(speed) * speedMultiplier, 0f, 0f));
        //Animation change
        if(speed != 0f){
            timing = false;
            gameObject.GetComponent<Animator>().SetBool("Walking", true);
        }else{
            gameObject.GetComponent<Animator>().SetBool("Walking", false);
            if (started){
                if(timing == false){
                    timing = true;
                    timer = Time.time;
                }else if(Time.time > timer + .75f){
                    Explode();
                }
            }
        }
	}

    private void Explode(){
        Instantiate(explosion).transform.position = transform.position;
        Destroy(gameObject);
    }
}
