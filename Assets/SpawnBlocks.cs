using UnityEngine;
using System.Collections;

public class SpawnBlocks : MonoBehaviour {

  public GameObject block;

  // Use this for initialization
  void Start ()
  {
    int i, j, k;
    int n, nk;
    float r;

    n = 16;
    for( j=-n; j<=n; j++)
    {
      for( i=-n; i<=n; i++)
      {
        r = Mathf.Sqrt( i*i + j*j);
        nk = (int)( Mathf.Floor( 4*Mathf.Sin(r/4) + 4) );
        for( k=0; k<nk; k++)
        {
          Instantiate( block, new Vector3( i, k, j), Quaternion.identity);
        }
      }
    }
  }
  
  // Update is called once per frame
  void Update ()
  {
  }
}
