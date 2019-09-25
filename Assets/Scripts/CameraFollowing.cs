using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] bool follow = true;
    [SerializeField] GameObject target;
    [SerializeField] float cameraSpeed = 1f;
    [SerializeField] float zStop = 0f;

    Vector3 startPoint;
    Vector3 offset;

    void Start()
    {
        startPoint = transform.position;
        offset = startPoint - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null || transform.position.z > zStop)
        {
            SetFollow(false);
        }
        if(follow)
        {
            transform.position = Vector3.Slerp(transform.position, target.transform.position + offset, cameraSpeed * Time.deltaTime);
        }
    }

    public void ResetPosition()
    {
        transform.position = startPoint;
    }

    public void SetFollow(bool f)
    {
        follow = f;
    }

}
