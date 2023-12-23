using UnityEngine;

public class Credit : MonoBehaviour
{
    public string wreckzURl, AbURL, WibiURL, webnURL, EwokURL;

    public void WreckzOpen()
    {
        Application.OpenURL(wreckzURl);
    }

    public void AbscratyOpen()
    {
        Application.OpenURL(AbURL);
    }

    public void WiBiOpen()
    {
        Application.OpenURL(WibiURL);
    }

    public void WebnOpen()
    {
        Application.OpenURL(webnURL);
    }

    public void EwokOpen()
    {
        Application.OpenURL(EwokURL);
    }
}