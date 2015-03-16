using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Infection {
	public Symptom symptom;
	public Trait susceptibility;
	public Trait protection;
	public float transmitRange=10f;
	public float transmitProbability=0.01f;
	public float revertDelay=0.01f;
	public float passOutDelay=60f;
	public List<Agent> infected;
	
	// Use this for initialization
	public Infection () { 
		this.symptom = Symptom.symptoms.Shuffle().ToList()[0];
		List<Trait> traits = Trait.traits.Shuffle ().Take (2).ToList ();
		this.susceptibility= traits[0];
		this.protection=traits[1];
	}
	public void MakeInfectious(){
		this.transmitRange = 5f;
		this.transmitProbability = 0.01f;
		this.passOutDelay = 60f;
		this.revertDelay = 61f;
	}
	public void MakeSporadic(){
		this.transmitProbability = 0f;
		this.passOutDelay = 61f;
		this.revertDelay = 60f;
	}
//	public Infection(Symptom sympton,Trait susceptibility,Trait protection) {
//		this.symptom = symptom;
//		this.susceptibility = susceptibility;
//		this.protection = protection;
//	}
//
	// Update is called once per frame
	void Update () {
	
	}
}
