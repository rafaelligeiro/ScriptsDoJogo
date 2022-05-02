using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPlayerAttack : MonoBehaviour
{
    
    private Rigidbody2D rig;
    private Animator anim;
    public Transform shotpoint;
    public GameObject bullet;
    [SerializeField] private float BulletAmount;
    public AudioSource ShotgunSound;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            {
                Shoot();
                ShotgunSound.Play();
            }
        
        if(!Input.GetMouseButtonDown(0))
            {
                anim.ResetTrigger("ShotgunAttack");
            }
    }

    void Shoot()
    {
        CinemachineShake.Instance.ShakeCamera(5f, .1f);
        anim.SetTrigger("ShotgunAttack");
        Instantiate(bullet, shotpoint.position, transform.rotation * Quaternion.Euler(0f, 0f, 90f));
        bullet.GetComponent<BulletsLife>().TakeBullet(BulletAmount);
    
    }
}
