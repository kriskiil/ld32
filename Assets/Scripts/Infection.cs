using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Infection {
	public Symptom symptom;
	public Trait susceptibility;
	public Trait protection;
	public float transmitRange;
	public float transmitProbability;
	public List<Agent> infected;
	
	// Use this for initialization
	public Infection () { 
		this.symptom = Symptom.symptoms.Shuffle().ToList()[0];
		List<Trait> traits = Trait.traits.Shuffle ().Take (2).ToList ();
		this.susceptibility= traits[0];
		this.protection=traits[1];
	}
	public Infection(Symptom sympton,Trait susceptibility,Trait protection) {
		this.symptom = symptom;
		this.susceptibility = susceptibility;
		this.protection = protection;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
