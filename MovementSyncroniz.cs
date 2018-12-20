using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovementSyncroniz : NetworkBehaviour {

	//private MOvement MO;

	[SyncVar (hook = "FacingCallback")]
	public bool netFacingRight = true;
	// Use this for initialization

	[Command]
	public void CmdFlipSprite(bool facing)
	{
		netFacingRight = facing;
		if (netFacingRight) {
			Vector3 SpriteScale = transform.localScale;
			SpriteScale.x = 1;
			transform.localScale = SpriteScale;

		} else {
			Vector3 SpriteScale = transform.localScale;
			SpriteScale.x = -1;
			transform.localScale = SpriteScale;

		}
	}

	void FacingCallback(bool facing)
	{
		netFacingRight = facing;
		if (netFacingRight) {
			Vector3 SpriteScale = transform.localScale;
			SpriteScale.x = 1;
			transform.localScale = SpriteScale;

		} else {
			Vector3 SpriteScale = transform.localScale;
			SpriteScale.x = -1;
			transform.localScale = SpriteScale;

		}
	}


}
