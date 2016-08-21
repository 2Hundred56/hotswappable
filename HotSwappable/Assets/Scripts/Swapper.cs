using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;
public class Swapper : MonoBehaviour {
	float SwapRange = 1000;
	public GameObject glow;
	// Use this for initialization
	void Start () {
		transform.rotation = new Quaternion();
		GetComponent<HotSwappable> ().StartControl ();
		glow = GameObject.Find ("Glow");
		glow.transform.parent = transform;
		glow.transform.localPosition = new Vector3 (0, 1, 0);
		Debug.Log ("Swapped in to " + this.name);

	}

	void Swap(GameObject closest) {
		Camera.main.transform.parent = closest.transform;
		Camera.main.transform.localRotation = Quaternion.Euler (new Vector3 (35.2904f, 0, 0));
		Camera.main.transform.localPosition = new Vector3(0, 11.5f, -8.2f)/(closest.GetComponent<Collider> ().bounds.size.magnitude*0.5f);
		closest.AddComponent<Swapper> ();
		Camera.main.GetComponent<CamCtrl> ().target = closest;
		Destroy (GetComponent<Swapper> ());
		Camera.main.GetComponent<CamCtrl> ().target = closest;
		//Camera.main.transform.localPosition *= closest.GetComponent<Collider> ().bounds.size.magnitude;
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
			Plane p = new Plane (Camera.main.transform.forward, transform.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
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
			Camera.main.transform.localPosition *= 0.95f;
		} 
		if (d < 0)
		{
			Camera.main.transform.localPosition *= 1.05f;
		}

	}
	void OnDestroy() {
		Debug.Log ("Swapped out from " + this.name);
		GetComponent<HotSwappable> ().EndControl ();
	}
}
