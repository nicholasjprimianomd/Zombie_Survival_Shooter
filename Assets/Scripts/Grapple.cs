using UnityEngine;
using System.Collections;

public class Grapple : MonoBehaviour {

	private Transform startMarker;
	private Transform endMarker;
	public float speed = .5F;
	private GameObject player;
	private GameObject enemy;
	private bool isLerping = false;
	private bool isWall = false;
	private bool isEnemy = false;
	private bool canCollide;

	void Awake() {
		canCollide = true;
	}

	void Update() {
		player = GameObject.FindGameObjectWithTag ("Player");

		if (isLerping && isWall) {
			player.transform.position = Vector3.MoveTowards (startMarker.position, endMarker.position, .5f);
			if(player.transform.position == endMarker.position){
				isLerping = false;
				isWall = false;
				DestroyImmediate (gameObject);
			}
		}

		if (isLerping && isEnemy) {
			Debug.Log ("Moving toward enemy");
			enemy.transform.position = Vector3.MoveTowards (enemy.transform.position, player.transform.position, .15f);
			if(Vector3.Distance (enemy.transform.position, player.transform.position) < 1f){
				isLerping = false;
				isEnemy = false;
				enemy.GetComponent<ZombieMove> ().canMove = true;
				DestroyImmediate (gameObject);
			}
		}

	}
		
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (canCollide) {
			if (coll.gameObject.tag == "Wall") {
				startMarker = player.transform;
				endMarker = transform;
				isLerping = true;
				isWall = true;
				canCollide = false;
			}

			if (coll.gameObject.tag == "Zombie") {
				enemy = coll.gameObject;
				isLerping = true;
				isEnemy = true;
				enemy.GetComponent<ZombieMove> ().canMove = false;
				canCollide = false;
			}
		}

	}

}
