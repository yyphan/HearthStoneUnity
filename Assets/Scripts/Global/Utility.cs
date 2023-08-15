using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    // Gives a list of offsets along the X axis to be added to the origin
    public static List<float> CalculateXOffsets(int itemsCount, float offSet)
    {
        List<float> xOffsets = new List<float>();

        float mid = itemsCount / 2;
        if (itemsCount % 2 == 1)
        {
            for (int index = 0; index < itemsCount; index++)
            {
                xOffsets.Add(offSet * (index - mid));
            }
        }
        else
        {
            for (int index = 0; index < itemsCount; index++)
            {
                xOffsets.Add(offSet * (index - mid + 0.5f));
            }
        }

        return xOffsets;
    }
}
