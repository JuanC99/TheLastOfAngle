using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormWeaponsController : MonoBehaviour
{
    [SerializeField] private WormAnimationController animationController;
    [SerializeField] private WormController wormController;
    [SerializeField] private Transform player;
    [SerializeField] private Transform canonPosition;

    [Header("BulletsConfig")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 3f;
    [SerializeField] private float secondsBetweenProjectiles = 3f;
    [SerializeField] private bool shootingBullets = false;


    void Start()
    {
    }

    public void ActivateWeapons()
    {
        StartCoroutine(ShootProjectiles());
    }
    // Update is called once per frame
    IEnumerator ShootProjectiles()
    {
        while (wormController.health >= 0)
        {
            if (shootingBullets)
                StartCoroutine(ShootProjectile());
            yield return new WaitForSeconds(secondsBetweenProjectiles);
        }
        yield return new WaitForSeconds(0f);
    }

    public IEnumerator ShootProjectile()
    {

        StartCoroutine(animationController.ShootProjectile());
        yield return new WaitForSeconds(1f);
        if (wormController.health >= 0)
        {
            GameObject bullet = Instantiate(projectile, canonPosition.position, Quaternion.identity) as GameObject;
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            bullet.transform.rotation = canonPosition.rotation;
            rb.AddForce(canonPosition.forward * 1000f);
            yield return new WaitForSeconds(1f);
            while (true)
            {
                if (bullet != null)
                {
                    bullet.transform.LookAt(player, Vector3.up);
                    bullet.transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
                    Debug.DrawRay(bullet.transform.position, bullet.transform.forward * 100f, Color.green);
                }
                else
                {
                    break;
                }

                yield return new WaitForSeconds(Time.deltaTime * 0.1f);
            }
        }
        yield return new WaitForSeconds(0f);
    }



}
