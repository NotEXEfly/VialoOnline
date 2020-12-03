﻿using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

[CustomEditor(typeof(EnvironmentTile))]
public class CustomTilePreviewRenderer : UnityEditor.Editor
{
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        Tile tile = AssetDatabase.LoadAssetAtPath<Tile>(assetPath);
        if (tile.sprite != null)
        {
            Texture2D spritePreview = AssetPreview.GetAssetPreview(tile.sprite); // Get sprite texture

            Color[] pixels = spritePreview.GetPixels();
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = pixels[i] * tile.color; // Tint
            }
            spritePreview.SetPixels(pixels);
            spritePreview.Apply();

            Texture2D preview = new Texture2D(width, height);
            EditorUtility.CopySerialized(spritePreview, preview); // Returning the original texture causes an editor crash
            return preview;
        }
        return null;
    }
}
