using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shell : NetworkBehaviour {

    public float shelllifetime = 1f;
    float currlife;

    [ServerCallback]
    void Update() {
        currlife += Time.deltaTime;
        if (currlife > shelllifetime) {
            NetworkServer.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "wall") {
            NetworkServer.Destroy(gameObject);
            NetworkServer.Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Unbreakable") {
            NetworkServer.Destroy(gameObject);
        }
    }
}
