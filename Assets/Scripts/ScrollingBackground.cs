using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
/*
Mono era uma reescrita do .NET para Mac, onde o Unity foi baseado inicialmente.
� uma eran�a de 20 anos.
Esse tipo de arquivo � necess�rio para incluir scripts em objetos do Unity.
*/
public class ScrollingBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float _scrollSpeed = 0.05f;
    Vector2 _offset = new Vector2 (0.0f, 0.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _offset.x += _scrollSpeed * Time.deltaTime;
        spriteRenderer.material.mainTextureOffset = _offset;
    }
}
