using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin Config")]
public class SkinConfig : ScriptableObject
{
    public List<Skin> listSkin;
}

[Serializable]
public class Skin
{
    public SkinType type;
    public List<SpriteImage> listSprites;
}

[Serializable]
public class SpriteImage
{
    public NormalItem.eNormalType type;
    public Sprite sprite;
}

[Serializable]
public enum SkinType
{
    Skin1,
    Skin2
}
