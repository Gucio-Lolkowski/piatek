using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 10 * Time.deltaTime, 0));
    }

   
    public virtual void Picked()
    {

        print("Bazowa: Picked");
        Destroy(gameObject);
    }
}
