using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    [SerializeField] PinManager pinManager;

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "BowlingPin")
        {
            pinManager.RemovePin(collision.gameObject);
        }
        if(collision.gameObject.tag == "BowlingBall")
        {
            collision.gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "MainCamera")
        {
            collision.gameObject.GetComponent<CameraFollowing>().SetFollow(false);
        }
    }
}
