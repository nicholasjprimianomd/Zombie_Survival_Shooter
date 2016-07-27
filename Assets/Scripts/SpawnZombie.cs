using UnityEngine;
using System.Collections;

public class SpawnZombie : MonoBehaviour
{

	public GameObject zombie;
	public GameObject player;
	public float offsetRange = 5;

	void spawnZombie ()
	{
		float offset = Random.Range (-offsetRange - 100, offsetRange + 100);
		Vector3 zombeSpawnLocation = new Vector3 (player.transform.position.x + offset, player.transform.position.y + offset, player.transform.position.z);
		Instantiate (zombie, zombeSpawnLocation, Quaternion.identity);
	}

	void Start ()
	{
		InvokeRepeating ("spawnZombie", 1f, 2f);
	}
}
