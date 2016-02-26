using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	static public FollowCam S; //a FollowCam Singleton
	public Vector2 minXY;
	//fields set in the Unity Inspector pane
	public float easing = 0.05f;
	public bool ___________________;
	//fields set dynamically
	public GameObject poi; //the point of interest
	public float camZ; //The desired Z pos of the camera

	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if there's only one line following an if, it doesn't need braces
		if (poi == null) return; //return if there is no poi
		//Get position of poi
		Vector3 destination = poi.transform.position;
		//Limit the X & Y to minimum values
		destination.x = Mathf.Max(minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);
		//Interpolate from the current Camera position toward destination
		destination = Vector3.Lerp(transform.position, destination, easing);
		//Retain a destination.z of camZ
		destination.z = camZ;
		//Set camera to destination
		transform.position = destination;
		//Set the orthographicSize of the Camera to keep Ground in view
		this.GetComponent<Camera>().orthographicSize = destination.y + 10;
	}
}
