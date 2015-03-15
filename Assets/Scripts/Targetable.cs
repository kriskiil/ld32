using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]

public class Targetable : MonoBehaviour,IPointerClickHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		print (this.name);
		CameraController.Follow (this.transform);
		this.Clicked();
	}
	public virtual void Clicked(){

	}

}
