using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

    public Texture2D cursorTexture;

	void Start () {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
	}
}
