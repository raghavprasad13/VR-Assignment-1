/*
 * Script to enable camera rotation about x and y axes using mouse actions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour {
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;	// Mouse action sensitivity
	public float smoothing = 2.0f;		// Mouse action smoothing constant

	GameObject character;
    // Start is called before the first frame update
    void Start() {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update() {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f/smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f/smoothing);

        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
