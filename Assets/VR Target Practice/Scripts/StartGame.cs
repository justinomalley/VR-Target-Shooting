using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    //public GameObject startMessage;
    GameManager mgr;

    // Use this for initialization
    void Start() {
        mgr = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !GameManager.Playing()) {
            Debug.Log("starting game");
            mgr.Begin();
            //startMessage.SetActive(false);
            enabled = false;
        }
    }

    private void OnEnable() {
        //startMessage.SetActive(true);
    }

}
