using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float distanceToPickup = 1f;
    [SerializeField] float ttl = 10f;

    void Awake()
    {
        player = GameManager.instance.player.transform;
        // Destroy(gameObject, ttl);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > distanceToPickup)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
