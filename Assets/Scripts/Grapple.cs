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

	void Start() {

	}

	void Update() {
		player = GameObject.FindGameObjectWithTag ("Player");

		if (isLerping && isWall) {
			Debug.Log ("Moving toward wall");
			player.transform.position = Vector3.MoveTowards (startMarker.position, endMarker.position, .5f);
			if(player.transform.position == endMarker.position){
				isLerping = false;
				isWall = false;
				Destroy (gameObject);
			}
		}

		if (isLerping && enemy) {
			Debug.Log ("Moving toward enemy");
			enemy.transform.position = Vector3.MoveTowards (enemy.transform.position, player.transform.position, .2f);
			if(Vector3.Distance (enemy.transform.position, player.transform.position) < 0.5f){
				
				isLerping = false;
				isEnemy = false;
				enemy.GetComponent<ZombieMove> ().canMove = true;

				Destroy (gameObject);
			}
		}
	}
		
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall") {
			startMarker = player.transform;
			endMarker = transform;
			isLerping = true;
			isWall = true;
		}

		if (coll.gameObject.tag == "Zombie") {
			enemy = coll.gameObject;
			//startMarker = enemy.transform;
			isLerping = true;
			isEnemy = true;
			enemy.GetComponent<ZombieMove> ().canMove = false;

			Debug.Log ("Enemy contact, isEnemy: " + isEnemy);
		}

	}

}
