using UnityEngine;

public class SmallBar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.Instance.IsGameOver) return;
        
        if (!other.CompareTag("Bar")) return;
        IncreaseBarSize(other.transform);
        SoundManager.Play(SoundManager.Instance.collectSound);
        Destroy(gameObject);
    }

    private void IncreaseBarSize(Transform bar)
    {
        var barScale = bar.transform.lossyScale;
        var pieceScale = transform.lossyScale;
        var newSize = new Vector3(barScale.x, barScale.y + pieceScale.y, barScale.z);
        bar.localScale = newSize;
        
        // decrease the player position by piece length 
        var isVertical = bar.gameObject.GetComponent<Bar>().isVertical;
        if (!isVertical) return;
        var playerBody = bar.transform.parent.Find("PlayerBody");
        playerBody.position -= new Vector3(0, pieceScale.y, 0);
    }
}
