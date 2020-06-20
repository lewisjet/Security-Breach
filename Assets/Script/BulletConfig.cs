using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletConfig : MonoBehaviour
{
    [Range(0, 50)] [SerializeField] float speed = 1f;
    [SerializeField] float damage = 100f;
    [SerializeField] bool piercing = false;
    [SerializeField] AudioClip shotsfx = null;
 //   [Range(0f, 1f)] [SerializeField] float volume = 0.75f;
    [SerializeField] BulletType bulletType = new BulletType();
    Vector2 direction = new Vector2();
    const string BULLET_PARENT_NAME = "Bullets";
    GameObject bulletParent;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    public float GetDamage()
    {
        return damage;
    }

    public bool TellIfPiercing()
    {
        return piercing;
    }

    private void Start()
    {
        if (bulletType == BulletType.enemy) { direction = Vector2.left; } else { direction = Vector2.right; }
        if (shotsfx) { AudioSource.PlayClipAtPoint(shotsfx, Camera.main.transform.position, PlayerPrefController.GetMasterVolume()); }

        CreateBulletParent();
        gameObject.transform.parent = bulletParent.transform;
    }

    enum BulletType
    {
        defensive,
        enemy
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attacker = collision.GetComponent<Attacker>();
        var health = collision.GetComponent<Health>();
        if (health && attacker) { health.TakeDamage(damage); }
        if (!piercing) { Destroy(gameObject); }
    }

    private void CreateBulletParent()
    {
        if (GameObject.Find(BULLET_PARENT_NAME)) { bulletParent = GameObject.Find(BULLET_PARENT_NAME); }
        else { Debug.LogError("Null reference exeption: BULLET_PARENT_NAME != Existing GameObject!"); }
    }

    

}
