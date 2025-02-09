using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public Transform cameraTransform;
    [SerializeField] private Vector2 parallax;
    private Vector3 lastCameraPosition;
    private Vector2 textureUnitSize;
    private void Start()
    {
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSize.x = 10 * texture.width / sprite.pixelsPerUnit;
        textureUnitSize.y = 10 * texture.height / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallax.x, deltaMovement.y * parallax.y);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSize.x)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSize.y;
            transform.position = new Vector3 (cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
        if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSize.y)
        {
            float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSize.y;
            transform.position = new Vector3 (transform.position.x, cameraTransform.position.y + offsetPositionY);
        }
    }

}
