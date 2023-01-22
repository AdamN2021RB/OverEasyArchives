using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Checklist:
    //Make the UFO move = done
    //make the ufo create a tractor beam to lift cows and eggs = done
    //ufo must collect all eggs to win = done
    //if cow is abducted on accident, player loses = done

    [Header("Move")]
    public float speed = 6;

    float horizontal;
    float vertical;
    public float xMin = -0.5f, xMax = 0.5f;
    public float yMin = -0.5f, yMax = 0.5f;


    [Header("Abduction")]
    public ParticleSystem loseKaboom;

    [Header("Audio")]
    public AudioClip beamClip;
    public AudioClip eggGet;
    public AudioClip loseBoom;
    public AudioClip winSound;
    public AudioClip loseSound;

    public AudioClip bGM;
    public AudioSource soundSource;

    public AudioSource winLose;

    public AudioSource suckComplete;

    [Header("Abducting")]
    bool abduction = false;
    public GameObject tractBeamPrefab;

    [Header("Win Condition")]
    int eggCount;
    bool cowPickUp;

    float timeBeforeWinScreen = 2f;

    public Coroutine Death;
    public TimerScript timer;
    
    // Start is called before the first frame update
    void Start()
    {
        winLose.clip = bGM;
        winLose.Play();
        eggCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            abduction = true;
            Debug.Log("tractor beam activated");
            soundSource.clip = beamClip;
            soundSource.Play();
            soundSource.loop = true;
            
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            abduction = false;
            Debug.Log("tractor beam deactivated");
            soundSource.Stop();
        }


        if (eggCount == 3)
        {
            if (timeBeforeWinScreen > 0)
        {
            timeBeforeWinScreen -= Time.deltaTime;
        }

        else
        {
            timeBeforeWinScreen = 0;
            Debug.Log("lose game");
            SceneManager.LoadScene("GameOverWin");
        }
        }
    }

    //make the UFO move
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        //Debug.Log(horizontal);

        vertical = Input.GetAxis("Vertical");
        position.y = position.y + speed * vertical * Time.deltaTime;
        //Debug.Log(vertical);
        position.x = Mathf.Clamp(position.x, xMin, xMax);
        position.y = Mathf.Clamp(position.y, yMin, yMax);
        transform.position = position;
        
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //checks if it's touching stuff with PickUp tag
        if (other.collider.tag == "Egg" && abduction == true)
        {
            suckComplete.clip = eggGet;
            suckComplete.Play();
            eggCount = eggCount + 1;
            Destroy(other.gameObject);
            Debug.Log("point get");
            CheckForWin();
        }

        if (other.collider.tag == "Cow" && abduction == true)
        {
            Destroy(timer.gameObject);
            Debug.Log("lost game");
            CheckForLoss();
        }
    }

    void CheckForWin()
    {
        if (eggCount == 3)
        {
            winLose.clip = winSound;
            winLose.Play();
            Destroy(timer.gameObject);
            Debug.Log("WIN!!!!");
            //player wins
        }
    }

    void CheckForLoss()
    {
        ParticleSystem Explode = Instantiate(loseKaboom, transform.position, Quaternion.identity);
        Explode.transform.parent = null;
        winLose.clip = loseSound;
        winLose.Play();
        Death.Death();
        Destroy(gameObject);
    }

}
