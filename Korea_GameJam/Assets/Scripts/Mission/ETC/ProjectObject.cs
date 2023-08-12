using DG.Tweening;
using UnityEngine;

public class ProjectObject : MonoBehaviour
{
    [SerializeField] private GameObject TargetObject;
    public bool IsStart { get; set; } = false;
    public bool IsClear { get; set; } = false;
    
    private Vector3 offSet;

    private float mZCoord;
    
    private Vector3 originPos;

    private void Awake()
    {
        originPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (!IsStart)
        {
            return;
        }
        
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
        offSet = gameObject.transform.position - GetMouseWorldPos();
        
        transform.DOLocalRotate(new Vector3(0 , 0, 0), 0.3f);
    }
    
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    private void OnMouseDrag()
    {
        if (!IsStart)
        {
            return;
        }
        
        transform.position = GetMouseWorldPos() + offSet;
    }

    private void OnMouseUp()
    {
        if (!IsStart)
        {
            return;
        }
        
        if (Vector3.Distance(transform.position, TargetObject.transform.position) < 0.2f)
        {
            transform.position = TargetObject.transform.position;
            transform.rotation = TargetObject.transform.rotation;
            IsStart = false;
            IsClear = true;
            return;
        }
        
        transform.position = originPos;
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}
