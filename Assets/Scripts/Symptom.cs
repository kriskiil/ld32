using UnityEngine;
//using System.Collections.Generic;
using System.Linq;

public class Symptom {
	public static Symptom[] symptoms = {new Symptom("Coughing"),
		new Symptom("Diarhea"),
		new Symptom("Nausea"),
		new Symptom("Rash"),
		new Symptom("Amnesia"),
		new Symptom("Insomnia"),
		new Symptom("Brain eating"),
		new Symptom("Depression")};
	public string name;
	// Use this for initialization
	Symptom (string name) {
		this.name = name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
