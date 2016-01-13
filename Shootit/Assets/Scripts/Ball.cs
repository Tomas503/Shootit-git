using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballLifeTime ;		//length of time before ball is destroyed
//	public Material[] ballColors;			//possible colors of the ball array
	public string ballCo;					//color of this ball instance
	public string ballCoInstance;			//color of this ball instance with (Instance) added to its name
	public bool sameColor = false;


	// Use this for initialization
	void Start () 
	{
		SetMatColor(gameObject.GetComponent<Renderer>().material.name);
	//	PickColor();
//		ballCo = GetComponent<Renderer>().material.name;
//
//		while(ballCo.Length >= 10)
//		{
//			ballCoInstance = ballCo.Substring(0, ballCo.Length - 11);
//			ballCo = ballCoInstance;
//		}

//		if (ballCoInstance.Length > 10)
//		{
//			ballCoInstance = ballCoInstance.Substring(0, ballCo.Length - 10);
//		}
	}

	void Update() 
	{			
		
		Destroy(gameObject, ballLifeTime);

		
	}

	void OnCollisionEnter(Collision hitObject) 
	{

		if (hitObject.gameObject.tag == "Enemy")
        {
			string enemyColor = hitObject.gameObject.GetComponent<Renderer>().material.name;

			if(ballCo == enemyColor )
			{
				hitObject.gameObject.transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
	        	hitObject.gameObject.GetComponent<TargetBall>().health -= 1;
	            Destroy(gameObject);
        	}
	
       	}

        
    }


	void SetMatColor(string colorName)
	{
//		Debug.Log("color name " + colorName);
		if(colorName.Length > 5)
		{
			colorName = colorName.Substring(0, 4);

	//		Debug.Log("tempString " + tempString[0]);
			gameObject.GetComponent<Renderer>().material.name = colorName;
			ballCo = colorName;
		}
		else
			ballCo = colorName;
	}



}
