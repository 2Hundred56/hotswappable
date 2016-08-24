using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;
public class Swapper : MonoBehaviour {
	float SwapRange = 1000;
	public GameObject glow;
	// Use this for initialization
	void Start () {
		Camera.main.GetComponent<CamCtrl> ().ChangeTarget (gameObject);
		GetComponent<HotSwappable> ().StartControl ();
		glow = GameObject.Find ("Glow");
		glow.transform.parent = transform;
		glow.transform.localPosition = new Vector3 (0, 1, 0);

		Debug.Log ("Swapped in to " + this.name);

	}

	void Swap(GameObject closest) {
		closest.AddComponent<Swapper> ();
		Destroy (GetComponent<Swapper> ());

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			
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
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, transform.rotation.eulerAngles.y, 0));
		}

		float d = Input.GetAxis ("Mouse ScrollWheel");
		if (d > 0) {
			Camera.main.GetComponent<CamCtrl>().Zoom(0.9f);
		} 
		if (d < 0)
		{
			Camera.main.GetComponent<CamCtrl>().Zoom(1.1f);
		}
		if (Input.GetKey (KeyCode.A)) {
			GetComponent<HotSwappable> ().Rotate (-1);
		}
		if (Input.GetKey (KeyCode.D)) {
			GetComponent<HotSwappable> ().Rotate (1);
		}
		if (Input.GetKey (KeyCode.W)) {
			
			transform.position += (GetComponent<HotSwappable>().moveAxis * transform.forward) * GetComponent<HotSwappable>().speed / 30f;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= (GetComponent<HotSwappable>().moveAxis * transform.forward) * GetComponent<HotSwappable>().speed / 30f;
		}
		if (Input.GetKey (KeyCode.Space)) {
			GetComponent<HotSwappable> ().Launch ();
		}

	}
	void OnDestroy() {
		Debug.Log ("Swapped out from " + this.name);
		GetComponent<HotSwappable> ().EndControl ();
	}

}
