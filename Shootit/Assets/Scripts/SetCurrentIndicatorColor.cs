using UnityEngine;
using System.Collections;

public class SetCurrentIndicatorColor : MonoBehaviour {

	public Material indicatorColor = null;

	// Use this for initialization
	void Start () 
	{
		indicatorColor = GameObject.Find("Turret").GetComponent<Turret>().curShootingBallColor;
		GetComponent<Renderer>().material = indicatorColor;
	
	}


	
	// Update is called once per frame
	void Update () 
	{

		indicatorColor = GameObject.Find("Turret").GetComponent<Turret>().curShootingBallColor;
		GetComponent<Renderer>().material = indicatorColor;

	
	}
}
