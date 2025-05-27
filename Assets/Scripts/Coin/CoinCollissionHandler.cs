using UnityEngine;

public class CoinCollissionHandler : MonoBehaviour
{
    private Coin _coin;

    public void Init(Coin coin)
    {
        _coin = coin;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
        {
            player.CollectCoin(_coin.Value);
            gameObject.SetActive(false);
            _coin.GetCollected();
        }
    }
}