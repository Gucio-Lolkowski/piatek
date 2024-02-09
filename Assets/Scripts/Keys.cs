using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum KeyColor
{
    RedKey, GreenKey, BlueKey
}
public class Keys : PickUp 
{
    public KeyColor ColorKey;
 
    public override void Picked()
    {

        GameManager.Instance.AddKey(ColorKey);



        base.Picked();
    }

}
