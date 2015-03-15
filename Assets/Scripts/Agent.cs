using UnityEngine;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Agent : Targetable {
	Vector3 destination;
	public float speed;
	float delay;
	float curspeed;
	public bool sick;
	public bool quarantined;
	public float zoneShiftProbability;
	float progress;
	static IEnumerable<Trait> traits;
	static IEnumerable<Symptom> symptoms;
	public Zone node;
	// Use this for initialization
	void Start () {
		//Initialize movement
		this.curspeed = this.speed;

		//Initialize infection related
		Agent.traits = Trait.traits.Shuffle().Take(3);
		Agent.symptoms = Symptom.symptoms.Shuffle ().Take (3);

		//Initialize the quarantine state
		this.quarantined = false;
		//Initialize the first node this agent belongs to
		node = GameSystem.instance.zones.Shuffle().ToList()[0];

	}
	
	// Update is called once per frame
	void Update () {
		// Billboard stuff in the direction of the camera
		this.transform.LookAt (CameraController.instance.transform);
		// Test if we should move in a different node
		bool areWeThereYet = (this.transform.position - node.transform.position).sqrMagnitude 
			< Mathf.Pow (node.transform.localScale.x, 2);
		if (!quarantined && areWeThereYet && Random.value < zoneShiftProbability) {
			this.ChangeNode ();
		}
		if (areWeThereYet) {
			this.Loiter ();
		} else {
			this.curspeed = this.speed;
			this.Move (node.transform.position);
		}
		// Move towards the target

	}
	void ChangeNode(){
		node=GameSystem.instance.zones.Shuffle().ToList()[0];
	}
	void Loiter(){
		this.progress += Time.deltaTime;
		if (progress < delay) {
			this.curspeed=Random.Range(0f,3f);
			this.delay=Random.Range (1f,2f);
			Vector2 pos=Random.insideUnitCircle*node.transform.localScale.x;
			this.destination= new Vector3(pos.x,0,pos.y)+node.transform.position;
		}
		this.Move (this.destination);
	}
	void Move(Vector3 destination){
		this.transform.position -= (this.transform.position - destination).normalized * curspeed * Time.deltaTime;
	}

	public override void Clicked ()
	{
		List<Trait> buffer = Agent.traits.ToList ();
		for (int i =0; i<buffer.Count; i++)
			print (buffer [i].name);
		this.node = GameSystem.instance.quarantine;
		this.quarantined = true;
	}

}
