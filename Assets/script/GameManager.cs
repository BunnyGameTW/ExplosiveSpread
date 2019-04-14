using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //public PlayerSkill playerSkill;
    public GameObject prefab;
    public Transform[] targets;
    public int person;
	// Use this for initialization
	void Start () {
      //  this.playerSkill.skillButtonClicked += this.OnPlayerSkillButtonClicked;
      for(int i = 1; i < person; i++)
        {
            Instantiate(prefab, targets[Random.Range(0, targets.Length)].position, new Quaternion());
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPlayerSkillButtonClicked(object sender, SkillButtonEventArgs args)
    {
        Debug.Log(args.skillName + " is :" + args.skillPoint);
    }
}
