using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
	private bool boolPortalFinal;
	public GameObject prefabPortal;
	public GameObject prefabIconFinal;

	void Update(){

		if(waitTime <= 0 && boolPortalFinal == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					Instantiate(prefabPortal, rooms[i].transform.position, Quaternion.identity);
					Instantiate(prefabIconFinal, rooms[i].transform.position, Quaternion.identity);
					boolPortalFinal = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
