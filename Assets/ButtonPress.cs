using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private Sprite buttonPressed;
    [SerializeField] private Sprite buttonUnPressed;

    [SerializeField] public Tilemap tilemap;
    [SerializeField] public TileBase tileToPlace;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||collision.gameObject.CompareTag("Crate"))
        {
            Debug.Log("Button Pressed");
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;

            tilemap.SetTile(new Vector3Int(8, 0, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(8, -1, 0), tileToPlace);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate"))
        {
            Debug.Log("Button Released");
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonUnPressed;

            tilemap.SetTile(new Vector3Int(8, 0, 0), null);
            tilemap.SetTile(new Vector3Int(8, -1, 0), null);
        }
    }
}
