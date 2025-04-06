using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MinmapCamera : MonoBehaviour
{
    public Transform player;
    public float Y;
    private Vector3 targetV3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetV3 = player.position;
        targetV3.y = Y;
        transform.position = targetV3;
    }
}
