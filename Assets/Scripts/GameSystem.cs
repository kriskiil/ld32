using UnityEngine;
using System.Collections.Generic;

public class GameSystem : MonoBehaviour {
	private static GameSystem _instance;
	public static GameSystem instance{
		get{
			if(! GameSystem._instance){
				GameSystem._instance = GameObject.FindObjectOfType<GameSystem>();
			}
			return GameSystem._instance;
		}
	}
	public GameObject prefabZone;
	public int worldRadius;
	public int nodeCount;
	public GameObject prefabAgent;
	public int population;
	public bool randomInfection;
	public Infection infection;
	public GameObject prefabQuarantine;
	public List<Zone> zones;
	public Zone quarantine;
	// Use this for initialization
	void Start () {
		Vector2 position;
		for(int i=0;i<nodeCount;i++){
			position = Random.insideUnitCircle*worldRadius;
			Instantiate (prefabZone,new Vector3(position.x,0,position.y),Quaternion.identity);
		}
		zones = new List<Zone>(GameObject.FindObjectsOfType<Zone> ());
		position = Random.insideUnitCircle*worldRadius;
		this.quarantine = (Instantiate (prefabQuarantine, new Vector3 (position.x, 0, position.y), Quaternion.identity) as GameObject).GetComponent<Zone>();
		for(int i =0;i<population;i++){
			Instantiate (prefabAgent) ;
		}
		if (randomInfection) {
			this.infection = new Infection ();
			this.infection.MakeInfectious();
			this.infection.infected=new List<Agent>();
			GameObject.FindObjectOfType<Agent>().Infect(this.infection);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
