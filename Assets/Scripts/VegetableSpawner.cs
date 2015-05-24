using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VegetableSpawner : MonoBehaviour {

    public Transform vegetable;
    public List<Sprite> sprites;

	void Start () {
        InvokeRepeating("SpawnVegetable", 2, 2F);
	}

    void SpawnVegetable()
    {
        Transform instance = Instantiate(vegetable) as Transform;
        instance.position = new Vector3(Random.Range(-5,5), 0, 15);
        SpriteRenderer spriteRend = instance.GetComponentsInChildren<SpriteRenderer>()[0];
        int spriteType = Random.Range(0, sprites.Count);
        spriteRend.sprite = sprites[spriteType];
        Enemy scriptEnemy = (Enemy)instance.GetComponent(typeof(Enemy));
        scriptEnemy.EnemyType = spriteType;
    }
}
