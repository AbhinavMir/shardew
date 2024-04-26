using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    public override void Hit()
    {
        Debug.Log("Tree Cut");
        Destroy(gameObject);
    }
}
