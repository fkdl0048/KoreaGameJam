using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickerState
{
    None,
    Up,
    Down
}

public class SoundMixerPicker : MonoBehaviour, IInteraction
{
    public bool IsStart { get; set; } = false;
    public PickerState IsPickerState { get; set; } = PickerState.None;

    public void Init()
    {
        IsStart = true;
    }
    
    private Vector3 offSet;
    
    private float mZCoord;
    
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
        offSet = gameObject.transform.position - GetMouseWorldPos();
    }
    
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    private void OnMouseDrag()
    {
        Vector3 mousePos = GetMouseWorldPos() + offSet;

        transform.position = new Vector3(transform.position.x, transform.position.y , mousePos.z);
        

        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -3.6f, -3.1f));
        
        if (transform.position.z >= -3.1f)
        {
            IsPickerState = PickerState.Up;
        }
        else if (transform.position.z <= -3.6f)
        {
            IsPickerState = PickerState.Down;
        }
        else
        {
            IsPickerState = PickerState.None;
        }
    }


    public void Interaction()
    {
        
    }
}
