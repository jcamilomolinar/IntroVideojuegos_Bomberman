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
    public int bombsInventory;

    [Header("Explosion")]
    public Explosion explosionStart;
    public Explosion explosionMiddle;
    public Explosion explosionEnd;
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

        Explosion explosion = Instantiate(explosionStart, position, Quaternion.identity);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);

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
    private Collider2D checkNextPos(Vector2 position, Vector2 direction)
    {
        Vector2 position2 = position;
        return Physics2D.OverlapCircle(position2 + direction, 0);

    }
    private void Explode(Vector2 position, Vector2 direction, int radius)
    {
        Collider2D NextPos = checkNextPos(position, direction);

        if (NextPos != null)
        {
            if (NextPos.CompareTag("Unbreakable"))
            {
                return;
            }

            if (NextPos.CompareTag("Breakable"))
            {
                Explosion explosion = Instantiate(explosionEnd, position + direction, Quaternion.identity);
                explosion.SetDirection(direction);
                explosion.DestroyAfter(explosionDuration);
                return;
            }
        }
        for (int i = 0; i <= radius; i++)
        {
            position += direction;
            NextPos = checkNextPos(position, direction);
            if (NextPos != null)
            {
                if (NextPos.CompareTag("Unbreakable"))
                {
                    Explosion explosionfinale = Instantiate(explosionEnd, position, Quaternion.identity);
                    explosionfinale.SetDirection(direction);
                    explosionfinale.DestroyAfter(explosionDuration);
                    return;
                }
                if (NextPos.CompareTag("Breakable"))
                {
                    Explosion explosionmid = Instantiate(explosionMiddle, position, Quaternion.identity);
                    explosionmid.SetDirection(direction);
                    explosionmid.DestroyAfter(explosionDuration);
                    Explosion explosionfinale = Instantiate(explosionEnd, position + direction, Quaternion.identity);
                    explosionfinale.SetDirection(direction);
                    explosionfinale.DestroyAfter(explosionDuration);
                    return;
                }
            }
            if (i == radius)
            {
                Explosion explosionfinale = Instantiate(explosionEnd, position, Quaternion.identity);
                explosionfinale.SetDirection(direction);
                explosionfinale.DestroyAfter(explosionDuration);
                return;
            }
            Explosion explosion = Instantiate(explosionMiddle, position, Quaternion.identity);
            explosion.SetDirection(direction);
            explosion.DestroyAfter(explosionDuration);

        }


    }

    // Update is called once per frame
}
