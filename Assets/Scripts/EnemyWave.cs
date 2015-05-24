using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class EnemyWave
{
    public List<Enemy> Enemies;
    public float WaveTimeBefore;
    public float WaveTimeSpawning;
    public float WaveTimeAfter;

    public float GetWaveTimeSingleEnemy()
    { 
        if (Enemies.Count>0)
            return WaveTimeSpawning/Enemies.Count;

        return 0;
    }
}
