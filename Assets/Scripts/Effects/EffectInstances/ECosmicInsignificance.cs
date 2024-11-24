using System.Collections;
using UnityEngine;

public class ECosmicInsignificance : Effect
{
    private float mainCameraSize;
    [SerializeField] private float targetZoomMultiplier;
    private float targetZoom;
    private float defaultZoom;
    private float zoomSpeed = 1f;
    void Awake()
    {
        mainCameraSize = GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize;
        defaultZoom = mainCameraSize;
        targetZoom = defaultZoom * targetZoomMultiplier;
        throw new System.NotImplementedException();
    }

    void Update()
    {
        if (mainCameraSize <= targetZoom)
        {
            mainCameraSize += zoomSpeed;
        }
        else
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            if (scrollInput != 0f)
            {
                // Adjust the orthographic size for orthographic cameras
                mainCameraSize -= scrollInput * zoomSpeed;
                if (mainCameraSize <= defaultZoom)
                    CompleteEffect();
            }
        }
        throw new System.NotImplementedException();
    }

    public override void CompleteEffect()
    {
        Destroy(gameObject);
        throw new System.NotImplementedException();
    }
}
