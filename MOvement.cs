using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MOvement : NetworkBehaviour {

	private MovementSyncroniz Ms;
	public GameObject bullet;
	//[SyncVar (hook = "CmdFlipSprite")]
	//public bool isFacingRight = true;
	// Use this for initialization
	public bool facingRight;
	bool isgrounded = true;
	MovementSyncroniz syncPos;

	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Awake()
	{
		syncPos = GetComponent<MovementSyncroniz> ();
	}
	

	void Update () {

		if (!isLocalPlayer) {
			return;
		}

		float x = Input.GetAxis ("Horizontal") * 10f * Time.deltaTime;
		float z = Input.GetAxis ("Vertical") * 10f * Time.deltaTime;
		transform.Translate (x, 0, z);

		if (Input.GetKeyDown (KeyCode.Space) && isgrounded==true) {
			if (facingRight) {
				CmdAaa ();
			} else if (!facingRight) {
				CmdAaa1 ();
			}
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (isgrounded == true) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 10), ForceMode2D.Impulse);
			}

		}

		if ((x > 0 && !facingRight) || (x < 0 && facingRight)) {
			facingRight = !facingRight;
			syncPos.CmdFlipSprite (facingRight);
		}
		

//		if (Input.GetKeyDown(KeyCode.D) && !isFacingRight)
//		{
//			isFacingRight = true;
//		}
//		if (Input.GetKeyDown(KeyCode.A) && isFacingRight)
//		{
//			isFacingRight = false;
//		}

		
	}

//	public override void OnStartLocalPlayer()
//	{
//		GetComponent<MeshRenderer> ().material.color = Color.green;
//
//	}
		
	[Command]
	public void CmdAaa()
	{
		var bul = (GameObject)Instantiate (bullet, transform.position - transform.forward, Quaternion.identity);
		bul.GetComponent<Rigidbody2D> ().velocity = transform.right * 100;
		NetworkServer.Spawn (bul);
		Destroy (bul, 2);
	}

	[Command]
	public void CmdAaa1()
	{
		var bul = (GameObject)Instantiate (bullet, transform.position - transform.forward, Quaternion.identity);
		bul.GetComponent<Rigidbody2D> ().velocity = -transform.right * 100;
		NetworkServer.Spawn (bul);
		Destroy (bul, 2);
	}
//		} else {
//			var bul = (GameObject)Instantiate (bullet, transform.position - transform.forward, Quaternion.identity);
//			bul.GetComponent<Rigidbody2D> ().velocity = transform.right * 100;
//			NetworkServer.Spawn (bul);
//			Destroy (bul, 2);
		//}
//
//	}
//	[Command]
//	void CmdFlipSprite(bool flip)
//	{
//		//transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
//		GetComponent<SpriteRenderer>().flipX=flip;
//	}


	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag=="Walls") {
			isgrounded = true;
		}
	}
	void OnCollisionExit(Collision c)
	{
		if (c.gameObject.tag=="Walls") {
			isgrounded = false;
		}
	}

}


