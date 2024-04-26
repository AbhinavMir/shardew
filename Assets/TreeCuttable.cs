using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropAmount = 5;
    [SerializeField] float spread = 0.7f;
    public override void Hit()
    {
        while (dropAmount > 0)
        {
            dropAmount--;

            Vector3 dropPosition = transform.position;
            dropPosition.x += spread * Random.Range(-1f, 1f);
            dropPosition.y += spread * Random.Range(-1f, 1f);

            GameObject drop = Instantiate(pickUpDrop, dropPosition, Quaternion.identity);
            drop.transform.position = dropPosition;

        }
        Debug.Log("Tree Cut");
        Destroy(gameObject);
    }
}
