using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject gameObjectToFollow;
    private void LateUpdate()
    {
        transform.position = gameObjectToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
