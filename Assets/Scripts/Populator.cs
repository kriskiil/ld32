using UnityEngine;
using System.Collections;

public class Populator : MonoBehaviour {
	public GameObject prefab;
	public int meepulation;
	// Use this for initialization
	void Start () {
		for(int i =0;i<meepulation;i++){
			Instantiate (prefab) ;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
