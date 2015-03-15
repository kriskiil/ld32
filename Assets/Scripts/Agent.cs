using UnityEngine;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Agent : Targetable {
	[HideInInspector]
	public Transform target;
	public float speed;
	[HideInInspector]
	public float curspeed;
	public bool sick;
	static IEnumerable<Trait> traits;
	static IEnumerable<Symptom> symptoms;
	// Use this for initialization
	void Start () {
		this.curspeed = this.speed;
		Agent.traits = Trait.traits.Shuffle().Take(3);
		Agent.symptoms = Symptom.symptoms.Shuffle ().Take (3);

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (CameraController.instance.transform);
		if (target) {
			this.transform.position -= (this.transform.position - target.position).normalized * curspeed * Time.deltaTime;
		}
	}

	public override void Clicked ()
	{
		List<Trait> buffer = Agent.traits.ToList ();
		for (int i =0; i<buffer.Count; i++)
			print (buffer [i].name);
	}

}
