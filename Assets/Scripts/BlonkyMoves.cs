using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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
    public float jumpForce = 1f;
    public bool grounded = true;

    public bool testing = false;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        //Direction selection
        if (Input.GetKey(KeyCode.RightArrow) || testing){
            GoRight();
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft();
        }
        else{
            Slow();
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
        if(speed > 0 && grounded){
            bool stopped = false;
            Collider2D box = gameObject.GetComponent<BoxCollider2D>();
            for (int i = 0; i < WallDetection.wallsLeft.Count; i++){
                if(box.IsTouching(WallDetection.wallsLeft[i].GetComponent<Collider2D>())){
                    stopped = true;
                }
            }
            if(stopped){
                speed = 0;
            }
        }
        if (speed < 0 && grounded)
        {
            bool stopped = false;
            Collider2D box = gameObject.GetComponent<BoxCollider2D>();
            for (int i = 0; i < WallDetection.wallsRight.Count; i++)
            {
                if (box.IsTouching(WallDetection.wallsRight[i].GetComponent<Collider2D>()))
                {
                    stopped = true;
                }
            }
            if (stopped)
            {
                speed = 0;
            }
        }
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

        //Jump
        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }
	}

    //Destroys Blonky
    private void Explode(){
        Instantiate(explosion).transform.position = transform.position;
        Destroy(gameObject);
    }

    //Increases right direction
    public void GoRight(){
        if (!started)
            started = true;
        movingDir = 1;
        transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
    }
    //Increases left direction
    public void GoLeft(){
        if (!started)
            started = true;
        movingDir = -1;
        transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
    }
    //Slows down when neither is pushed
    public void Slow()
    {
        movingDir = 0;
    }
}
