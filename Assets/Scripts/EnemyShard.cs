using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShard : MonoBehaviour 
{
    public List<Sprite> ColorSprites;
    public List<Sprite> ShadowsSprites;

	void Start () {
        SpriteRenderer mySpriteRendererColor = GetComponentsInChildren<SpriteRenderer>()[0];
        SpriteRenderer mySpriteRendererShadows = GetComponentsInChildren<SpriteRenderer>()[1];	
        int randomSpriteIndex = Random.Range(0, ColorSprites.Count);
        Quaternion randomRotation = Random.rotationUniform;

        mySpriteRendererColor.sprite = ColorSprites[randomSpriteIndex];
        mySpriteRendererShadows.sprite = ShadowsSprites[randomSpriteIndex];
        mySpriteRendererColor.gameObject.transform.rotation = randomRotation;
        mySpriteRendererShadows.gameObject.transform.rotation = randomRotation;

        mySpriteRendererColor.color = new Color(Random.value, Random.value, Random.value);
        Invoke("DestroyMe", 3);
	}

    void DestroyMe()
    {
        Destroy(gameObject);
    }

	void Update () {
	
	}
}
