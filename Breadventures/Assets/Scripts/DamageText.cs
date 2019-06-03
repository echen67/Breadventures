using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    // Attach this script to DamagePopupParent
    public Animator animator;       // DamagePopup's animator

    private Text damageText;

    // Start is called before the first frame update
    void Awake()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        damageText = animator.GetComponent<Text>();
        //Debug.Log("Start: ");
        //Debug.Log(damageText);
    }

    public void SetText(string text)
    {
        //Debug.Log("SetText");
        //Debug.Log(damageText);
        damageText.text = text;
    }
}
