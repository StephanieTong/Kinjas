﻿using UnityEngine;
using System.Collections;

public class NinjaGroundChecker : MonoBehaviour {

	private NinjaController parentScript;
	private Animator anim;
	
	void Awake() {
		GameObject parentObject = transform.parent.gameObject;
		parentScript = parentObject.GetComponent<NinjaController> ();
		anim = parentObject.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		// revert Ninja back to idle animation
		if (col.gameObject.tag == "ground" || col.gameObject.tag == "ninja"){
			anim.SetBool ("PressJump", false);
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		// set flag for grounded
		if (col.gameObject.tag == "ground") {
			parentScript.setGrounded(true);
			//parentScript.setJump(false);
		}
	}


	void OnTriggerExit2D (Collider2D col){
		// Set flags for Ninja no longer grounded
		if (col.gameObject.tag == "ground") {
			parentScript.setJump (false);
			parentScript.setGrounded (false);
		}

	}

	                     

}