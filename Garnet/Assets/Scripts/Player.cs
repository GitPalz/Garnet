using UnityEngine;

public class Player : MonoBehaviour
{

    public GunController theGun;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) theGun.isFiring = true;
        if (Input.GetMouseButtonUp(0)) theGun.isFiring = false;
    }
}
