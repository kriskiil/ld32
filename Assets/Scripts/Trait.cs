using UnityEngine;
//using System.Collections.Generic;
using System.Linq;

public class Trait {
	public static Trait[] traits = {new Trait("Loves raw oysers"), new Trait("Actively licks door knobs"),
		new Trait("Stress"),
		new Trait("Kulde"),
		new Trait("Spiser fisk"),
		new Trait("Insomnia"),
		new Trait("Direkte sol"),
		new Trait("Dyrker motion"),
		new Trait("Drikker kakao"),
		new Trait("Holder sig varm"),
		new Trait("Frequent hand wash"),
		new Trait("Wears glasses"),
		new Trait("Flies Business Class")};
	public string name;
	// Use this for initialization
	Trait (string name) {
		this.name = name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
