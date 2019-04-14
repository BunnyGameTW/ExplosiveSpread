using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//
public class PathFind : MonoBehaviour {
    float reachDistance = 0.1f;
    int targetIndex = 0;
    float timer, delayTime = 0;
    bool startTimer = false;
    public Transform[] targets;
    NavMeshAgent agent;
    float lastRemainDistance = 0;
    Animator animator;
    // Use this for initialization
    void Start () {
        delayTime = Random.Range(0, 3);
        agent = GetComponent<NavMeshAgent>();
        startTimer = true;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        delayTimer();
        if (agent.remainingDistance <= reachDistance || Mathf.Abs(agent.remainingDistance - lastRemainDistance) < 0.001f) {
            startTimer = true;
            animator.SetBool("isWalk", false);
         //   animator.SetTrigger("reachTarget");
        }
        lastRemainDistance = agent.remainingDistance;
    }
    void delayTimer()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                timer = 0;
                startTimer = false;
                delayTime = Random.Range(0, 3);
                findTarget();
            }
        }
    }
    // 到達之後就往某個地方轉向 放個特效?
    void findTarget()
    {
        animator.SetBool("isWalk", true);
        targetIndex = (Random.Range(0, targets.Length) == targetIndex) ? targetIndex + 1 : Random.Range(0, targets.Length);
        targetIndex = targetIndex >= targets.Length ? targetIndex - 2: targetIndex;
        agent.destination = targets[targetIndex].position;

    }
}
