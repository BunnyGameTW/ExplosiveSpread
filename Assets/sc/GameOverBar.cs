using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverBar : MonoBehaviour {

    public Image progressBar;
    public Vector2 barPosRangePosX;

    public static GameOverBar instance;

    Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();

        gameObject.SetActive(false);

        instance = this;
    }

    public void ShowGameOverBar()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float posX = Mathf.Lerp(barPosRangePosX.x, barPosRangePosX.y, OctoGameLoop.instance.resisitanceManager.GetCurrentResisitancePoint() / 100);
        progressBar.transform.localPosition= new Vector3(posX, progressBar.transform.localPosition.y, progressBar.transform.localPosition.z);
    }
}
