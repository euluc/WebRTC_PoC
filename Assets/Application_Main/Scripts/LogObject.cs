using TMPro;
using UnityEngine;

public class LogObject : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [SerializeField] protected TextMeshProUGUI messageTMP;

    #endregion

    #endregion

    #region Methods

    #region Public Methods

    public void SetupAsError(string message)
    {
        messageTMP.text = $"$ {message}";
        messageTMP.color = Color.red;
    }
    public void SetupAsWarning(string message)
    {
        messageTMP.text = $"$ {message}";
        messageTMP.color = Color.yellow;
    }
    public void SetupAsMessage(string message)
    {
        messageTMP.text = $"$ {message}";
        messageTMP.color = Color.white;
    }

    #endregion

    #endregion
}