using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int dano = 1;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 transformDown = transform.up * -1.0f;

        rb.velocity = transformDown * speed;
    }

    void OnTriggerEnter2D (Collider2D HitInfo)
    {
       EnemyAI enemy =  HitInfo.GetComponent<EnemyAI>();
       if (enemy != null)
        {
            enemy.TakeDamage(1);
        }
        Destroy(gameObject);

        BossHealth boss =  HitInfo.GetComponent<BossHealth>();
       if (boss != null)
        {
            boss.TakeDamage(2);
        }
        Destroy(gameObject);
    }

    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
