#if UNITY_EDITOR
using UnityEditor.Tilemaps;
#endif
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/Environment")]
public class EnvironmentTile : Tile
{
    public string Description;

#if UNITY_EDITOR
    [CreateTileFromPalette]
    public static TileBase CustomEnvironmentTile(Sprite sprite)
    {
        var environmentTile = CreateInstance<EnvironmentTile>();
        environmentTile.sprite = sprite;
        environmentTile.name = sprite.name;
        environmentTile.colliderType = ColliderType.Grid;
        environmentTile.Description = "Object";
        return environmentTile;
    }
#endif
}

