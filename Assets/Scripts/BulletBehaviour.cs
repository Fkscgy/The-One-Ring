using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float projectileDmg; 
    public float varSpeed;
    public float timeDestroy;
    public static int typeOfBullet = 1;
    public Sprite emoji1;
    public Sprite emoji2;
    public Sprite emoji3;
    // Start is called before the first frame update
    void Start()
    {
        if (typeOfBullet == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = emoji1;
            gameObject.GetComponentInChildren<ParticleSystem>().textureSheetAnimation.SetSprite(0,emoji1);
        }
        if (typeOfBullet == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = emoji2;
            gameObject.GetComponentInChildren<ParticleSystem>().textureSheetAnimation.SetSprite(0,emoji2);
        }
        if (typeOfBullet == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = emoji3;
            gameObject.GetComponentInChildren<ParticleSystem>().textureSheetAnimation.SetSprite(0,emoji3);
        }
    }
    
    void Update()
    {   
        Invoke("DestroyGameObject", timeDestroy);
        transform.Translate(Vector2.right * varSpeed * Time.deltaTime);
    } 
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();
        if (collision.gameObject.CompareTag("Ground"))
        {
            DestroyGameObject();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeHit(projectileDmg);
            DestroyGameObject();
        }
    }
    void DestroyGameObject()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<ParticleSystem>().Stop();
            Destroy(child.gameObject, timeDestroy);
        }
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
