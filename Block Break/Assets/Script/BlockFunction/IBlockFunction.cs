using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockFunction
{
    public void ItStart();
    public void ItUpdate();
    public void ItCollisionEnter(Collision collision);

}
