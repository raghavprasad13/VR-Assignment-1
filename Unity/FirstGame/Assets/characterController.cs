/*
 * Script to control character movement in z and x directions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
	public float speed = 10.0f;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;   // Lock out cursor for the game
    }

    // Update is called once per frame
    void Update() {
        float translation = Input.GetAxis("Vertical") * speed;  // Front and back
        float strafe = Input.GetAxis("Horizontal") * speed;     // Strafing sideways
        translation *= Time.deltaTime;  // Ensures smooth motion
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0.0f, translation);

        if(Input.GetKeyDown("escape"))  // Press 'esc' to regain cursor control
        	Cursor.lockState = CursorLockMode.None;
    }
}
