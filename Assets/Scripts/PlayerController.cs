using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetAxis("Horizontal")!=0)
        {
            transform.position += Vector3.right * Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += Vector3.forward * Input.GetAxis("Vertical");

        }
    }
}
