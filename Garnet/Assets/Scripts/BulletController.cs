using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed = 1;
	public float lifeSpan = 0;
	public float maxLife = 2;
    private Vector3 X = new Vector3(0, -1, 0);
    //private Vector3 rotation = new Vector3(0, 180, 0);

	void Start()
	{
		transform.Rotate (0, 0, 180);
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(X * bulletSpeed * Time.deltaTime*-1);
		lifeSpan += Time.deltaTime;
		if (lifeSpan >= maxLife) 
		{
			Destroy (gameObject);
		}
        //transform.Rotate(rotation);
    }
}
