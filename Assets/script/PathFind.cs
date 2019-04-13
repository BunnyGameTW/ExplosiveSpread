using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//
public class PathFind : MonoBehaviour {
    float reachDistance = 10;
    public Transform[] targets;
    NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        findTarget();
    }
	
	// Update is called once per frame
	void Update () {
        if (agent.remainingDistance <= reachDistance) {
            findTarget();
        }

    }

    // 到達之後就往某個地方轉向 放個特效?
    void findTarget()
    {
        agent.destination = targets[Random.Range(0, targets.Length)].position;

    }
}
