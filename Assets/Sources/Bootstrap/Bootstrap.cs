using Assets.Sources.Common.Factory;
using Sources.GameBuilder;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private readonly Factory<GameBuilder> _gameBuilderFactory = new Factory<GameBuilder>();

    private void Awake()
    {
        GameBuilder gameBuilder = FindObjectOfType<GameBuilder>() ?? _gameBuilderFactory.Create();

        gameBuilder.OnSceneLoaded();
    }
}