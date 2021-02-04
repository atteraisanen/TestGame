using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField]private Transform target;
    public float fRadius = 3.0f;
    [SerializeField] private float offset;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(target.position); //Gets the position of the target in world coordinates
        pos = Input.mousePosition - pos;    //Get the vector between mouse position and the position of target
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;    //Calculate angle in radians and convert it into degrees
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));   //Modify the shield's z rotation by angle and offset.
        pos = Quaternion.AngleAxis(angle, Vector3.forward) * (Vector3.right * fRadius); //Create rotation around player, with the distance from the player set by the fRadius variable
        transform.position = target.position + pos;     //Add pos to the player's position
    }
}
