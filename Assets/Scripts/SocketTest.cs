using UnityEngine;
using socket.io;


public class SocketTest : MonoBehaviour {
	string serverUrl = "http://49.236.133.174:3332";
	Socket socket;

	void Start() {
		reconnectAttempNum = 0;
		 
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Z)) {
			asd ();
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			asd2 ();
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			asd3 ();
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			asd4 ();
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			asd5 ();
		}
	}

	void asd() {
		socket = Socket.Connect(serverUrl);

		socket.On(SystemEvents.connect, () => {
			// send "ferret" event
			socket.Emit(
				"event", "LLLKKKAAA", 
				(string ackData) => { 

					Debug.Log(ackData); 
					if (ackData.Contains ("connected")) {
						//			functionA ();
					}
				}
			);

		});
	}

	void asd2 () {
		Debug.Log ("click X");
//		socket.Emit("event", "LLLKKK");

	}

	int reconnectAttempNum;
	void asd3() {
		Debug.Log ("click S");
		socket.On("a message", (string data) => {
			Debug.Log("news => " + data);
		});
	}

	void asd4() {
		Debug.Log ("click V");

	}

	void asd5() {
		Debug.Log ("click B");
		reconnectAttempNum++;
		SocketManager.Instance.Reconnect(socket,reconnectAttempNum);
	}
}