using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;

public class BallDrag : MonoBehaviour
{
    bool isDragging;
    Vector2 initialMousePosition;
    Vector2 currentMousePosition;
    Transform sling;
    int nextBallType;
    SpriteRenderer previewBallSprite;

    public List<Sprite> sprites;

    public Transform Projectile;

    void Start()
    {
        sling = GameObject.FindGameObjectsWithTag("Sling")[0].transform;
        previewBallSprite = GameObject.FindGameObjectsWithTag("NextBall")[0].GetComponent<SpriteRenderer>();
        UpdatePreviewBall();
    }

    void Update()
    {

        if (isDragging)
        {
            currentMousePosition = Input.mousePosition;
            Vector2 slingPos =  (currentMousePosition - initialMousePosition) / 100;
            sling.localPosition = new Vector3(slingPos.x, 2, slingPos.y);//Camera.main.ScreenToWorldPoint(currentMousePosition);
            //Vector3 cameraRotation = Camera.main.transform.rotation.eulerAngles;
            //cameraRotation.y = Input.mousePosition.x;
            //Camera.main.transform.rotation = Quaternion.Euler(cameraRotation);
        }

        if (Input.GetMouseButtonDown(0) && isDragging == false)
        {
            isDragging = true;
            initialMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) && isDragging == true)
        {
            isDragging = false;
            Transform ball = Instantiate(Projectile, new Vector3(0, 4, -8), Quaternion.identity) as Transform;
            Rigidbody ballRigid = ball.GetComponent<Rigidbody>();
            SpriteRenderer ballSprite = ball.GetComponent<SpriteRenderer>();
            Vector3 strength = -(currentMousePosition - initialMousePosition) / 30;
            ballRigid.AddForce(strength.x, 1, strength.y, ForceMode.Impulse);
            
            ballSprite.sprite = sprites[nextBallType];
            BallCollision scriptBall = (BallCollision)ball.GetComponent(typeof(BallCollision));
            scriptBall.BallType = nextBallType;
            UpdatePreviewBall();
        }
    }

    void UpdatePreviewBall()
    {
        nextBallType = Random.Range(0, sprites.Count);
        previewBallSprite.sprite = sprites[nextBallType];
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        //Handles.DrawLine(Vector2.zero, (currentMousePosition - initialMousePosition) / 100);
    }
#endif
}