using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetChanger : MonoBehaviour {
	// Use this for initialization
	Zone zone;
	List<Zone> zones;
	float progress;
	GameObject randomTarget;
	public float zoneShiftProbability;
	public Agent controller;
	void Start () {
		zones = new List<Zone>(GameObject.FindObjectsOfType<Zone> ());
		zone = zones [Random.Range (0, zones.Count)];
		controller.target=zone.transform;
		randomTarget=new GameObject("Target");
	}
	
	// Update is called once per frame
	void Update () {
		progress += Time.deltaTime;
		if(progress>1){
			progress=0;
			if((this.transform.position-zone.transform.position).sqrMagnitude < Mathf.Pow(zone.transform.localScale.x,2)){
				if(Random.value < zoneShiftProbability){
					zone = zones [Random.Range (0, zones.Count)];
					controller.target = zone.transform;
					controller.curspeed = controller.speed;
				}else{
					Vector2 pos=Random.insideUnitCircle*zone.transform.localScale.x;
					randomTarget.transform.position= new Vector3(pos.x,0,pos.y)+zone.transform.position;
					controller.target = randomTarget.transform;
					controller.curspeed=Random.Range(0f,3f);
				}
			}
		}
	}
}
