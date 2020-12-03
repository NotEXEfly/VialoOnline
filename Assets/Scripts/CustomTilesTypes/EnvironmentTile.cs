using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/Environment")]
public class EnvironmentTile : Tile
{
    public string Description;

    [CreateTileFromPalette]
    public static TileBase CreateEnvironmentTile(Sprite sprite)
    {
        var environmentTile = ScriptableObject.CreateInstance<EnvironmentTile>();
        environmentTile.sprite = sprite;
        environmentTile.name = sprite.name;
        environmentTile.colliderType = ColliderType.Grid;
        environmentTile.Description = "Object";
        return environmentTile;
    }
}

