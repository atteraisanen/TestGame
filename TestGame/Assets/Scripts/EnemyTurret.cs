using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    private Transform target;
    [SerializeField] private string targetName;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float startShotCd;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float offset;
    [SerializeField] private float shotForce;
    [SerializeField] private float lerpSpeed;
    private float shotCd;

    private void Start()
    {
        target = GameObject.Find(targetName).transform;
        shotCd = startShotCd;
    }

    void FixedUpdate()
    {
        TurnTowardsTarget();
        if(shotCd <= 0)
        {
            Shoot();
        } else
        {
            shotCd -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject instBullet = Instantiate(bullet, shotPoint.position, Quaternion.identity);
        instBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * shotForce);
        Destroy(instBullet, 30);
        shotCd = startShotCd;
    }

    void TurnTowardsTarget()
    {
        Vector3 pos = target.position - transform.position;
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(0, angle + offset, Time.deltaTime * lerpSpeed)));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle + offset)), lerpSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
