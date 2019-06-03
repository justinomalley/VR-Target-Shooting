using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

    public int type; //0 for front, 1 for middle, 2 for back
    bool spawn = true;

    public float secBetweenSpawns;
    public GameObject target;
    public GameManager mgr;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (spawn)
            StartCoroutine(SpawnTarget());
	}

    public IEnumerator SpawnTarget()
    {
        spawn = false;
        Target targ = Instantiate(target, transform.position, target.transform.rotation).GetComponent<Target>();
        targ.type = type;
        targ.mgr = mgr;
        yield return new WaitForSeconds(secBetweenSpawns);
        spawn = true;
        
    }
}
