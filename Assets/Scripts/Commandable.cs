using UnityEngine;
using System.Collections;

public interface Commandable {

    void move(Vector3 _position);
    void fetch(Fetchable fObj);

}
