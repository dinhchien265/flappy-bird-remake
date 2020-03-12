using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public float bounceForce;
    private Rigidbody2D rigidbody2D;
    private Animator anim;

    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip flyClip, pingClip, dieClip;

    private bool isAlive, didFlap;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        BirdMoveMent();
    }
    void BirdMoveMent()
    {
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                rigidbody2D.velocity = new Vector2(0, bounceForce);
                audio.PlayOneShot(flyClip);
            }
        }


        if (rigidbody2D.velocity.y > 0)
        {
            float angle = Mathf.Lerp(0, 90, rigidbody2D.velocity.y / 5);
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, -rigidbody2D.velocity.y / 3);
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
    public void FlapButton()
    {
        didFlap = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pipe Holder")
        {
            audio.PlayOneShot(pingClip);
            score++;
            if (GamePlayControler.instance)
            {
                GamePlayControler.instance.SetScore(score);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            audio.PlayOneShot(dieClip);
            anim.SetBool("isDead", true);
            Time.timeScale = 0;
            if (GamePlayControler.instance)
            {
                GamePlayControler.instance.BirdDieShowPanel(score);
            }
        }
    }
}
