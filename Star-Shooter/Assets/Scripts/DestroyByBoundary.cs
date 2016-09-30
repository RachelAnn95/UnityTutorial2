using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerExit(Collider other){
		
		Destroy (other.gameObject);
	}

}
