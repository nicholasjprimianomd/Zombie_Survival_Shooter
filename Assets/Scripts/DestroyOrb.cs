using UnityEngine;
using System.Collections;

public class DestroyOrb : MonoBehaviour {


	public float lifeTime = 3; 
	private float initalTime;
	private float currentTime;
	public float orbHealth = 3;

	void Awake(){
		initalTime = Time.time;
	}

	void Update ()
	{
		currentTime = Time.time;
		if(currentTime - initalTime > lifeTime ){
			Destroy(gameObject);
		}

		if(orbHealth == 0){
			Debug.Log ("Pop orb");	
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Bullet") {
			Destroy (gameObject);
		}
		if (coll.gameObject.tag == "Bullet") {
			orbHealth -= 1;
			Destroy (coll.gameObject);
		}
	}
}
