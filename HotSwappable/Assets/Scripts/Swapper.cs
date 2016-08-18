using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;
public class Swapper : MonoBehaviour {
	float SwapRange = 1000;
	public GameObject glow;
	// Use this for initialization
	void Start () {

	}

	void Swap(GameObject closest) {
		Camera.main.transform.parent = closest.transform;
		Camera.main.transform.localRotation = Quaternion.Euler (new Vector3 (35.2904f, 0, 0));
		Camera.main.transform.localPosition = new Vector3 (0, 9.8f, -(closest.GetComponent<Collider> ().bounds.size.magnitude + 8.63f)) / 2f;
		closest.AddComponent<FreeLookCam> ();
		closest.AddComponent<Swapper> ();
		closest.AddComponent<Swappable_Controller> ();
		closest.GetComponent<HotSwappable> ().Controlled = true;
		Destroy (GetComponent<FreeLookCam> ());
		Destroy (GetComponent<Swapper> ());
		Destroy (GetComponent<Swappable_Controller> ());
		GetComponent<HotSwappable> ().Controlled = false;
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
						print (g.name);
					}
					continue;
				}
				if ((Vector3.Distance (transform.position, g.transform.position) < Vector3.Distance (transform.position, closest.transform.position) && g != this.gameObject)) {
					
					if (g.GetComponent<HotSwappable> () != null) {
						print (g.name);
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
	
	}
}
