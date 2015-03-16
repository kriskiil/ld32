using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float speed;
	public float minHeight;
	private static CameraController _instance;
	public static CameraController instance{
		get{
			if(!CameraController._instance){
				CameraController._instance = GameObject.FindObjectOfType<CameraController>();
			}
			return CameraController._instance;
		}
	}
	private static Transform target;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		this.offset = this.transform.position;
		CameraController.target = GameObject.FindObjectOfType<StartLocation> ().transform;
	}

	// Update is called once per frame
	void Update () {
		if (CameraController.target) {
			this.Zoom (Input.GetAxis("Mouse ScrollWheel"));
			this.transform.position=Vector3.Lerp (this.transform.position,CameraController.target.position+this.offset,Time.deltaTime*this.speed);
			Vector3 localRotation = this.transform.localRotation.eulerAngles;
			Vector3 lookdirection = this.transform.position-CameraController.target.position;
			float xRotation = Mathf.Asin (lookdirection.normalized.y)*Mathf.Rad2Deg;
			localRotation.x=xRotation;
			this.transform.localRotation= Quaternion.Lerp (this.transform.localRotation,Quaternion.Euler(localRotation),Time.deltaTime*this.speed);
		}
	}

	public void Zoom(float up){
		// Changes z axis and keeps target in centre of view

		this.offset += Vector3.up * -up* (this.transform.position-CameraController.target.position).magnitude;
		if (this.offset.y < this.minHeight) {
			this.offset.y = this.minHeight;
		}

	}

	public static void Follow(Transform target) {
		// Starts following an object
		CameraController.target = target;
	}
}
