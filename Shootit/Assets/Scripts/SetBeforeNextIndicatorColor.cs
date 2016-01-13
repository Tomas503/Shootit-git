using UnityEngine;
using System.Collections;

public class SetBeforeNextIndicatorColor : MonoBehaviour {

	public Material indicatorColor = null;

	// Use this for initialization
	void Start () 
	{
		indicatorColor = GameObject.Find("Turret").GetComponent<Turret>().beforeNextShootingBallColor;
		GetComponent<Renderer>().material = indicatorColor;
	
	}


	
	// Update is called once per frame
	void Update () 
	{

		indicatorColor = GameObject.Find("Turret").GetComponent<Turret>().beforeNextShootingBallColor;
		GetComponent<Renderer>().material = indicatorColor;

	
	}
}
