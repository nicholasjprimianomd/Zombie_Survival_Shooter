using UnityEngine;
using System.Collections;

public class SpawnZombie : MonoBehaviour
{

	public GameObject zombie;
	public GameObject player;

	void spawnZombie ()
	{
		Instantiate (zombie, player.transform.position, Quaternion.identity);
	
	}

	void Start ()
	{
		InvokeRepeating ("spawnZombie", 2f, 2f);
	}

	void Update ()
	{
		
	}

}
