using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using System;


[Serializable] class Data { 
	public string name; 
	public string nick; 
	public int age; 
}


public class Event : MonoBehaviour {

	// Use this for initialization
	void Start() {
		var serverUrl = "http://localhost:7001";
		var socket = Socket.Connect(serverUrl);

		// receive "news" event
		socket.On("news", (string data) => {
			Debug.Log(data);

			// Emit raw string data
			socket.Emit("my other event", "{ my: data }");

			// Emit json-formatted string data
			socket.EmitJson("my other event", @"{ ""my"": ""data"" }");
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
