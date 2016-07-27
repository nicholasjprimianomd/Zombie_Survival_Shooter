using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

public class UIShowPlayerHealth : MonoBehaviour
{
	public PlayerTakeDamage player;
	private Text playerHealthText;

	void Start ()
	{
		playerHealthText = GetComponent<Text> ();
	}

	//Show player Health on UI
	void Update ()
	{
		playerHealthText.text = "Health : " + player.currentHealth.ToString ();
	}
}
