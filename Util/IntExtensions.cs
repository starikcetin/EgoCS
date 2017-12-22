using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntExtensions
{
    public static int Factorial( this int i )
    {
        var result = 1;
        i = Mathf.Max( 0, i );
        for( int f = i; f > 1; f-- )
        {
            result *= f;
        }
        return result;
    }
}
