// Day and Night Change Utility
// You can use this script to switch between sunlight and lighting
// How to use
// 1. Check "DayAndNightChange" and press the execute button
// 2. You can change daytime and nighttime from the "Brightness" menu

// 昼間と夜間変更ユーティリティ
// このスクリプトを使用して、太陽光と照明を切り替えることができます
// 使い方
// 1.「DayAndNightChange」をチェックして、実行ボタンを押してください
// 2.「Brightness」メニューから昼間と夜間を変更できます

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyTown {

	public class DayAndNightChange : MonoBehaviour {

		GameObject mainCamera;
		private Vector3 cameraMyTownPos = new Vector3 (5.0f, 10.0f, -15.0f); // MyTown
		private Vector3 cameraMyTownAng = new Vector3 (25.0f, 0.0f, 0.0f); // MyTown
		private Vector3 cameraSamplePos = new Vector3 (231.0f, 20.0f, 106.0f); // Sample
		private Vector3 cameraSampleAng = new Vector3 (10.0f, -50.0f, 0.0f); // Sample
		private float directionalLightBright = 1.0f;
		private float roomLightBright = 0.0f;
		private float doorLightBright = 0.0f;
		private float roadLightBright = 0.0f;

		// Use this for initialization
		void Start () {
			mainCamera = GameObject.Find ("Main Camera");
			if (SceneManager.GetActiveScene ().name.Equals ("MyTown")) {
				mainCamera.transform.position = cameraMyTownPos;
				mainCamera.transform.rotation = Quaternion.Euler (cameraMyTownAng);
			} else {
				mainCamera.transform.position = cameraSamplePos;
				mainCamera.transform.rotation = Quaternion.Euler (cameraSampleAng);
			}
			DayMode (true);
		}

		void OnGUI () {
			GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
			buttonStyle.fontSize = 30;
			buttonStyle.alignment = TextAnchor.UpperCenter;
			GUI.Box (new Rect (30, 20, 240, 170), "Brightness", buttonStyle);
			buttonStyle.alignment = TextAnchor.MiddleCenter; // Upper or Lower + Left Center Right
			if (GUI.Button (new Rect (50, 80, 200, 40), "Daytime", buttonStyle)) {
				DayMode (true);
			}
			if (GUI.Button (new Rect (50, 130, 200, 40), "Night", buttonStyle)) {
				DayMode (false);
			}
		}

		// Update is called once per frame
		void Update () {

		}

		void DayMode (bool mode) {
			if (mode == true) {
				directionalLightBright = 1.0f;
				roomLightBright = 0.0f;
				doorLightBright = 0.0f;
				roadLightBright = 0.0f;
			} else {
				directionalLightBright = 0.0f;
				roomLightBright = 0.7f;
				doorLightBright = 0.7f;
				roadLightBright = 0.7f;
			}

			// Directional light Change
			GameObject directionalLight = GameObject.Find ("Directional light");
			Color lightColor = directionalLight.GetComponent<Light>().color;
			lightColor.r = directionalLightBright;
			lightColor.g = directionalLightBright;
			lightColor.b = directionalLightBright;
			directionalLight.GetComponent<Light>().color = lightColor;

			// Window Change
			GameObject[] windowList = GameObject.FindGameObjectsWithTag ("HouseWindow");
			foreach (GameObject window in windowList) {
				//Debug.Log ("HouseWindow");
				MeshRenderer meshRenderer = window.GetComponent<MeshRenderer>();
				meshRenderer.material.EnableKeyword ("_EMISSION");
				meshRenderer.material.SetColor ("_EmissionColor", new Color (roomLightBright, roomLightBright, roomLightBright));
				meshRenderer.UpdateGIMaterials ();
			}

			// Lamp Change
			GameObject[] DoorList = GameObject.FindGameObjectsWithTag ("DoorLamp");
			foreach (GameObject door in DoorList) {
				//Debug.Log ("HouseWindow");
				MeshRenderer meshRenderer = door.GetComponent<MeshRenderer>();
				meshRenderer.material.EnableKeyword ("_EMISSION");
				meshRenderer.material.SetColor ("_EmissionColor", new Color (doorLightBright, doorLightBright, doorLightBright));
				meshRenderer.UpdateGIMaterials ();
			}

			// Street Lamp Change
			GameObject[] lampList = GameObject.FindGameObjectsWithTag ("LampLens");
			foreach (GameObject lamp in lampList) {
				//Debug.Log ("LampLens");
				MeshRenderer meshRenderer = lamp.GetComponent<MeshRenderer>();
				meshRenderer.material.EnableKeyword ("_EMISSION");
				meshRenderer.material.SetColor ("_EmissionColor", new Color (roadLightBright, roadLightBright, roadLightBright));
				meshRenderer.UpdateGIMaterials ();
			}
			GameObject[] lensList = GameObject.FindGameObjectsWithTag ("StreetLamp");
			foreach (GameObject lens in lensList) {
				//Debug.Log ("StreetLamp");
				Color lensColor = lens.GetComponent<Light>().color;
				lensColor.r = roadLightBright;
				lensColor.g = roadLightBright;
				lensColor.b = roadLightBright;
				lens.GetComponent<Light>().color = lensColor;
			}
		}
	}
}
