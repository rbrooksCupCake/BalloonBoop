using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalloonBehavior : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;

    public SpriteRenderer MySpriteRender;

    public GameObject MainMenu;
    public GameObject MainPlay;
    public GameObject GameOver;

    public Transform BalloonPosition;

    public ScoreBehavior MyScoreBehavior;
    public TextMeshProUGUI GameOverText;
    public bool IsGameStarted = false;

    public Color OriginalColor;

    private void Awake()
    {
        OriginalColor = MySpriteRender.color;
    }

    private void Update()
    {
        if(IsGameStarted)
        {
            if (!MySpriteRender.isVisible)
            {
                GameOverEvent();
            }
        }
    }

    void GameOverEvent()
    {
        MainPlay.SetActive(false);
        GameOver.SetActive(true);
        MyRigidBody.gravityScale = 0.0f;
        MyScoreBehavior.Reset();
        MyRigidBody.velocity = Vector2.zero;
        MyRigidBody.angularVelocity = 0f;
        GameOverText.text = MyScoreBehavior.ScoreText.text;
        MySpriteRender.color = OriginalColor;
        gameObject.GetComponent<Transform>().position = BalloonPosition.position;
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.zero);
        IsGameStarted = false;
    }

    private void OnMouseDown()
    {
        if(!IsGameStarted)
        {
            IsGameStarted = true;
        }

        if(IsGameStarted)
        {
            MyScoreBehavior.AddPoint();
            MainMenu.SetActive(false);
            MainPlay.SetActive(true);
            GameOver.SetActive(false);

            Vector3 ColorValues = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            MySpriteRender.color = new Color(ColorValues.x, ColorValues.y, ColorValues.z, 1.0f);
            int LeftOrRight = Random.Range(1, 3);
            float XForce = 50f;
            if (LeftOrRight == 2)
            {
                XForce = 50f;
            }
            else
            {
                XForce = -50f;
            }
            MyRigidBody.gravityScale = 1.0f;
            MyRigidBody.AddForce(new Vector2(XForce, 500f));
            MyRigidBody.AddTorque(XForce);
        }
    }
}
