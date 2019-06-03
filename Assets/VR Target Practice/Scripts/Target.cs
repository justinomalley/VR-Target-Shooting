using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int type; //0 is bottom row, 1 is middle, 2 is top; set by TargetSpawner
    public float speed;
    public GameManager mgr;

	// Use this for initialization
	void Start()
    {
        StartCoroutine(WaitAndDestroy());
	}
	
	// Update is called once per frame
	void Update () {
        if(type == 0 || type == 2)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        else
            transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(speed * 5);
        Destroy(this.gameObject);
    }

    public void TargetHit()
    {
        mgr.TargetHit();
        Destroy(this.gameObject);
    }

}
