using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour {

	public List<GameObject> spawners;
	public List<Sprite> asteroidSprites;
	public int spawnRate;
    public bool leftOrRight;
	private float cooldown;
    // public bool allowMoreThanOne;
    public float scaleFactor = 2f;
    public GameObject asteroid;
    public float timer;

    private float defaultTimer;
    private int count = 0;
    private int increaseCount = 10;
    void Start () {
        timer = Mathf.Floor(Random.Range(3, 5));
		cooldown = timer;
		defaultTimer = timer;
        
	}


	void Update () {
		int choice = Random.Range(0, spawners.Count);
        // float spawnChance = 1 - (spawnRate / 10f);
		float spawn = (Random.Range(0f, 10f));
		spawn /= 10;
        // Debug.Log(spawn);

		//Prevents 2 objects spawning in the same spawner.
		//If it happens, it will just spawn the asteroid at the opposite end of where it would originally spawn.
        //It really doesnt I guess, but oh well.
        //It more delays the inevitable of one spawning on the same 
		if(spawners[choice].transform.childCount > 0)
        {
            choice -= spawners.Count;
            if (choice < 0)
                choice *= -1;
            // Debug.Log(choice);
        }
			
		if(timer <= 0)
		{
			

			// Debug.Log("Spawning Rock");
			GameObject spawnedAsteroid = Instantiate(asteroid,spawners[choice].transform);
            spawnedAsteroid.transform.position += new Vector3(12, 2, 0);
            FloatLeft fl = spawnedAsteroid.GetComponent<FloatLeft>();
            int randomVel = Random.Range(120, 150);
            fl.speed = new Vector2(randomVel, 0);
            // Explodable ex = spawnedAsteroid.GetComponent<Explodable>();
            if(leftOrRight)
                fl.speed *= -1f;
            // spawnedAsteroid.transform.localScale += new Vector3(scaleFactor,scaleFactor,0);
			SpriteRenderer sAS = spawnedAsteroid.GetComponent<SpriteRenderer>();
			int index = Random.Range(0, asteroidSprites.Count);
			sAS.sprite = asteroidSprites[index];
			resetCollider(spawnedAsteroid);
			spawnedAsteroid.GetComponent<PolygonCollider2D>().isTrigger = true;
			timer = cooldown;
			// timer -= 0.5f;
			// checkTimer();
			cooldown = timer;
            // Debug.Log(spawnChance);
            // Debug.Log(spawn);
            //I'll finish it a different time
            count++;
            if (count == increaseCount)
            {
                cooldown -= .1f;
                increaseCount += 10 * count;
                //Debug.Log("yeeeeet");
                // Debug.Log(cooldown)

            }
            

		}
		else
		{

			// Debug.Log("Spawn Chance" + spawnChance);
			// Debug.Log("Spawn" + spawn);
			// Debug.Log(timer);
			timer -= Time.deltaTime;
			// Debug.Log(choice);

		}
	}

	void checkTimer()
	{
		if(timer <= 1f)
			timer = Random.Range(3f,defaultTimer);
	}
    public void decreaseTimer()
    {
        timer -= .5f;

    }

  


    private void resetCollider(GameObject go)
	{
		//Resets the asteroids collider for the different sprites
		Destroy(go.GetComponent<PolygonCollider2D>());
		go.AddComponent<PolygonCollider2D>();
	}
}
