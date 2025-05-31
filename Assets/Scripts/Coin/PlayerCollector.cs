using System;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public event Action<float> CoinCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            CoinCollected?.Invoke(coin.Value);
        }
    }
}