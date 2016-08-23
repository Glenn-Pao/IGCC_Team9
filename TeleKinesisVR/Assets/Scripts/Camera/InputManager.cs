using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour {
	
	public float maxAttractSpeed = 300.0f;
	public float pushSpeedFactor = 100.0f;
	public float attractSpeedFactor = 0.1f;
	public float distanceToPush = 6.0f;
	
	private float attractSpeed = 0.0f;
	
	private GameObject current = null;
    private OVRCameraRig CameraRig;

    public Text debug;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {       

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, 10000))
        {
            hit.collider.gameObject.GetComponent<PositiveScript>().Targeted();
        }
	}
}
