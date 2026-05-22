using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;

    public AudioClip collisionSound; // 碰撞声音文件
    private AudioSource audioSource; // 音频源组件

    void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // 禁止在加载时自动播放
        audioSource.clip = collisionSound; // 设置音频剪辑
    }

    void OnCollisionEnter(Collision collision)
    {
        // 当球对象与其他对象发生碰撞时播放声音
        if (collision.relativeVelocity.magnitude > 0.5f) // 设定一个最低速度阈值，以防止小碰撞触发声音
        {
            audioSource.Play();
        }
    }

    void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

        if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		
		//gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}