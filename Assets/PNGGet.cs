using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PNGGet : MonoBehaviour
{
    public Sprite spriteToSave;  // 在Inspector中拖入的精灵

    void Start()
    {
        if (spriteToSave != null)
        {
            // 保存精灵为PNG文件
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
        // 创建一个新的Texture2D，尺寸为精灵的尺寸
        Texture2D texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height, TextureFormat.RGBA32, false);

        // 获取精灵纹理的像素数据并设置到新的Texture2D
        texture.SetPixels(sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                   (int)sprite.textureRect.y,
                                                   (int)sprite.textureRect.width,
                                                   (int)sprite.textureRect.height));
        texture.Apply();

        // 将Texture2D保存为PNG文件
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(path, bytes);

        Debug.Log("Sprite saved as PNG to " + path);
    }
}
