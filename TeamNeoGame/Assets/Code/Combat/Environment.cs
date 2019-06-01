/******************************
 * Author: Nico
 * Description: Changes the environ
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Environment
    {
        City,
        Grass
    }
static class EnvironmentC
{
    public static Sprite PlatformSprite(this Environment env)
    {
        switch (env)
        {
            case Environment.City:
                return Resources.Load<Sprite>("Environment/PlatformCity");
            case Environment.Grass:
                return Resources.Load<Sprite>("Environment/PlatformGrass");
            default:
                return Resources.Load<Sprite>("Environment/Platform");

        }
    }
    public static Sprite BackgroundSprite(this Environment env)
    {
        switch (env)
        {
            case Environment.City:
                return Resources.Load<Sprite>("Environment/BackgroundCity");
            case Environment.Grass:
                return Resources.Load<Sprite>("Environment/BackgroundGrass");
            default:
                return Resources.Load<Sprite>("Environment/Background");
        }
    }
}