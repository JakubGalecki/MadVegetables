using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnumVegetableColor
{
    RedVegetable,
    YellowVegetable,
    GreenVegetable,
    BlueVegetable,
    WhiteVegetable,
}

public class Enemy : MonoBehaviour 
{
    protected Rigidbody myRigidbody;    
    public int EnemyType;
    public EnumVegetableColor VegetableColor;
    public int StartingHealth;

	protected virtual void Start () 
    {
        myRigidbody = GetComponent<Rigidbody>();
        Invoke("EnemyJump", Random.Range(0.2f,2));
	}

    void Update()
    {
        if (transform.position.z < -8)
        {
            Destroy(this.gameObject);
        }
    }
	
    void EnemyJump()
    {
        myRigidbody.AddForce(new Vector3(0, Random.Range(3,4), -Random.Range(2,3)), ForceMode.Impulse);
        Invoke("EnemyJump", Random.Range(1.5f, 3));
    }
}
