using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyDragUI : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public GameObject key;
    public float dragSpeed;
    [SerializeField]
    private Vector3 beginDragPoint;
    [SerializeField]
    private float dragValue = 0;
    public float dragEndValue;

    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dragEndValue<=dragValue)
        {
            FindAnyObjectByType<MissionManager_001>().Drag();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        beginDragPoint = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (beginDragPoint.x < Input.mousePosition.x)
        {
            rt.Rotate(new Vector3(0, 0, -dragSpeed * Time.deltaTime));
            //key.Rotate()
            dragValue += dragSpeed * Time.deltaTime;
        }
        else
        {
            rt.Rotate(new Vector3(0, 0, +dragSpeed * Time.deltaTime));
            dragValue += dragSpeed * Time.deltaTime;
        }
    }
}
