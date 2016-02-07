using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
	Transform Player;
	Transform myTransform;
	public Rigidbody bullet;
	public Transform shotSpawn;
	public float velocity = 10.0f;
	public float fireRate;
	public float delay;
	public float moveSpeed;
	public float rotationSpeed;
	public float range;
	public float range2;
	public float stop;

	void Awake()
	{
		myTransform = transform; 
	}
	
	// Update is called once per frame
	void Start ()
	{
		Player = GameObject.FindWithTag ("Player").transform;
		InvokeRepeating ("Fire", delay, fireRate);
	}
	
	void Fire ()
	{
		Rigidbody newBullet = Instantiate(bullet,shotSpawn.position,shotSpawn.rotation) as Rigidbody;
		newBullet.AddForce(transform.forward*velocity,ForceMode.VelocityChange);
		GetComponent<AudioSource>().Play();
	}
	
	void Update () 
	{
		//rotate to look at the player
		var distance = Vector3.Distance(myTransform.position, Player.position);
		if (distance<=range2 &&  distance>=range){
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			                                        Quaternion.LookRotation(Player.position - myTransform.position), rotationSpeed*Time.deltaTime);
		}
		
		
		else if(distance<=range && distance>stop){
			
			//move towards the player
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			                                        Quaternion.LookRotation(Player.position - myTransform.position), rotationSpeed*Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		else if (distance<=stop) {
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			                                        Quaternion.LookRotation(Player.position - myTransform.position), rotationSpeed*Time.deltaTime);
		}
	}
}
