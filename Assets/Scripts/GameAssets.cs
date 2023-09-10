using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    private void Awake()
    {
        instance = this;
    }

    public Sprite snakeHeadSprite;
    public Sprite foodSprite;
    public Sprite snakeBodySprite;
}
