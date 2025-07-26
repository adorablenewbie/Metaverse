using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private float interpolateSpeed = 5f;
    Vector3 interpolate = new Vector3(0, 0, 0);
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 adjustPosition = new Vector3(0, 0, -10);

    void Start()
    {
        targetObject = GameObject.Find("Player");
    }

    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        startPosition = mainCamera.transform.position;
        endPosition = targetObject.transform.position + adjustPosition;
        mainCamera.transform.position = Vector3.Lerp(startPosition, endPosition, interpolateSpeed * Time.deltaTime);

    }
}
