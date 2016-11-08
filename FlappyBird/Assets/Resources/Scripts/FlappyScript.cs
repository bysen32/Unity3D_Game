using UnityEngine;
using System.Collections;

public class FlappyScript : MonoBehaviour {

    public GameObject IntroGUI, DeathGUI;
    public Collider2D restartButtonGameCollider;

    public float XSpeed = 1;
    public float VelocityPreJump = 3;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (GameStateManager.GameState == GameState.Intro)
        {
            MoveBirdOnXAxis();
            if (WasTouchedOrClicked())
            {
                BoostOnYAxis();
                GameStateManager.GameState = GameState.Playing;
                IntroGUI.SetActive(false);
                ScoreManagerScript.Score = 0;
            }

        }
        else if (GameStateManager.GameState == GameState.Playing)
        {
            MoveBirdOnXAxis();
            if (WasTouchedOrClicked())
            {
                BoostOnYAxis();
            }

        }
        else if (GameStateManager.GameState == GameState.Dead)
        {
            Vector2 contactPoint = Vector2.zero;
            if (Input.touchCount > 0)
                contactPoint = Input.touches[0].position;
            if (Input.GetMouseButton(0))
                contactPoint = Input.mousePosition;

            if (restartButtonGameCollider == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(contactPoint)))
            {
                GameStateManager.GameState = GameState.Intro;
                Application.LoadLevel(Application.loadedLevelName);
            }
        }
	}

    void FixedUpdate()
    {
        if (GameStateManager.GameState == GameState.Intro)
        {
            if (GetComponent<Rigidbody2D>().velocity.y < -1)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GetComponent<Rigidbody2D>().mass * 5500 * Time.deltaTime));
        }
        else if (GameStateManager.GameState == GameState.Playing || GameStateManager.GameState == GameState.Dead)
        {
            FixFlappyRotation();
        }

    }

    bool WasTouchedOrClicked()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
            return true;
        else
            return false;
    }

    void MoveBirdOnXAxis()
    {
        transform.position += new Vector3(Time.deltaTime * XSpeed, 0, 0);
    }

    void BoostOnYAxis()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, VelocityPreJump);
    }

    private void FixFlappyRotation()
    {

    }
}
