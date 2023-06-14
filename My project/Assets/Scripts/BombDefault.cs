using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDefault : MonoBehaviour
{
    private float coordsOffset = 0.5f;
    [Header("BombDefault")]
    public KeyCode inputKey = KeyCode.LeftShift;
    public GameObject bombGame;
    public float bombTimerLenght = 3f;
    public int bombStarterAmount = 1;
    private int bombsInventory;

    [Header("Explosion")]
    //public Explosion explosionPrefab;
    public LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;
    private void OnEnable()
    {
        bombsInventory = bombStarterAmount;
    }
    private void Update()
    {
        if (bombsInventory > 0 && Input.GetKeyDown(inputKey))
        {
            StartCoroutine(PlaceBomb());
        }
    }
    void Start()
    {
        
    }
    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bombGame, position, Quaternion.identity);
        bombsInventory--;

        yield return new WaitForSeconds(bombTimerLenght);

        position = bomb.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        //Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        //explosion.SetActiveRenderer(explosion.start);
        //explosion.DestroyAfter(explosionDuration);

        //Explode(position, Vector2.up, explosionRadius);
        //Explode(position, Vector2.down, explosionRadius);
        //Explode(position, Vector2.left, explosionRadius);
        //Explode(position, Vector2.right, explosionRadius);

        Destroy(bomb.gameObject);
        bombsInventory++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            other.isTrigger = false;
        }
    }

    // Update is called once per frame
}
