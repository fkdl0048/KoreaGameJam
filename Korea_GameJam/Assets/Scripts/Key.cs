using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private Transform origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "KeyHole")
        {
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "KeyHole")
        {
        }
    }
}
