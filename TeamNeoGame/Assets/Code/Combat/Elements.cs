using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    Fire,
    Water,
    Grass,
    Tan
}

static class ElementC
{
    public static float ToDegrees(this Element e)
    {
        switch (e)
        {
            case Element.Fire:
                return 0;
            case Element.Water:
                return 90;
            case Element.Grass:
                return 270;
            case Element.Tan:
                return 180;
            default:
                return 0;
        }
    }
    public static Color ToColor(this Element e)
    {
        switch (e)
        {
            case Element.Fire:
                return new Color(0.835f, 0.21f, 0.19f);
            case Element.Grass:
                return new Color(0.26f, 0.66f, 0.168f);
            case Element.Tan:
                return new Color(0.99f, 0.83f, 0.34f);
            case Element.Water:
                return new Color(0.2f, 0.2f, 0.81f);
            default:
                //Won't happen
                return new Color(0, 0, 0);
        }
    }
    public static int Beats(this Element e, Element c)
    {
        if (e == Element.Fire)
        {
            switch (c)
            {
                case Element.Grass:
                    return 1;
                case Element.Water:
                    return -1;
            }
        }
        else if (e == Element.Grass)
        {
            switch (c)
            {
                case Element.Fire:
                    return -1;
                case Element.Tan:
                    return 1;
            }
        }
        else if (e == Element.Water)
        {
            switch (c)
            {
                case Element.Fire:
                    return 1;
                case Element.Tan:
                    return -1;
            }
        }
        else if (e == Element.Tan)
        {
            switch (c)
            {
                case Element.Water:
                    return 1;
                case Element.Grass:
                    return -1;
            }
        }
        return 0;
    }
}