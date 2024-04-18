using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShooting : MonoBehaviour
{
    public InputActionReference gunShoot = null;
    public GameObject bullet;
    float triggerValue;

    GameObject bulletPoint;
    Rigidbody bulletRb;

    bool startShooting = true;
    void Start()
    {
        bulletPoint = this.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        triggerValue = gunShoot.action.ReadValue<float>();
        if (triggerValue > 0.5f)
        {
            shooting();
        }
    }

    void shooting()
    {
        if (startShooting)
        {
            GameObject newBullet = Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);
            newBullet.transform.forward = bulletPoint.transform.forward;
            bulletRb = newBullet.GetComponent<Rigidbody>();

            bulletRb.AddForce(newBullet.transform.forward, ForceMode.Impulse);

            StartCoroutine(shootManager());
            StartCoroutine(destroyBullet(newBullet));
        }
    }

    private IEnumerator shootManager()
    {
        startShooting = false;
        yield return new WaitForSeconds(0.5f);
        startShooting = true;
    }

    private IEnumerator destroyBullet(GameObject lastBullet)
    {
        yield return new WaitForSeconds(6f);
        Destroy(lastBullet);
    }
}
