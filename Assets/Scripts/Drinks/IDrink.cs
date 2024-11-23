using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDrink 
{
    string DrinkName { get; }
    string FlavorText { get; }

    float Mind { get; }
    float Body { get; }
    float Soul { get; }
}
