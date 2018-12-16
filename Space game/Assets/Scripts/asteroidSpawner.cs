using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour {

	public List<GameObject> spawners;
	public List<Sprite> asteroidSprites;
	public int spawnRate;
	private float cooldown;

	public GameObject asteroid;
	public float timer;
	private float defaultTimer;
	void Start () {
		cooldown = timer;
		defaultTimer = timer;
	}


	void Update () {
		int choice = Random.Range(0, spawners.Count);
		float spawnChance = 1-(spawnRate / 10f);
		float spawn = (Random.Range(0f, 10f));
		spawn /= 10;
		//Prevents 2 objects spawning in the same spawner.
		//If it happens, it will just spawn the asteroid at the opposite end of where it would originally spawn.
		if(spawners[choice].transform.childCount > 0)
			choice -= spawners.Count;
			if (choice < 0)
				choice *= -1;
		if(spawnChance <= spawn && timer <= 0)
		{
			
			Debug.Log("Spawning Rock");
			GameObject spawnedAsteroid = Instantiate(asteroid,spawners[choice].transform);
			SpriteRenderer sAS = spawnedAsteroid.GetComponent<SpriteRenderer>();
			int index = Random.Range(0, asteroidSprites.Count);
			sAS.sprite = asteroidSprites[index];
			resetCollider(spawnedAsteroid);
			timer = cooldown;
			timer -= 0.5f;
			checkTimer();
			cooldown = timer;
			// Debug.Log(spawnChance);
			// Debug.Log(spawn);
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

	private void resetCollider(GameObject go)
	{
		//Resets the asteroids collider for the different sprites
		Destroy(go.GetComponent<PolygonCollider2D>());
		go.AddComponent<PolygonCollider2D>();
	}
}
