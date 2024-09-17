using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDatPersistence 
{
    void LoadData(GameData data);

    void SaveData( GameData data);
}
