using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
   
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Button"))
        {
			GameObject obj = collision.collider.transform.parent.gameObject;
			Debug.Log("Touched a button");
            obj.GetComponent<DoorController>().openDoor();
        }
        else if(collision.collider.gameObject.layer == LayerMask.NameToLayer("LandMine"))
        {	
			GameObject obj = collision.collider.transform.gameObject;
			Destroy(obj);
			Debug.Log("Touched a landmine");
 //           obj.GetComponent<DoorController>().openDoor();
        }
        //obj.GetComponent<DoorController>().openDoor();
        Destroy(gameObject);

    }
}
