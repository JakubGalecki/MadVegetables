using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyJumper : Enemy
{
    public float JumpSeriesInterval;
    public float JumpSeriesIntervalVariation;
    public int JumpSeriesNumber;
    private int jumpSeriesCurrentJump;
    public float JumpInterval;
    public float JumpIntervalVariation;
    public Vector3 JumpForce;
    public Vector3 JumpForceVariation;

    protected override void Start()
    {
        base.Start();
        Invoke("Jump", Random.Range(JumpSeriesInterval - JumpSeriesIntervalVariation, JumpSeriesInterval + JumpSeriesIntervalVariation));
    }

    void Jump()
    {
        float jumpForceX = Random.Range(JumpForce.x - JumpForceVariation.x, JumpForce.x + JumpForceVariation.x);
        float jumpForceY = Random.Range(JumpForce.y - JumpForceVariation.y, JumpForce.y + JumpForceVariation.y);
        float jumpForceZ = Random.Range(JumpForce.z - JumpForceVariation.z, JumpForce.z + JumpForceVariation.z);

        myRigidbody.AddForce(new Vector3(jumpForceX, jumpForceY, jumpForceZ), ForceMode.Impulse);

        jumpSeriesCurrentJump++;
        if (jumpSeriesCurrentJump >= JumpSeriesNumber)
        {
            Invoke("Jump", Random.Range(JumpSeriesInterval - JumpSeriesIntervalVariation, JumpSeriesInterval + JumpSeriesIntervalVariation));
            JumpSeriesNumber = 0;
        }
        else
        {
            Invoke("Jump", Random.Range(JumpInterval - JumpIntervalVariation, JumpInterval + JumpIntervalVariation));
        }
    }
}

