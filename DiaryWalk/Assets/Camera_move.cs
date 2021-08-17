using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Camera_move : MonoBehaviour {



	public float smoothTimeX, smoothTimeY;

	public Vector2 velocity;

	public GameObject player;

	public Vector2 minPos, maxPos;

	public bool bound;





	// 캐릭터 초기화
	void Awake() {
		Screen.SetResolution(1280, 720, true);

	}
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

	}



	// 캐릭터의 위치에 따라 카메라가 이동

	void FixedUpdate () {

		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);

		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		// 카메로 이동

		transform.position = new Vector3 (posX, posY+1, transform.position.z);



		if(bound) {


			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minPos.x, maxPos.x),

				Mathf.Clamp (transform.position.y, minPos.y, maxPos.y),

				Mathf.Clamp (transform.position.z, transform.position.z, transform.position.z)

			);

		}

	}

}
