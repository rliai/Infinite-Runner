using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBird : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField]
    private Transform bird;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - bird.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vv = bird.position + offset;
        vv.y = transform.position.y;
        transform.position = vv;
    }
}
