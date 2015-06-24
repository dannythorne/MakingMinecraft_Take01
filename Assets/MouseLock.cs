using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {

  public TextAsset crossHairsRaw;
  private Texture2D crossHairs;

  void LockCursor()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.SetCursor( crossHairs, new Vector2(8,8), CursorMode.Auto);
  }

  void UnlockCursor()
  {
    Cursor.lockState = CursorLockMode.None;
    Cursor.SetCursor( null, Vector2.zero, CursorMode.Auto);
    // Note cursor may not change back to original when running in the Unity
    // Game View. Build and run to test.
  }

  void Start()
  {
    crossHairs = new Texture2D(16,16);
    crossHairs.LoadImage(crossHairsRaw.bytes);

    LockCursor();
  }

  void OnMouseDown()
  {
    LockCursor();
  }

  void OnApplicationFocus( bool focusStatus)
  {
    if( focusStatus)
    {
      Debug.Log("Application Focused!");
      // TODO: Unpause Screen. Or provide a GUI button and wait for click?
    }
    else
    {
      // TODO: Pause Screen
    }
  }

  void Update()
  {
    if( Input.GetKeyDown("escape"))
    {
      UnlockCursor();
    }
    else if( Input.GetMouseButtonDown(0))
    {
      LockCursor();
    }
  }

}
