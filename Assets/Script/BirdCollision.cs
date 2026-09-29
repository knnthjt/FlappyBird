using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit object: " + collision.gameObject.name + " with tag: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Pipe"))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger hit object: " + collision.gameObject.name + " with tag: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Pipe"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GetComponent<BirdJump>().enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.simulated = false;

        PipeSpawner spawner = Object.FindFirstObjectByType<PipeSpawner>();
        if (spawner != null) spawner.enabled = false;

        PipeMove[] pipes = Object.FindObjectsByType<PipeMove>(FindObjectsSortMode.None);
        foreach (PipeMove pipe in pipes)
        {
            pipe.enabled = false;
        }
    }
}
