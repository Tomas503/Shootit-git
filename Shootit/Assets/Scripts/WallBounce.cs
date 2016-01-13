using UnityEngine;
using System.Collections;

public class WallBounce : MonoBehaviour {

	public float radius = 50.0F;				//radius for explosion
    public float force = 5000.0F;				//force of the explosion
	public float upwardModifier = 0.0F;			//upwardModifier for explosion
	public ForceMode forceMode;					//forceMode of ecplosion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		
	
	}



	void OnCollisionEnter(Collision hitObject) 
	{
		Debug.Log("player hit something");
		//Debug.Log("hit by something");
		//Debug.Log("hit by"+ hitObject.gameObject.name);
		if(hitObject.gameObject.tag == "Player")
		{

		Debug.Log("player hit the wall");	

			foreach(Collider col in Physics.OverlapSphere(transform.position, radius))  //blast back everything within radius
			{
				if(col.GetComponent<Rigidbody>() != null)
				{
					col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, upwardModifier, forceMode);
				}
			} 
		}
	}
}
