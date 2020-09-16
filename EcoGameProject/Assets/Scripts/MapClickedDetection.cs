using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClickedDetection : MonoBehaviour
{
    public static MapClickedDetection mapClickedDetectionInstance;
    public string HitDetection;
    public void Awake()
    {
        if (mapClickedDetectionInstance == null)
            mapClickedDetectionInstance = this;
        else
            Destroy(gameObject);

    }

    public string Detection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 Point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D Hit = Physics2D.Raycast(Point, Vector2.zero);
            if (Hit.collider != null)
            {
                Debug.Log(Hit.collider.name);
                HitDetection = Hit.collider.name;
            }
            else
                HitDetection = "";
        }
        return HitDetection;
    }
}
