using System.Collections;
using UnityEngine;

public class SlotMachineController : MonoBehaviour
{
    public ReelSpin reel1;
    public ReelSpin reel2;
    public ReelSpin reel3;

    public GameObject winPopup;

    public Sprite[] symbolSprites;


    public void Spin()
    {
        winPopup.SetActive(false);

        AudioManager.instance.PlaySpin();

        bool forceWin = Random.value <= 0.25f;

        if (forceWin)
        {
            Sprite forced =
                symbolSprites[Random.Range(0, symbolSprites.Length)];

            reel1.SetForcedSprite(forced);
            reel2.SetForcedSprite(forced);
            reel3.SetForcedSprite(forced);
        }
        else
        {
            reel1.SetForcedSprite(null);
            reel2.SetForcedSprite(null);
            reel3.SetForcedSprite(null);
        }

        reel1.StartSpin();

        Invoke(nameof(SpinReel2), 0.3f);
        Invoke(nameof(SpinReel3), 0.6f);

        StartCoroutine(CheckWinAfterSpin());
    }


    void SpinReel2()
    {
        reel2.StartSpin();
    }


    void SpinReel3()
    {
        reel3.StartSpin();
    }


    IEnumerator CheckWinAfterSpin()
    {
        yield return new WaitForSeconds(reel1.spinTime + 1f);

        CheckWin();
    }


    void CheckWin()
    {
        AudioManager.instance.StopSpin();

        string s1 = reel1.GetMiddleSymbol();
        string s2 = reel2.GetMiddleSymbol();
        string s3 = reel3.GetMiddleSymbol();

        Debug.Log("RESULT: " + s1 + " | " + s2 + " | " + s3);

        if (s1 == s2 && s2 == s3)
        {
            winPopup.SetActive(true);

            AudioManager.instance.PlayWin();
        }
    }
}