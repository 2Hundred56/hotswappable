using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;
public class Swapper : MonoBehaviour {
	float SwapRange = 1000;
	public GameObject glow;
	// Use this for initialization
	void Start () {
		glow = GameObject.Find ("Glow");

	}

	void Swap(GameObject closest) {
		Camera.main.transform.parent = closest.transform;
		Camera.main.transform.localRotation = closest.GetComponent<HotSwappable>().getIdealCameraRot();
		Camera.main.transform.localPosition = new Vector3(1.1f, 11.5f, -8.2f);
		closest.AddComponent<FreeLookCam> ();
		closest.transform.rotation = new Quaternion();
		closest.AddComponent<Swapper> ();
		closest.GetComponent<HotSwappable> ().Controlled = true;
		Destroy (GetComponent<FreeLookCam> ());
		Destroy (GetComponent<Swapper> ());
		GetComponent<HotSwappable> ().Controlled = false;
		print (GetComponent<HotSwappable> ().Controlled);
		if (GetComponent<HotSwappable> ().Controlled) {
			Debug.LogError ("Bad swap!");
		}
		glow.transform.parent = closest.transform;
		glow.transform.localPosition = new Vector3 (0, 0, 0);
		closest.GetComponent<Swapper> ().glow = glow;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			
			object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
			GameObject closest = null;
			foreach (object o in obj)
			{
				GameObject g = (GameObject) o;

				if (closest == null) {
					if (g.GetComponent<HotSwappable> () != null && g != this.gameObject) {
						closest = g;
					}
					continue;
				}
				if ((Vector3.Distance (transform.position, g.transform.position) < Vector3.Distance (transform.position, closest.transform.position) && g != this.gameObject)) {
					
					if (g.GetComponent<HotSwappable> () != null) {
						closest = g;
					}
				}
			}

			Swap (closest);



		}
		if (Input.GetMouseButtonDown (0)) {
			Plane p = new Plane (Camera.main.transform.forward , transform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				GameObject hitobject = hit.collider.gameObject;
				if (Vector3.Distance (transform.position, hitobject.transform.position) < SwapRange && hitobject.GetComponent<HotSwappable> () != null) {
					Swap (hitobject);
				}

			}
		}
		float d = Input.GetAxis ("Mouse ScrollWheel");
		if (d > 0) {
			Camera.main.transform.localPosition *= 0.94f;
		} 
		if (d < 0)
		{
			Camera.main.transform.localPosition *= 1.04f;
		}
	}
}
