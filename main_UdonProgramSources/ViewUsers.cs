using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


public class ViewUsers : UdonSharpBehaviour
{
    [Header("表示するテキスト")]
    public Text m_text;

    [Header("ユーザの名前を表記するタイトル")]
    VRCPlayerApi[] players = new VRCPlayerApi[20];
    int _count = 0;

    [Header("[Option] Join音")]
    public AudioSource m_audioSource;


    void Start()
    {
        _count = VRCPlayerApi.GetPlayerCount();
        VRCPlayerApi.GetPlayers(players);
        foreach(VRCPlayerApi player in players)
        {
            m_text.text = "";
            if (player == null) continue;
            m_text.text += player.displayName;
            m_text.text += "\n";
        }
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        _count = VRCPlayerApi.GetPlayerCount();
        VRCPlayerApi.GetPlayers(players);
        foreach (VRCPlayerApi player_joined in players)
        {
            if (player_joined == null) continue;
            m_text.text = "";
            m_text.text += player_joined.displayName;
            m_text.text += "\n";
        }
        if (m_audioSource != null && m_audioSource.isPlaying)
        {
            m_audioSource.Play();
        }
    }

    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        _count = VRCPlayerApi.GetPlayerCount();
        VRCPlayerApi.GetPlayers(players);
        foreach (VRCPlayerApi player_left in players)
        {
            if (player_left == null) continue;
            m_text.text = "";
            m_text.text += player_left.displayName;
            m_text.text += "\n";
        }
    }

}
