/**
 * @author Kleber Ribeiro da Silva
 * @email krsmga@gmail.com
 * @create date 2020-06-10 19:36:50
 * @modify date 2020-06-19 10:37:24
 * @desc This class allows you to create an interface that shows the status of the internet connection.
 * @github https://github.com/krsmga/Network
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class allows you to create an interface that shows the status of the internet connection.
/// </summary>
/// <remarks>
/// <param name="carrierData">Attach a GameObject that contains the mobile network image via data carrier.</param>
/// <param name="localArea">Attach a GameObject that contains the Wi-Fi lan image.</param>
/// <param name="noConnection">Attach a GameObject that contains the image it shows without internet connectivity.</param>
///
/// 'carrierData' or 'localArea', you can use one or the other or both. It is optional.
/// 'noConnection' is optional. If you use it it will show an image (icon) without connectivity. If not defined, it will not show any image.
/// </remarks>
public class Network : MonoBehaviour
{
    [SerializeField] private GameObject carrierData = default;
    [SerializeField] private GameObject localArea = default;
    [SerializeField] private GameObject noConnection = default;

    /// <summary>
    /// Returns true or false for the internet connection.
    /// </summary>
    /// <returns>
    /// (bool) -> true is connected
    /// </returns>
    public bool Connected
    {
        get
        {
            return ((Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork) ||
                    (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork));
        }
    }

    void Start()
    {
        // Repeater starts only if any of the objects is defined. 
        // It serves to allow the class to call through others to get only 'Connected' without activating the repeater.
        if (carrierData != null || localArea != null)
        {
            InvokeRepeating("NetworkIconUpdate", 0f, 1f);
        }
        
    }

    private void NetworkIconUpdate()
    {
        NoConnectionIcon(!Connected);

        if (carrierData != null)
        {
            if (Connected)
            {
                carrierData.SetActive(Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork);
            }
            else
            {
                carrierData.SetActive(false);
            }
        }

        if (localArea != null)
        {
            if (Connected)
            {
                localArea.SetActive(Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork);
            }
            else
            {
                localArea.SetActive(false);
            }
        }
    }

    private void NoConnectionIcon(bool value)
    {
        if (noConnection != null)
        {
            noConnection.SetActive(value);
        }

        if (carrierData != null)
        {
            carrierData.SetActive(!value);
        }

        if (localArea != null)
        {
            localArea.SetActive(!value);
        }
    }
}