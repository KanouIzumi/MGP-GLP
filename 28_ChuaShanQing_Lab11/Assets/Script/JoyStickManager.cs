using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class JoyStickManager : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public static JoyStickManager instance;
    public RectTransform pad;

    //this deadzone is to check if the stick is move more than 50%
    public float deadZone;

    private Vector2 directionVec;
    private Vector2 normalized;
    private float vecX;
    private float vecY;

    float inputH = JoyStickManager.instance.GetDirection().x;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
        normalized = transform.localPosition/(pad.rect.width * 0.5f);

        if(normalized.x > deadZone || normalized.x < -deadZone)
        {
            vecX = transform.localPosition.x;
        }
        else
        {
            vecX = 0;
        }

        if(normalized.y > deadZone || normalized.y < -deadZone)
        {
            vecY = transform.localPosition.y;
        }
        else
        {
            vecY = 0;
        }

        directionVec = new Vector3(vecX, vecY, 0).normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
        directionVec = Vector2.zero;
    }

    public Vector2 GetDirection()
    {
        return directionVec;
    }

}
