using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectionScript : MonoBehaviour
{
    private PearlScript pearlScript;

    public GameObject deadTop;
    public GameObject deadBottom;

    private Rigidbody2D topRB;
    private Rigidbody2D bottomRB;
    private void Start()
    {
        pearlScript = GetComponentInParent<PearlScript>();
        topRB = deadTop.GetComponent<Rigidbody2D>();
        bottomRB = deadBottom.GetComponent<Rigidbody2D>();

        pearlScript.AliveGO.SetActive(true);
        deadTop.SetActive(false);
        deadBottom.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player" || collision.transform.name == "Ground")
        {
            pearlScript.DeadState();
        }
    }

    private void BreakApart()
    {
        deadBottom.transform.position = pearlScript.AliveGO.transform.position;
        deadTop.transform.position = pearlScript.AliveGO.transform.position;

        deadTop.SetActive(true);
        deadBottom.SetActive(true);
        pearlScript.AliveGO.SetActive(false);

        topRB.AddForce(Vector2.right * Random.Range(10, 20), ForceMode2D.Impulse);
        bottomRB.AddForce(Vector2.right * Random.Range(10, 20), ForceMode2D.Impulse);

        Destroy(GameObject.Find("Pearl(Clone)"), 0.5f);

    }
}
