using UnityEngine;

public class GunController : MonoBehaviour
{

    public bool isFiring;

    public BulletController bullet;

    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;


    // Use this for initialization
    void Start()
    {
        shotCounterReset();

        firePoint.position.Set(
            firePoint.position.x,
            firePoint.position.y,
            firePoint.position.z);
    }

    // Update is called once per frame
    void Update()
    {
		shotCounter -= Time.deltaTime;
		if (shotCounter <= 0)
        {
            
			if (isFiring) 
            {
                //var rotation = new Quaternion(firePoint.rotation.x, firePoint.rotation.y, firePoint.rotation.z, firePoint.rotation.w);
                shotCounterReset();
                BulletController newBullet =
                    Instantiate(bullet, firePoint.position, firePoint.rotation)
                    as BulletController;
                //newBullet.transform.rotation = Quaternion.Euler(0f, 0f, newBullet.transform.rotation.z);
                newBullet.bulletSpeed = bulletSpeed;
            }
        }
        //else
        //{
        //    shotCounter = 0;
        //}
    } // Update()

    void shotCounterReset()
    {
        shotCounter = timeBetweenShots;
    }
}
