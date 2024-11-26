using System.Collections;
using UnityEngine;

public class ECosmicInsignificance : Effect
{
    private Camera mainCamera;
    [SerializeField] private float targetZoomMultiplier;
    private float targetZoom;
    private float defaultZoom;
    private float zoomSpeed = 0.25f;
    private bool canScroll = false;
    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        defaultZoom = mainCamera.orthographicSize;
        targetZoom = defaultZoom * targetZoomMultiplier;
        StartCoroutine(ZoomOut());
    }

    void Update()
    {
        if (canScroll)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            if (scrollInput != 0f)
            {
                // Adjust the orthographic size for orthographic cameras
                mainCamera.orthographicSize -= scrollInput * (zoomSpeed * 4);
                if (mainCamera.orthographicSize <= defaultZoom)
                    CompleteEffect();
            }
        }
    }

    public override void CompleteEffect()
    {
        Destroy(gameObject);
        throw new System.NotImplementedException();
    }

    private IEnumerator ZoomOut()
    {
        while (mainCamera.orthographicSize <= targetZoom)
        {
            mainCamera.orthographicSize += zoomSpeed;
            yield return new WaitForSeconds(0.05f);
        }
        canScroll = true;
    }
}

