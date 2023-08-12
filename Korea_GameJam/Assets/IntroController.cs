using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.transform.DOLocalRotate(new Vector3(15f, 0, 0), 0.7f).SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
