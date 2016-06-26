using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

    public GameObject player;
    public GameObject playerUI;
	
	void Start ()
    {
        playerUI = GameObject.Find("playerUI");
        playerUI.SetActive(false);
	}
	
	
	void Update ()
    {
        if (GameObject.Find("Player(Clone)"))
        {
            player = GameObject.Find("Player(Clone)");
            gameObject.transform.position = GameObject.Find("CameraPos").transform.position;
            gameObject.transform.SetParent(player.transform);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
            gameObject.GetComponent<MouseLook>().enabled = true;
            gameObject.GetComponent<MouseLook>().characterBody = player;
        }
	}
}
