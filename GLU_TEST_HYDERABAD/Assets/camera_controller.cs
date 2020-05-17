using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    
    //Start is called before the first frame update
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }

// Update is called once per frame
void Update()
    {
    //    this.transform.position = player.transform.position-new Vector3(0,0,10);
       // this.transform.LookAt(player.transform);
       // this.transform.rotation = player.transform.rotation;
    }
}
