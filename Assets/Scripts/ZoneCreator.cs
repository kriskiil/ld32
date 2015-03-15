using UnityEngine;
using System.Collections;

public class ZoneCreator : MonoBehaviour {
	public GameObject prefabZone;
	public float worldRadius;
	public int zoneCount;

	// Use this for initialization
	void Start () {
		for(int i=0;i<zoneCount;i++){
			Vector2 position = Random.insideUnitCircle*worldRadius;
			Instantiate (prefabZone,new Vector3(position.x,0,position.y),Quaternion.identity);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
