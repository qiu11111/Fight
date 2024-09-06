using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PNGGet : MonoBehaviour
{
    public Sprite spriteToSave;  // ��Inspector������ľ���

    void Start()
    {
        if (spriteToSave != null)
        {
            // ���澫��ΪPNG�ļ�
            string savePath = Path.Combine(Application.persistentDataPath, spriteToSave.name + ".png");
            SaveSprite(spriteToSave, savePath);
        }
        else
        {
            Debug.LogError("No sprite assigned.");
        }
    }

    void SaveSprite(Sprite sprite, string path)
    {
        // ����һ���µ�Texture2D���ߴ�Ϊ����ĳߴ�
        Texture2D texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height, TextureFormat.RGBA32, false);

        // ��ȡ����������������ݲ����õ��µ�Texture2D
        texture.SetPixels(sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                   (int)sprite.textureRect.y,
                                                   (int)sprite.textureRect.width,
                                                   (int)sprite.textureRect.height));
        texture.Apply();

        // ��Texture2D����ΪPNG�ļ�
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(path, bytes);

        Debug.Log("Sprite saved as PNG to " + path);
    }
}
