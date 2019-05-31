using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    private CanvasGroup canvasGroup;
    private bool pauseOpen = false;
    private int canvasAlpha = 0;
    public GameObject[] childrenList;
    private Collider2D[] childrenColliders;

    void Awake()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        childrenColliders = new Collider2D[childrenList.Length];
        for(int i = 0; i < childrenList.Length; i++)
        {
            childrenColliders[i] = childrenList[i].GetComponent<Collider2D>();
        }
        /*foreach (Collider2D collider in childrenColliders)
        {
            collider.enabled = false;
        }*/
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseOpen = !pauseOpen;
            canvasAlpha = pauseOpen ? 1 : 0;
            canvasGroup.alpha = canvasAlpha;
            canvasGroup.interactable = !canvasGroup.interactable;
            canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
            /*foreach(Collider2D collider in childrenColliders)
            {
                collider.enabled = pauseOpen;
            }*/
        }
    }
}
