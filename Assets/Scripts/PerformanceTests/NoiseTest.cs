using UnityEngine;
using DRE.Noise;

public class NoiseTest : MonoBehaviour
{
    private string report = null;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) {
            Noise2DTest();
        }
    }


    void Noise2DTest()
    {
        INoise noise = new SimplexNoise();

        double hMax = double.MinValue;
        double hMin = double.MaxValue;

        for (float y = 0; y < 1000; y++) {
            for (float x = 0; x < 1000; x++) {
                double h = noise.GetValue(x / 5.7f, y * 4.3f); // Get height
                if (h < hMin) {
                    hMin = h;
                }
                if (h > hMax) {
                    hMax = h;
                }
            }
        }
        report = "Noise2DTest: Height range = < " + hMin + "  " + hMax + " >";
    }


    void OnGUI()
    {
        if (report != null) {
            GUI.TextArea(new Rect(0, 200, Screen.width, 100), report);
        } else {
            GUI.TextArea(new Rect(0, 200, Screen.width, 100), "Press N to start the Noise test");
        }
    }
}
