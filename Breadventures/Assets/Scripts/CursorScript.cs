using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

    public Texture2D defaultCursor;
    public Texture2D speechCursor;

	void Start () {
        DefaultCursor();
	}

    public void DefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SpeechCursor()
    {
        Cursor.SetCursor(speechCursor, Vector2.zero, CursorMode.Auto);
    }
}
