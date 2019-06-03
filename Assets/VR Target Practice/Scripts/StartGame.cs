using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject startMessage;

    GameManager mgr;

    // Use this for initialization
    void Start () {
        mgr = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        OVRInput.Controller controller = OVRInput.GetConnectedControllers();

		if(OVRInput.GetDown(OVRInput.Button.One) && !mgr.isCountingDown)
        {
            mgr.Begin();
            startMessage.SetActive(false);
            enabled = false;
        }
	}

    private void OnEnable()
    {
        startMessage.SetActive(true);
    }

}
