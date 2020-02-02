using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    [SerializeField]
    public WeaponMinigameManager manager;
    public GameObject beatBar;
    public int numberOfBeats;
    protected int numberOfBeatsSpawned = 0;
    public int numberOfCorrectInputsNeeded;
    protected int numberOfCorrectHitsNeeded;
    protected int numberOfCorrectHits = 0;
    protected Queue<float> inputTimes = new Queue<float>();
    public float postLeeway;
    public float preLeeway;
    private bool setupComplete = false;
    private bool previousInput = false;
    private bool needReset = false;
    private float currentBeatTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBeatsInARow());
    }

    protected IEnumerator SpawnBeatsInARow()
    {
        float currentTime = Time.time;
        SpawnBeat();
        inputTimes.Enqueue(currentTime + 2f);
        numberOfBeatsSpawned++;
        if(numberOfBeatsSpawned < numberOfBeats)
        {
            yield return new WaitForSeconds((float).8);
            StartCoroutine(SpawnBeatsInARow());
        }
        else
        {
            StartCoroutine(EndGame());
        }
        
    }

    protected IEnumerator EndGame()
    {
        yield return new WaitForSeconds((float)2.5);
        if(numberOfCorrectHits > numberOfCorrectHitsNeeded)
        {
            manager.WinMinigame();
        }
        else
        {
            manager.LoseMinigame();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && currentBeatTime != 0 && !previousInput)
        {
            previousInput = true;
            
            if (currentBeatTime - preLeeway < Time.time && !needReset)
            {
                numberOfCorrectHits++;
                print(numberOfCorrectHits);
                this.GetComponent<Animator>().SetTrigger("Correct");
            }
            else
            {
                this.GetComponent<Animator>().SetTrigger("Incorrect");
                needReset = true;
            }
            StartCoroutine(WaitThenResetTriggers());
            StartCoroutine(ReallowInputAfterHalfASecond());
        }

        if(inputTimes.Count > 0 && Time.time > currentBeatTime + postLeeway)
        {
            currentBeatTime = inputTimes.Dequeue();
            needReset = false;
        }
    }

    private IEnumerator WaitThenResetTriggers()
    {
        yield return new WaitForSeconds((float)0.02);
        
        GetComponent<Animator>().ResetTrigger("Correct");
        GetComponent<Animator>().ResetTrigger("Incorrect");
    }

    protected IEnumerator ReallowInputAfterHalfASecond()
    {
        yield return new WaitForSeconds((float).3);
        previousInput = false;

    }

    void Awake()
    {
    }

    /*
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(beatBar, new Vector2(transform.position.x+10,transform.position.y), Quaternion.identity);
            Instantiate(beatBar, new Vector2(transform.position.x - 10, transform.position.y), Quaternion.identity);

            nextTimeToSpawn = Time.time + 1f / spawnRate;
        }
    }
    */

    public void SpawnBeat()
    {
        Instantiate(beatBar, new Vector2(transform.position.x + 10, transform.position.y), Quaternion.identity);
        Instantiate(beatBar, new Vector2(transform.position.x - 10, transform.position.y), Quaternion.identity);
    }
}
