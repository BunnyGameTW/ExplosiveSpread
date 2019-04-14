using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextMove : MonoBehaviour {
    public Color[] colors;
    int randomAnimationIndex = 0;
    public AnimationClip[] clips;
    public float speed;
    Animation ani;
    Text text;
    RectTransform rectTrans;
    // Use this for initialization
    void Start () {
        GetComponent<Text>().color = colors[Random.Range(0, colors.Length)];
        rectTrans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update () {
        rectTrans.anchoredPosition += new Vector2(-speed * Time.deltaTime, 0);
        if (rectTrans.anchoredPosition.x < -1920) Destroy (transform.parent.gameObject);
    }
    public void setAnimationType(int i)
    {
        randomAnimationIndex = i;
        ani = GetComponent<Animation>();
        ani.clip = clips[randomAnimationIndex];
    }
}
