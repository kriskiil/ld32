using UnityEngine;
//using System.Collections.Generic;
using System.Linq;

public class Trait {
	public static Trait[] traits = {new Trait("Loves raw oysers"), new Trait("Actively licks door knobs")};
//		new Trait(""),
//		new Trait(""),
//		new Trait(""),
//		new Trait(""),
//		new Trait(""),
//		new Trait(""),
//		new Trait(""),
//		new Trait(""),
//		new Trait("")};
	public string name;
	// Use this for initialization
	Trait (string name) {
		this.name = name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
