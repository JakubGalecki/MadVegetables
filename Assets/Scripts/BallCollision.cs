using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallCollision : MonoBehaviour
{
    public int BallType;
    public GameObject Shard;
    public List<AudioClip> SploshSound;

    // Use this for initialization
    void Start()
    {
        Invoke("DestroyMe", Random.Range(3,5));
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy scriptEnemy = (Enemy)collision.gameObject.GetComponent(typeof(Enemy));
            if (scriptEnemy.EnemyType == BallType || scriptEnemy.EnemyType > 2)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);

                int numberOfShards = Random.Range(5, 10);
                
                for (int i = 0; i < numberOfShards; i++)
                {
                    GameObject shard = (GameObject)Instantiate(Shard);
                    Rigidbody shardRigidBody = shard.GetComponent<Rigidbody>();
                    shard.transform.position = collision.gameObject.transform.position+Vector3.up;
                    shard.transform.rotation = Random.rotationUniform;
                    

                    shardRigidBody.AddForce(Random.onUnitSphere * 6 + Random.Range(2, 6) * Vector3.up - collision.relativeVelocity/4, ForceMode.Impulse);
                }

                AudioSource.PlayClipAtPoint(SploshSound[Random.Range(0, SploshSound.Count)], Vector3.zero);
                //SploshSound[Random.Range(0, SploshSound.Count)].isReadyToPlay();             
            }
        }
    }
}
