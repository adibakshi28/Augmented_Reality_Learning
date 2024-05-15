using UnityEngine;
using System.Collections;

public class FruitBehav : MonoBehaviour {

	public GameObject fruitSlicedPrefab, effect;
	public float startForce = 15f,rotSpeed=5;
	public int fruitIndex;

	private Vector3 rot;

	Rigidbody2D rb;
	FruitSpawner fruitSpawner;

	void Start ()
	{
		fruitSpawner = GameObject.FindGameObjectWithTag ("FruitSpawner").GetComponent<FruitSpawner> ();
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
//		rot = new Vector3 (rotSpeed,rotSpeed,rotSpeed);
		rot = new Vector3 (Random.Range(0,rotSpeed),Random.Range(0,rotSpeed),Random.Range(0,rotSpeed));
	}

	void Update(){
		transform.Rotate (rot);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rot = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rot)as GameObject;
			Vector3 vfxPos = new Vector3 (transform.position.x, transform.position.y, -2);
			GameObject vfx = Instantiate(effect, vfxPos, Quaternion.identity)as GameObject;

			fruitSpawner.FruitSlashCheck (fruitIndex);

			Destroy (vfx, 0.5f);
			Destroy(slicedFruit, 3f);
			Destroy(gameObject);
		}

		if (col.tag == "Bottom")
		{
			fruitSpawner.FruitFallCheck (fruitIndex);
			Destroy(gameObject);
		}
	}
}
