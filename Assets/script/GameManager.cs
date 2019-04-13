using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public PlayerSkill playerSkill;
	// Use this for initialization
	void Start () {
        this.playerSkill.skillButtonClicked += this.OnPlayerSkillButtonClicked;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPlayerSkillButtonClicked(object sender, SkillButtonEventArgs args)
    {
        Debug.Log(args.skillName + " is :" + args.skillPoint);
    }
}
