using UnityEngine;
using System.Collections;

public class DestroyOrb : MonoBehaviour {

	public float lifeTime = 3; 
	private float initalTime;
	private float currentTime;
	public float orbHealth = 3;
	public float explosionRadius = 5 ;

	void Awake(){
		initalTime = Time.time;
	}

	void Update ()
	{
		currentTime = Time.time;
		if(currentTime - initalTime > lifeTime ){
			Destroy(gameObject);
		}
		Vector3 center = transform.position;

		if(orbHealth == 0){
			ExplosionDamage(center);
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
		
	void ExplosionDamage(Vector3 center) {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, explosionRadius);
		int i = 0;
		while (i < hitColliders.Length) {
			
				hitColliders [i].SendMessage ("AddDamage");
				Debug.Log ("Pop orb");
			if (hitColliders [i].tag != "Player") {
				Destroy (hitColliders [i].gameObject);
			}
				i++;
			
		}
	}
}
