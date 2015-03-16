using UnityEngine;
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
	IEnumerable<Trait> traits;
	List<Symptom> symptoms;
	public Zone node;
	// Use this for initialization
	void Start () {
		//Initialize movement
		this.curspeed = this.speed;
		this.delay = 1f;

		//Initialize infection related
		this.traits = Trait.traits.Shuffle().Take(3);
		this.symptoms = Symptom.symptoms.Shuffle ().Take (3).ToList();

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
		bool areWeThereYet = (this.transform.position - this.node.transform.position).sqrMagnitude 
			< Mathf.Pow (this.node.radius, 2);
		if (!quarantined && areWeThereYet && Random.value < zoneShiftProbability*Time.deltaTime) {
			this.ChangeNode ();
		}
		if (areWeThereYet) {
			this.Loiter ();
		} else {
			this.curspeed = this.speed;
			this.Move (node.transform.position);
		}
		// Check if we get infected
		Infection infection = GameSystem.instance.infection;
		if (!this.sick && 
		    this.traits.Contains<Trait>(infection.susceptibility) && 
		    ! this.traits.Contains<Trait>(infection.protection)) 
		{
			List<Agent> infected = GameSystem.instance.infection.infected;
			for(int i =0;i<infected.Count;i++){
				if((this.transform.position - infection.infected[i].transform.position).sqrMagnitude 
				   < Mathf.Pow(infection.transmitRange,2f)
				   && Random.Range(0f,1f)<infection.transmitProbability*Time.deltaTime){
					this.Infect(infection);
					break;
				}
			}
		//	this.BroadcastMessage("Infect",this.transform);
		}
	}
	void ChangeNode(){
		this.node=GameSystem.instance.zones.Shuffle().ToList()[0];
	}
	void Loiter(){
		this.progress += Time.deltaTime;
		if (progress > delay) {
			this.curspeed=Random.Range(2f,4f);
			this.delay=Random.Range (1f,4f);
			Vector2 pos=Random.insideUnitCircle*node.radius;
			this.destination= new Vector3(pos.x,0,pos.y)+this.node.transform.position;
			progress=0;
		}
		this.Move (this.destination);
	}
	void Move(Vector3 destination){
		this.transform.position -= (this.transform.position - destination).normalized * curspeed * Time.deltaTime;
	}

	public void quarantine(){
		this.node = GameSystem.instance.quarantine;
		this.quarantined = true;
	}
	public override void Clicked ()
	{
		List<Trait> buffer = traits.ToList ();
		for (int i =0; i<buffer.Count; i++)
			print (buffer [i].name);
	}
	public void Infect(Infection infection){
		this.symptoms.Add(infection.symptom);
		infection.infected.Add (this);
		this.sick=true;
	}
}
