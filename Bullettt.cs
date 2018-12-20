using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class Bullettt : NetworkBehaviour {
//	[SerializeField]
//	private string enemyTag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}
	}
//
	void OnCollisionEnter2D(Collision2D c)
	{
//		var player = c.gameObject.GetComponent<MOvement> ();
//		Debug.Log ("work");
//		if (player != null) {
//			Debug.Log ("work1");
//
//			//var Hp = c.gameObject.GetComponent<HealthPlayer> ();
//			//Hp.PlayerHealth (5);
//			SceneManager.LoadScene(1);
//			//Destroy (c.gameObject);
//		if (c.gameObject.tag == "die") {
//
//			//Application.LoadLevel (1);
//			Destroy (gameObject);
//			Debug.Log ("work");
//		}
//
//		
//		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "die") {
			
			//Application.LoadLevel (1);
			Destroy (col.gameObject);
			Debug.Log ("work");
//			if () {
//				SceneManager.LoadScene (2);
//			}
		}
	}

}
