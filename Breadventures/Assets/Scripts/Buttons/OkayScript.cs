using UnityEngine;
using System.Collections;

public class OkayScript : MonoBehaviour {

    void OnMouseDown()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        Debug.Log("WORKKK");
    }
}
