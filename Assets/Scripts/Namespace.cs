using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

public class Namespace : MonoBehaviour {

	string serverUrl = "http://49.236.133.174:3332";
	Socket news;


	void Start() {

	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Z)) {
			asd ();
		}
	}

	void asd() {
		Debug.Log ("click Z");

		news = Socket.Connect(serverUrl + "/socket");

		news.On(SystemEvents.connect, () => {
			// send "ferret" event
			news.Emit(
				"conn", "isConnect OK?", 
				(string ackData) => { 

					if (ackData.Contains ("true")) {
						Debug.Log("socket connected!");
						//functionA ();
					}
				}
			);
		});

		news.On("enroll", (string data) => {
			Debug.Log(data); 
			if (data.Equals("true")) {
				Debug.Log("sign2 data is true");
				// TODO

			} else if (data.Equals("false")){
				Debug.Log("sign2 data is false");
				//TODO
			}

		});

		news.On ("scenarioChange", (string msg) => {
			Debug.Log("scenario change is called : " + msg);
			if(msg.Equals("true")) {
				Debug.Log("scenario change is true");
			}
		});

		news.On ("scenarioStart", (string testName) => {
			// TODO test name save
			Debug.Log("test name : " + testName);
		});

	}


}