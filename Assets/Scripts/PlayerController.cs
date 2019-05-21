using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Camera cam;
	private float speed=50f;

	void FixedUpdate(){
		float movez = Input.GetAxis ("Vertical") * speed;
		float movex = Input.GetAxis ("Horizontal") * speed;
		float rot = cam.transform.rotation.eulerAngles.y;

		movez *= Time.deltaTime;
		movex *= Time.deltaTime;
		transform.Translate (movex, 0, movez);
		transform.rotation = Quaternion.Euler(0,rot,0);
	}
}
