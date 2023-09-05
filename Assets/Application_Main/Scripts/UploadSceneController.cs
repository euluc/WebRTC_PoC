using System.Collections;
using UnityEngine;
using AnotherFileBrowser.Windows;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UploadSceneController : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [SerializeField] protected TMP_InputField pathToFileInputField;
    [SerializeField] protected float timeBetweenUploads;
    [SerializeField] protected GameObject startButtonGO, stopButtonGO;
    [SerializeField] protected ScrollRect consoleScrollRect;

    #endregion

    #endregion

    #region Methods

    #region Protected Methods

    protected void Start()
    {
        Setup();
    }

    protected void Setup()
    {
        SetupButtons();
    }
    protected void SetupButtons()
    {
        startButtonGO.SetActive(true);
        stopButtonGO.SetActive(false);
    }
    
    protected IEnumerator UploadFile()
    {
        while (true)
        {
            using var receive = UnityWebRequest.Get(pathToFileInputField.text);
            yield return receive.SendWebRequest();
            var send = UnityWebRequest.Put("lucasmartinmacedo.com", receive.downloadHandler.data);
            send.certificateHandler = new CertificateWhore();
            yield return send.SendWebRequest();
            
            if (send.result == UnityWebRequest.Result.Success)
                Console.Log("File uploaded successfully!", LogType.Message, consoleScrollRect);
            else
                Console.Log(send.error, LogType.Error, consoleScrollRect);
            
            yield return new WaitForSeconds(timeBetweenUploads);
        }
    }

    #endregion
    
    #region Public Methods

    public void OnStartButtonPressed()
    {
        if (pathToFileInputField.text == string.Empty)
        {
            Console.Log("Path to file is empty!", LogType.Error, consoleScrollRect);
            return;
        }
        
        stopButtonGO.SetActive(true);
        startButtonGO.SetActive(false);
        StartCoroutine(UploadFile());
    }
    public void OnStopButtonPressed()
    {
        StopAllCoroutines();
        startButtonGO.SetActive(true);
        stopButtonGO.SetActive(false);
        pathToFileInputField.text = string.Empty;
    }
    public void OnOpenFileExplorerButtonPressed()
    {
        new FileBrowser().OpenFileBrowser(new BrowserProperties(), path =>
        {
            pathToFileInputField.text = path;
        });
    }
    public void OnCloseButtonPressed()
    {
        Application.Quit();
    }

    #endregion

    #endregion
}

public class CertificateWhore : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}