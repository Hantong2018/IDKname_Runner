﻿using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    private Vector3 inputValue;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if (!isLocalPlayer) {
            return;
        }

        inputValue.x = CrossPlatformInputManager.GetAxis("Horizontal");
        inputValue.y = 0f;
        inputValue.z = CrossPlatformInputManager.GetAxis("Vertical");

        transform.Translate(inputValue);
    }

    public override void OnStartLocalPlayer() {
        GetComponentInChildren<Camera>().enabled = true;
    }
}

