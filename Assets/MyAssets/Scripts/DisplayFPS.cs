using UnityEngine;
using System.Collections;

public class DisplayFPS : MonoBehaviour
{
    float deltaTime = 0.0f;

    void Update()
    {
        //For time keeping 
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        //get the resolution of your phone's screen
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        /*
         TextAnchor will anchor the FPS counter to  a specified position on your phone.
         LowerCenter worked perfectly for me, but if you do not want that go to the below
         link to see what other anchor properties you can use.
         https://docs.unity3d.com/ScriptReference/TextAnchor.html
         */
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = w * 2 / 100;
        /* You can change the floating values to make your FPS counter text a different colour.
         Keep in mind that each value for "new Color" (RGBA) is between 0 and 1. Anything outside
         of that range won't register well.
         */
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}