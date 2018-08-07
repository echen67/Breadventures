using UnityEngine;
using System.Collections;

public class test3 : MonoBehaviour {

	public void test()
    {
        Debug.Log("test");
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        Debug.Log("click");
    }
}
