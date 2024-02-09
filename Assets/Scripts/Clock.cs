using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public int TimetoAdd = 5;


    public override void Picked()
    {
        GameManager.Instance.AddTime(TimetoAdd);

        base.Picked();
    }
}
