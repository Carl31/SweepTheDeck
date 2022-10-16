using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class that holds a Wave object and controls how it executes/spawns enemies etc.
 * Is very extensible - simply add required variables within the class (e.g. int difficulty or int totalCoints)
 * Will be used for Code review - Carl
*/

public class WaveSpawner : MonoBehaviour
{

    public enum WaveState {  SPAWNING, WAITING, COUNTING };
        // SPAWNING - wave is in the process of spawning specified number of enemies
        // WAITING - wave is waiting for enemies to be killed before continuing (to countdown)
        // COUNTING - wave is counting down before next wave can start

    [System.Serializable] // allows us to change the bewlow values of this class within Unity
    public class Wave
    {
        public string name; // for name of each wave
        public Transform enemy; // reference to prefab that we want to instantiate at each spawn point - NOTE: will have to have reference an enemy constructor for multiple enemy types!
        public int enemyAmount; // num of enemy spawns per wave
        public float spawnRate; // enemy spawn rate 

    }

    public Transform[] enemySpawnPoints; // array of enemy spawn points (in our case, only left and right side of screen).
    public Wave[] waves; // our array of waves
    private int nextWave = 0; // stores index of next wave to be executed
    public float waveInterval = 5f; // time between waves (seconds)
    private float waveCountdown;
    private WaveState state = WaveState.COUNTING;
    private float enemySearchCountdown = 1f; // see IsAnEnemyAlive method

    // Start is called before the first frame update
    void Start()
    {
        if (enemySpawnPoints.Length == 0)
        {
            Debug.Log("Error: no spawn points have been made!");
        }
        waveCountdown = waveInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == WaveState.WAITING)
        {
            if (!IsAnEnemyAlive())
            {
                // begin a new round
                NewWave();

            }
            else // keep waiting
            {
                return;
            }
        }

        if (waveCountdown <= 0) // if it's time to spawn the next wave
        {
            if (state != WaveState.SPAWNING) // and if not already spawning the current wave, then start spawning the next wave
            {
                StartCoroutine(SpawnWave(waves[nextWave])); // have to use 'StartCoroutine' since it's a IEnumerator function
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime; // else decrease countdown
        }
    }

    IEnumerator SpawnWave(Wave wave) // allows a method to wait a number of seconds before continuing
    {
        state = WaveState.SPAWNING;

        for (int i = 0; i < wave.enemyAmount; i++) // spawn all enemies
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate); // applies specified enemy spawn delay (i.e the whole purpose of using IEnumerator)
        }

        state = WaveState.WAITING; // waiting for player to kill all enemies

        yield break; // returns nothing -- avoids error since IEnumerator functions need to return a value
    }

    void SpawnEnemy(Transform enemy) // spawns an enemy
    {
        // spawn enemy here
        Debug.Log("Spawning enemy: " + enemy.name);

        int spawnSide = Random.Range(0, enemySpawnPoints.Length);
        enemy.transform.localScale = new Vector3(-2.6f, 2.6f, 0.0f);

        Transform currentSpawnPoint = enemySpawnPoints[spawnSide]; // spawsn enemy on either left or right of screen (randomly)
        currentSpawnPoint.position += new Vector3(0f, -0.1f, 0f);
        Instantiate(enemy, currentSpawnPoint.position, currentSpawnPoint.rotation);
    }

    bool IsAnEnemyAlive() // returns if there are any more enemies left in the wave
    {
        enemySearchCountdown -= Time.deltaTime; // only searches for enemy every second instead of every frame -- less resource intensive
        if (enemySearchCountdown <= 0)
        {
            enemySearchCountdown = 1f; // reset countdown
            if (GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                return false; // no enemies exist
            }

        }

        return true; 
    }

    void NewWave()
    {
        Debug.Log("Wave completed!");

        state = WaveState.COUNTING;
        waveCountdown = waveInterval;

        if (nextWave + 1 > waves.Length - 1)
        {
            //nextWave = 0; // enable this line for restarting at wave 1.
            Debug.Log("All waves complete!");
        }
        else
        {
            nextWave++;
        }
    }
}
