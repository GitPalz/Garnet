using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed = 1;
    private Vector3 X = new Vector3(0, -1, 0);
    //private Vector3 rotation = new Vector3(0, 180, 0);

    // Update is called once per frame
    void Update()
    {
        transform.Translate(X * bulletSpeed * Time.deltaTime);
        //transform.Rotate(rotation);
    }
}
