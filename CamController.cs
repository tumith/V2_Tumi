using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player;
    public float RotationsSpeed = 5.0f;
    public float SmoothFactor = 0.5f;

    private Vector3 offset;
    private bool RotateAroundPlayer = true;
    private bool LookAtPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
                                                            //video fyrir camera rotate : https://www.youtube.com/watch?v=xcn7hz7J7sI
                                                            // Update is called once per frame
    void LateUpdate()
    {
        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);

            offset = camTurnAngle * offset;
        }

        transform.position = player.transform.position + offset;

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(player.transform);
    }
}
