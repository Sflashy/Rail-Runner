using System;
using Unity.Mathematics;
using UnityEngine;

public class Cutter : MonoBehaviour
{

    public GameObject piecePrefab;
    public AudioSource cutSound;
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.IsGameOver) return;

        if (other.CompareTag("Player"))
        {
            GameManager.Instance.IsGameOver = true;
            LevelManager.Instance.ChangeState(LevelManager.State.Failed);
            AnimationManager.Instance.ChangeState(AnimationManager.State.Failed);
            GameManager.Instance.ReleaseObjects();
            return;
        }
        
        
        if (!other.CompareTag("Bar")) return;
        cutSound.Play();
        Slice(other.gameObject);
    }
    
    private void Slice(GameObject bar)
    {
        var barScale = bar.transform.lossyScale;
        var barPos = bar.transform.position;
        var barBottom = bar.transform.Find("Bottom");
        var cutPointPos = transform.position;
       
        //var playerPos = bar.transform.parent.position;
        var cutLength = 0f;
        
        switch (transform.localPosition.x)
        {
            case < 0:
                CutLeftSide();
                break;
            case > 0:
                CutRightSide();
                break;
            default:
                CutVertical();
                break;
        }
        
        void CutLeftSide()
        {
            cutLength = (barScale.y - barPos.x - Mathf.Abs(cutPointPos.x)) / 2;
            bar.transform.localScale = new Vector3(barScale.x, barScale.y - cutLength, barScale.z);
            bar.transform.position = new Vector3(barPos.x + cutLength, barPos.y, barPos.z);
            InstantiatePiece(new Vector3(-((barScale.y - barPos.x) - cutLength), barPos.y, barPos.z));
        }

        void CutRightSide()
        {
            cutLength = ((barScale.y + barPos.x) - Mathf.Abs(cutPointPos.x)) / 2;
            bar.transform.localScale = new Vector3(barScale.x, barScale.y - cutLength, barScale.z);
            bar.transform.position = new Vector3(barPos.x - cutLength, barPos.y, barPos.z);
            InstantiatePiece(new Vector3(barScale.y + barPos.x, barPos.y, barPos.z));
        }

        void CutVertical()
        {
            cutLength = (cutPointPos.y - barBottom.position.y) / 2;
            if (bar.transform.localScale.y < cutLength) return;
            bar.transform.localScale = new Vector3(barScale.x, barScale.y - cutLength, barScale.z);
            bar.transform.position = new Vector3(barPos.x, barPos.y + cutLength, barPos.z);
            InstantiatePiece(new Vector3(barPos.x, barBottom.position.y - cutLength, barPos.z));
        }
        
        void InstantiatePiece(Vector3 spawnPosition)
        {
            var piece = Instantiate(piecePrefab).transform;
            piece.localScale = new Vector3(barScale.x, cutLength, barScale.z);
            piece.position = spawnPosition;
            piece.rotation = bar.transform.rotation;
            piece.parent = transform.parent;

        }
    }
}
