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
        if (randomAnimationIndex == 0)
        {
            rectTrans.anchoredPosition += new Vector2(-speed * Time.unscaledDeltaTime, 0);
        }
        else
        {
            rectTrans.anchoredPosition += new Vector2(-speed * Time.deltaTime, 0);
        }
        if (rectTrans.anchoredPosition.x < -19999) Destroy (transform.parent.gameObject);
    }
    public void setAnimationType(int i)
    {
        randomAnimationIndex = i;
        speed = i == 0 ? speed / 2 : speed;
        //ani = GetComponent<Animation>();

        //ani.clip = clips[randomAnimationIndex];
        //ani.Play();
        if(i == 0)GetComponent<Animator>().SetBool("isEvent", true);
    }
}
