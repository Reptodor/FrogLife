using UnityEngine;

public class SpawnpointGenerator
{
    private Vector2 _minPositionCoordinate;
    private Vector2 _maxPositionCoordinate;

    public SpawnpointGenerator(Vector2 minPositionCoordinate, Vector2 maxPositionCoordinate)
    {
        _minPositionCoordinate = minPositionCoordinate;
        _maxPositionCoordinate = maxPositionCoordinate;
    }

    public Vector2 GetRandomSpawnpoint()
    {
        Vector2 spawnpoint = new Vector2(GetRandomHorizontalCoordinate(), GetRandomVerticalCoordinate());

        return spawnpoint;
    }

    private float GetRandomHorizontalCoordinate()
    {
        float horizontalCoordinate = Random.Range(_minPositionCoordinate.x, _maxPositionCoordinate.x);

        return horizontalCoordinate;
    }

    private float GetRandomVerticalCoordinate()
    {
        float verticalCoordinate = Random.Range(_minPositionCoordinate.y, _maxPositionCoordinate.y);

        return verticalCoordinate;
    }
}
