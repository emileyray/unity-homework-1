using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject platformPiece;
    public GameObject lastPlatformPiece;
    public GameObject coin;
    public PlayerMovement player;
    private int level;
    private Vector3 _initScale = Vector3.zero;


    void Awake()
    {
        level = Random.Range(5, 15);
        int _prevDirection = 1;
        Vector3 _prevPosition = Vector3.zero;
        Vector3 _prevScale = new Vector3(Random.Range(3, 8), 0.5f, 1);

        for (int i = 0; i < level; i++)
        {
            GameObject _nextPlatformPiece;
            if (i == level - 1)
            {
                _nextPlatformPiece = lastPlatformPiece;
            } else
            {
                _nextPlatformPiece = platformPiece;
            }

            var _nextScale = _nextPlatformPiece.transform.localScale;
            _nextScale.x = Random.Range(3, 8);
            Vector3 _nextPosition = _prevPosition;

            if (i == 0) {
                _nextPosition = _prevPosition;
                _initScale = _nextScale;
            }
            else
            {
                if (_prevDirection == 0){
                    _nextPosition.z = _prevPosition.z + _prevScale.x / 2 - _nextScale.z / 2;
                    _nextPosition.x = _prevPosition.x + _prevScale.z / 2 + _nextScale.x / 2;
                } else
                {
                    _nextPosition.x = _prevPosition.x + _prevScale.x / 2 - _nextScale.z / 2;
                    _nextPosition.z = _prevPosition.z + _prevScale.z / 2 + _nextScale.x / 2;
                }
            }

            _nextPlatformPiece.transform.localScale = _nextScale;
            _nextPlatformPiece.transform.position = _nextPosition;
            _nextPlatformPiece.transform.rotation = Quaternion.Euler(0, 90 * _prevDirection, 0);

            _prevScale = _nextScale;
            _prevPosition = _nextPosition;
            _prevDirection = _prevDirection == 0 ? 1 : 0;

            if (i == level - 1 && _prevDirection == 1)
            {
                _nextPlatformPiece.transform.rotation = Quaternion.Euler(
                    _nextPlatformPiece.transform.rotation.eulerAngles.x,
                    _nextPlatformPiece.transform.rotation.eulerAngles.y + 180,
                    _nextPlatformPiece.transform.rotation.eulerAngles.z
                );
            }

            Instantiate(_nextPlatformPiece);

            GameObject _nextCoin = coin;
            Vector3 _nextCoinPosition = _nextPosition;
            _nextCoinPosition.y += 
                _nextScale.y/2 + 
                _nextCoin.transform.localScale.y;
            coin.transform.position = _nextCoinPosition;

            Instantiate(_nextCoin);
        }

        player.transform.position = new Vector3(0, 1.5f, -_initScale.x/2 + player.transform.localScale.x/2);

    }
}
