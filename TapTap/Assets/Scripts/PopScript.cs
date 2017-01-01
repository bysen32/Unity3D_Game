using UnityEngine;
using System.Collections;

public class PopScript : MonoBehaviour {
    private int m_Score;
    public UILabel m_ScoreLabel;
    void Start() {
    }

    void Update() {
        Rigidbody rigibody = GetComponent<Rigidbody>();
        if (GameScene.GetInstance().m_GameState == GameScene.GAME_STATE.PLAYING) {
            Vector3 force = new Vector3(Random.Range(-Speed, Speed), Random.Range(-Speed, Speed), 0).normalized * Speed;
            if (rigibody.velocity == Vector3.zero) {
                rigibody.velocity = force;
            }
            if (rigibody.velocity.sqrMagnitude < Speed / 3) {
                rigibody.AddForce(force);
            }
        }
        else {
            rigibody.velocity = Vector2.zero;
        }
    }

    public float Speed {
        get {
            int level = GameScene.GetInstance().Level;
            return GameObjManager.GetInstance().m_Lv2Speed[level];
        }
    }

    public int Score {
        set {
            m_Score = value;
            m_ScoreLabel.text = value.ToString();
        }
        get { return m_Score; }
    }
}
