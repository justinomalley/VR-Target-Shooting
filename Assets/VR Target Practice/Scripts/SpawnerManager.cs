using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    public float secsBetweenSpawns;
    TargetSpawner[] spawners;

	// Use this for initialization
	void Start () {
        spawners = GetComponentsInChildren<TargetSpawner>();
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].secBetweenSpawns = secsBetweenSpawns;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
