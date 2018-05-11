using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

public class SocketConnect : MonoBehaviour {
	string serverUrl = "http://49.236.133.174:3332";
	Socket socket;

	// Use this for initialization
	void Start() {
//		var socket = Socket.Connect(serverUrl);
//		socket = Socket.Connect(serverUrl);
//		socket.On(SystemEvents.connect, () => {
//			Debug.Log("Socket connected");
//
//		});
//
//
//		socket.On(SystemEvents.reconnect, (int reconnectAttempt) => {
//			Debug.Log("Hello, Again! " + reconnectAttempt);
//		});
//
//		socket.On(SystemEvents.disconnect, () => {
//			Debug.Log("Bye~");
//		});

		reconnectAttempNum = 0;
	}

	void Update() {
//		if (Input.GetKeyDown (KeyCode.Z)) {
//			asd ();
//		}
//		if (Input.GetKeyDown (KeyCode.X)) {
//			asd2 ();
//		}
//
//		if (Input.GetKeyDown (KeyCode.C)) {
//			asd3 ();
//		}
//		if (Input.GetKeyDown (KeyCode.V)) {
//			asd4 ();
//		}
//		if (Input.GetKeyDown (KeyCode.B)) {
//			asd5 ();
//		}
	}

	void asd() {
		Debug.Log ("click Z");
		socket = Socket.Connect(serverUrl);

		socket.On(SystemEvents.connect, () => {
			Debug.Log("Socket connected");

		});
//		SocketManager.Instance.

	}

	void asd2 () {
		Debug.Log ("click X");
		socket.Emit("event", "LLLKKK");

	}

	int reconnectAttempNum;
	void asd3() {
		Debug.Log ("click S");
		reconnectAttempNum++;
		SocketManager.Instance.Reconnect(socket,reconnectAttempNum);
	}

	void asd4() {
		Debug.Log ("click V");
		SocketManager.Instance.OnDestroy ();
	}

	void asd5() {
		Debug.Log ("click B");

	}
}
