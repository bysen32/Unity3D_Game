using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public static class ImageSlicer
{
    [MenuItem("Assets/ImageSlicer/Process to Sprites")]
    static void ProcessToSprite()
    {
        Texture2D image = Selection.activeObject as Texture2D;//获取旋转的对象
        string rootPath = Path.GetDirectoryName(AssetDatabase.GetAssetPath(image));//获取路径名称
        string path = rootPath + "/" + image.name + ".PNG";//图片路径名称


        TextureImporter texImp = AssetImporter.GetAtPath(path) as TextureImporter;//获取图片入口


        AssetDatabase.CreateFolder(rootPath, image.name);//创建文件夹


        foreach (SpriteMetaData metaData in texImp.spritesheet)//遍历小图集
        {
            Texture2D myimage = new Texture2D((int)metaData.rect.width, (int)metaData.rect.height);

            for (int y = 0; y < metaData.rect.height; ++y) {
                for (int x = 0; x < metaData.rect.width; ++x) {
                    myimage.SetPixel(x, y, image.GetPixel(x + (int)metaData.rect.x, y + (int)metaData.rect.y));
                }
            }

            //转换纹理到EncodeToPNG兼容格式
            if (myimage.format != TextureFormat.ARGB32 && myimage.format != TextureFormat.RGB24)
            {
                Texture2D newTexture = new Texture2D(myimage.width, myimage.height);
                newTexture.SetPixels(myimage.GetPixels(0), 0);
                myimage = newTexture;
            }
            var pngData = myimage.EncodeToPNG();

            AssetDatabase.CreateAsset(myimage, rootPath + "/" + image.name + "/" + metaData.name + ".PNG");
            File.WriteAllBytes(rootPath + "/" + image.name + "/" + metaData.name + ".PNG", pngData);
            AssetDatabase.Refresh();
        }
    }
}