using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private float interpolateSpeed = 5f;
    Vector3 interpolate = new Vector3(0, 0, 0);
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 adjustPosition = new Vector3(0, 0, -10);

    [SerializeField]
    private float maxPositionx = 0;
    [SerializeField]
    private float maxPositiony = 0;
    [SerializeField]
    private float minPositionx = 0;
    [SerializeField]
    private float minPositiony = 0;
    private float height;
    private float width;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    Vector2 mapSize;


    void Start()
    {
        targetObject = GameObject.Find("Player");
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        startPosition = transform.position;
        endPosition = targetObject.transform.position + adjustPosition;
        transform.position = Vector3.Lerp(startPosition, endPosition, interpolateSpeed * Time.deltaTime);

        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, center.x - lx, center.x + lx);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, center.y - ly, center.y+ ly);

        transform.position = new Vector3(clampX, clampY, -10f);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}
