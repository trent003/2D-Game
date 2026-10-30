using UnityEngine;

// to have camera follow lowest position player
public class CameraMovement : MonoBehaviour
{

    //tracking each player
    public Transform ember;
    public Transform ripple;

    //where camera sits compared to lowest player
    public float cameraPosition = 2f;

    void LateUpdate()
    {

        //determine which payer is lowest
        float whichPlayerLowest = Mathf.Min(ember.position.y, ripple.position.y);

        //move camera towards the lowestx player
        transform.position = new Vector3(transform.position.x, whichPlayerLowest + cameraPosition, transform.position.z);
    }
}