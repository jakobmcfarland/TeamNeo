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

    public static Color ToColor(this Element e)
    {
        switch (e)
        {
            case Element.Fire:
                return new Color(1, 0, 0);
            case Element.Grass:
                return new Color(1, 0, 0.85f);
            case Element.Tan:
                return new Color(0,0,0.85f);
            case Element.Water:
                return new Color(1,1,0);
            default:
                //Won't happen
                return new Color(0,0,0);
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
        } else if (e == Element.Water)
        {
            switch(c)
            {
                case Element.Fire:
                    return 1;
                case Element.Tan:
                    return -1;
            }
        } else if (e == Element.Tan)
        {
            switch(c)
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