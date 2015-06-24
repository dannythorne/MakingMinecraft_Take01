using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour {

  public AudioClip collectSound;

  void Start()
  {
  }
  
  void Update()
  {
  }

  void OnTriggerEnter( Collider collider)
  {
    if( collider.tag == "Player")
    {
      Debug.Log("Trigger");
      AudioSource.PlayClipAtPoint( collectSound, transform.position);
      Destroy(gameObject);
    }
  }
}
