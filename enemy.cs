using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class enemy : NetworkBehaviour {
    public int health;
    public float mspeed;
    int direction;
    public float timer = 0;
    bool directionChange;
   // Animator anim;
    public int thrust;
    public float changeTimer = 0f;
	//public GameObject player;
    // Use this for initialization
    void Start() {
        //anim = GetComponent<Animator>();
		direction = Random.Range(0,3);
        directionChange = false;
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer >= 1.5f) {
            timer = 0f;
            direction = Random.Range(0, 3);
        }
        Movement();
        if (directionChange) {
            changeTimer += Time.deltaTime;
            if (changeTimer >= 0.2f) {
                directionChange = false;
                changeTimer = 0f;
            }
        }
    }

    //[ServerCallback]
    void Movement() {
       // anim.SetInteger("movedirection", direction);
        if (direction == 0) {
            transform.Translate(0, mspeed * Time.deltaTime, 0);
        }
        if (direction == 1) {
            transform.Translate(-mspeed * Time.deltaTime, 0, 0);
        }
        else if (direction == 2) {
            transform.Translate(0, -mspeed * Time.deltaTime, 0);
        }
        else if (direction == 3) {
            transform.Translate(mspeed * Time.deltaTime, 0, 0);
        }

    }
		

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Walls") {
            if (directionChange)
            {
                return;
            }
            if (direction == 3)
            {
                direction = 1;
            }
            else if (direction == 2)
            {
                direction = 0;
            }
            else if (direction == 0)
            {
                direction = 2;
            }
            else if (direction == 1)
            {
                direction = 3;
            }
            directionChange = true;
        }

		if (col.gameObject.tag == "PlayerDie") {
			Destroy (col.gameObject);
			//SceneManager.LoadScene (1);
		}
    }


    private void OnTriggerEnter2D(Collider2D col) {
//        if (col.gameObject.tag == "PlayerDie") {
//            health -= 1;
//            if(health <= 0) {
//                //GameObject.FindGameObjectWithTag("ecount").GetComponent<EnemyCount>().enemies -= 1;
//                NetworkServer.Destroy(gameObject);
//            }
//            NetworkServer.Destroy(col.gameObject);
//        }
    }

}

