using UnityEngine;

public class GroundCheaker : MonoBehaviour
{
    public bool isGround;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        Debug.Log(isGround);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = false;
        }
        Debug.Log(isGround);
    }

}
