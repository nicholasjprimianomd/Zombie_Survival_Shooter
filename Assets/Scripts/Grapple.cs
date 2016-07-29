using UnityEngine;
using System.Collections;

public class Grapple : MonoBehaviour {

	private Transform startMarker;
	private Transform endMarker;
	public float speed = .5F;
	public GameObject enemy;
	private float startTime;
	private float journeyLength;
	float fracJourney;
	float distCovered;
	private GameObject player;
	private bool isLerping = false;

	void Start() {
		startTime = Time.time;
	}

	void Update() {
		player = GameObject.FindGameObjectWithTag ("Player");
		distCovered = (Time.time - startTime) * speed;
		if (isLerping) {
			player.transform.position = Vector3.MoveTowards (startMarker.position, endMarker.position, .5f);
			if(player.transform.position == endMarker.position){
				isLerping = false;
				Destroy (gameObject);
			}
		}
		//lerp ();
	}
		
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall") {
			startMarker = player.transform;
			endMarker = transform;

			//player.transform.position = Vector3.Lerp (startMarker.position, endMarker.position, 1);

			//player.transform.position = Vector3.MoveTowards (startMarker.position, endMarker.position, 2);
			isLerping = true;
		}
	}

//	void lerp(){
//		if (isLerping) {
//			journeyLength = Vector3.Distance (startMarker.position, endMarker.position);
//			fracJourney = distCovered / journeyLength;
//			player.transform.position = Vector3.Lerp (startMarker.position, endMarker.position, fracJourney);
//			Debug.Log ("End marker: " + endMarker.position.ToString());
//			Debug.Log ("startMarker: " + startMarker.position.ToString());
//			if(fracJourney == 1){
//				isLerping = false;
//			}
//		}
//	}


}
