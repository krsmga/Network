# Network
This class provides resources for implementing an interface that shows the device's battery level and status.
For Android or iOS devices.

## Script settings in Inspector
<img src="../master/Example.png">

## Steps for use
1. Attach the **Network.cs** script to any **GameObject** in the Scene.

2. **Carrier Data:** Attach a GameObject that contains the mobile network image via data carrier.

3. **Local Area:** Attach a GameObject that contains the Wi-Fi lan image.

**Note:** **Carrier Data:** or **Local Area:**, you can use one or the other or both. It is optional.

4. **No Connection:** Attach a GameObject that contains the image it shows without internet connectivity. 

**Note:** Is optional. If you use it it will show an image (icon) without connectivity. If not defined, it will not show any image.
