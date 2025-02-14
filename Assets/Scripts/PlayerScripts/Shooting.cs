using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    // shooting
    public GameObject Bullet;
    public Transform BulletSpawn;
    public float bulletVelocity;
    public float bulletDuration = 10f;
    public int bulletNumber = 50;
    public float fireRate;
    private bool enableShoot = true;

    private int newbulletNumber = 0;
    //audio
    public GameObject AudioClip;
    public float clipLenght;
    
    //rotation
    private float duration = 2f;
  

    
    public Image ammoCircle;
    public TextMeshProUGUI BulletText;


    void Start()
    {
        AudioClip.SetActive(false);
        newbulletNumber = bulletNumber;
        BulletText.text = bulletNumber.ToString();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(FireBullet());
            
        }

        
    }
     IEnumerator Recoil()
    {
        Quaternion currentRotation = transform.localRotation;
        Quaternion targetRotation = currentRotation * Quaternion.Euler(-2f, 0, 0);
        SmoothRotation(currentRotation, targetRotation);
        yield return new WaitForSeconds(0.1f);
        SmoothRotation(targetRotation, currentRotation);
        
    }

    private void SmoothRotation(Quaternion from, Quaternion to)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(from, to, elapsedTime / duration);
            
        }
        transform.localRotation = to; 
    }

    public IEnumerator FireBullet()
    {
        if (bulletNumber > 0 && enableShoot)
        {
            enableShoot = false;
            StartCoroutine(Recoil());
            StartCoroutine(StartSound());
            //GameObject newBullet = Instantiate(Bullet, BulletSpawn.position, Quaternion.identity);
           // newBullet.GetComponent<Rigidbody>().AddForce(BulletSpawn.forward.normalized * bulletVelocity);
            //StartCoroutine(DestroyBullet(newBullet, bulletDuration));
            bulletNumber -= 1;
            yield return new WaitForSeconds(fireRate);
            enableShoot = true;


        }

        //making new bullet
        ammoCircle.fillAmount = (float)bulletNumber / (float)newbulletNumber;
        BulletText.text = bulletNumber.ToString();
    }

    public void RefillBullets(int amount)
    {
        
        bulletNumber +=amount;
        newbulletNumber = bulletNumber;
        BulletText.text = bulletNumber.ToString();
        
        ammoCircle.fillAmount = (float)bulletNumber/newbulletNumber;
    }

    // private IEnumerator DestroyBullet(GameObject bullet, float duration)
    // {      
    //         yield return new WaitForSeconds(duration);
    //         Destroy(bullet);
    //     
    // }

    private IEnumerator StartSound()
    {
        AudioClip.SetActive(true);
        yield return new WaitForSeconds(clipLenght);
        AudioClip.SetActive(false);
    }
    
    void SetAmmo()
    {
        ammoCircle.fillAmount = (float)bulletNumber/newbulletNumber;
    }

}
