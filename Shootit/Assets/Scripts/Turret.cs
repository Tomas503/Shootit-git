using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float speed;							//rotation speed
	public Rigidbody ballPrefab;				//object being shot out of the turret
	public Transform barrelEnd;					//barrel end object used as start point of ball being shot
	public int turretHealth;
	public static Turret instance;

	public float timeBetweenShots = .333f;		//allow 3 shots per second

	public Material[] _ballColors;

	public Material curSBColor;
	public Material noColor;
	public Material curShootingBallColor = null;
	public Material nextShootingBallColor = null;
	public Material beforeNextShootingBallColor = null;

	
	private float timestamp;


	public float radius = 50.0F;				//radius for explosion
    public float force = 5000.0F;				//force of the explosion
	public float upwardModifier = 0.0F;			//upwardModifier for explosion
	public ForceMode forceMode;					//forceMode of ecplosion



//	public float radius = 50.0F;
 //   public float power = 100.0F;


	// Use this for initialization
	void Start () 
	{
		instance = this;
		_ballColors = GameObject.Find("GameManager").GetComponent<GameController>().ballColors;



		SetFirstSootingBallColors();

	
	}


	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			
		if(Time.time >= timestamp &&  (Input.GetKey(KeyCode.Space)) )   		
		{
			
			Fire();
		}
	
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.up * speed * Time.deltaTime);
			
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(Vector3.up * -speed * Time.deltaTime);

//		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
//			rb.AddRelativeForce(Vector3.forward * 100);
//
//		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
//			transform.Translate(Vector3.forward * (speed /4) * Time.deltaTime);
			

	
	}


	
	void Fire()						//shoot the ball
	{
		Rigidbody ballInstance = (Rigidbody) Instantiate( ballPrefab, barrelEnd.position, barrelEnd.rotation);
		ballInstance.velocity = barrelEnd.TransformDirection(Vector3.forward*20);

		ballInstance.GetComponent<Renderer>().material = curShootingBallColor;
		timestamp = Time.time + timeBetweenShots;

		LoadNextBallToShoot();
		
	}



	void SetFirstSootingBallColors()			//initial setup of ball colors at start of play
	{
		curShootingBallColor = _ballColors[ Random.Range(0, _ballColors.Length)];

		nextShootingBallColor = _ballColors[ Random.Range(0, _ballColors.Length)];

		beforeNextShootingBallColor = _ballColors[ Random.Range(0, _ballColors.Length)];  	//set ball material to one that is still left

	}


	void LoadNextBallToShoot()
	{
		curShootingBallColor = nextShootingBallColor;
		nextShootingBallColor = beforeNextShootingBallColor;

		GameObject[] tempGoStr = GameObject.FindGameObjectsWithTag("Enemy");  		//find all targetBalls 


		_ballColors = new Material[tempGoStr.Length];


	for(int i = 0; i <= tempGoStr.Length - 1; ++i)					//make new string of targetBall materials
		{
			GameObject tempGo = tempGoStr[i];						//temp gameobject to hold one gameobject from the string tempGoStr
											
			_ballColors[i] = tempGo.GetComponent<Renderer>().material;	//set materials in _ballColors to availiable targetball materials
		}

		if(_ballColors.Length >= 2)									//if two or more targetballs are left pick random material
		{
			beforeNextShootingBallColor = _ballColors[ Random.Range(0, _ballColors.Length)];

		}
		else if(_ballColors.Length == 1)								//if only 1 targetball left set material to same
		{
			beforeNextShootingBallColor = _ballColors[0];
		}
		else 														//when no target balls are left set material to noColor
		{
			beforeNextShootingBallColor = noColor;
			}
	}




	public void ChangeHealth(int changeAmount)
	{
		turretHealth -= changeAmount;
	}


	void OnCollisionEnter(Collision hitObject) 
	{
		//Debug.Log("hit by something");
		//Debug.Log("hit by"+ hitObject.gameObject.name);
		if(hitObject.gameObject.tag == "Enemy")
		{

			ChangeHealth(1);

			foreach(Collider col in Physics.OverlapSphere(transform.position, radius))  //blast back everything within radius
			{
				if(col.GetComponent<Rigidbody>() != null)
				{
					col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, upwardModifier, forceMode);
				}
			} 
		}

		if(hitObject.gameObject.tag == "Level")
		{
		Debug.Log("player hit the wall");	
//				if(gameObject.GetComponent<Rigidbody>() != null)
//				{
//				gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, upwardModifier, forceMode);
//				}
		}

	}

}
