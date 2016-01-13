using UnityEngine;
using System.Collections;

public class TargetBall : MonoBehaviour {


    public Rigidbody rb;
    public int health;
    public Transform target;
    public float speed;

    Turret turret;



    void Start() {
    	target = GameObject.Find("Turret").transform;
        rb = GetComponent<Rigidbody>();
        health = 3;

        SetMatColor(gameObject.GetComponent<Renderer>().material.name);
    }

    void Update()
    {

		float power = speed * 2 * Time.deltaTime;
		transform.LookAt(target);
      	rb.AddRelativeForce(0, 0, power);
    	
		if(health <=0 )
    	{
    		
			Destroy(gameObject);
		}
    }


	void OnCollisionEnter(Collision hitObject) 
	{
		
//		Debug.Log("hit "+ hitObject.gameObject.name);
		if(hitObject.gameObject.name == "Turret")
		{
//			Debug.Log("hit Turret");
			hitObject.gameObject.GetComponent<Turret>().curShootingBallColor = gameObject.GetComponent<Renderer>().material;
			hitObject.gameObject.GetComponent<Turret>().nextShootingBallColor = gameObject.GetComponent<Renderer>().material;
			hitObject.gameObject.GetComponent<Turret>().beforeNextShootingBallColor = gameObject.GetComponent<Renderer>().material;
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

		}
	}

}
