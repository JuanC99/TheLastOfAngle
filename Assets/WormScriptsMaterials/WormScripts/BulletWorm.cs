using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWorm : MonoBehaviour
{
    public float damage = 10f;
    [SerializeField] private float duration = 5f;
    [SerializeField] private GameObject effectExplosionVFX;

    private void Start()
    {
        StartCoroutine(StartProjectileDuration());
    }

    IEnumerator StartProjectileDuration()
    {
        yield return new WaitForSeconds(duration);
        if (gameObject != null)
        {
            GameObject explosionVFX = Instantiate(effectExplosionVFX, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == GameConstants.PLAYER_TAG || GameConstants.GROUND_TAG == other.transform.tag)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);

                GameObject explosionVFX = Instantiate(effectExplosionVFX, transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject, 2f);
            }
        }
    }
}
