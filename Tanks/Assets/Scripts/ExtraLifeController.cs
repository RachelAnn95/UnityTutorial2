using UnityEngine;
using System.Collections;

public class ExtraLifeController : MonoBehaviour {

	public void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {

			Destroy (gameObject);
		}
	}
}
