using UnityEngine;
using System.Collections;

public class MineBlock : MonoBehaviour {

  public GameObject boxOutlinePrefab;
  public GameObject itemDropPrefab;

  private GameObject boxOutline;
  private Renderer[] wireFrame;


  public AudioClip mineSound;

  void Awake()
  {
    gameObject.name = "Block at ("+transform.position.x+","+transform.position.y+","+transform.position.z+")";
  }

  // Use this for initialization
  void Start ()
  {
    boxOutline = (GameObject)Instantiate( boxOutlinePrefab
                                        , transform.position
                                        , Quaternion.identity);

    wireFrame = boxOutline.GetComponentsInChildren<Renderer>();
    Debug.Log(wireFrame.Length);

    foreach( Renderer wire in wireFrame)
    {
      wire.enabled = false;
    }
  }

  void OnMouseDown()
  {
    AudioSource.PlayClipAtPoint( mineSound, transform.position);

    Debug.Log("Mining the block named " + gameObject.name + ".");

    Destroy(boxOutline);
    Destroy(gameObject);
    Instantiate( itemDropPrefab
               , transform.position
               , itemDropPrefab.transform.rotation);
  }

  void OnMouseEnter()
  {
    Debug.Log("Targeting block named " + gameObject.name + ".");
    //boxOutline.GetComponent<Renderer>().enabled = true;
    foreach( Renderer wire in wireFrame)
    {
      wire.enabled = true;
    }
  }

  void OnMouseExit()
  {
    Debug.Log("Done targeting block named " + gameObject.name + ".");
    //boxOutline.GetComponent<Renderer>().enabled = false;
    foreach( Renderer wire in wireFrame)
    {
      wire.enabled = false;
    }
  }

  // Update is called once per frame
  void Update () {
  
  }
}
