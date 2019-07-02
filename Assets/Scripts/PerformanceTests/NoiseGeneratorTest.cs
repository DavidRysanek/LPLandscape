using UnityEngine;
using DRE.Noise;

public class NoiseGeneratorTest : MonoBehaviour
{
    private string report = null;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) {
            NoiseGenerator2DTest();
        }
    }


    void NoiseGenerator2DTest()
    {
        INoise noise = new SimplexNoise();
        LinearSimplexNoiseGenerator noiseGenerator = new LinearSimplexNoiseGenerator(noise);
        noiseGenerator.octaves = 6;

        double hMax = double.MinValue;
        double hMin = double.MaxValue;

        for (float y = 0; y < 1000; y++) {
            for (float x = 0; x < 1000; x++) {
                double h = noiseGenerator.GetValue(x / 5.7f, y * 4.3f); // Get height
                if (h < hMin) {
                    hMin = h;
                }
                if (h > hMax) {
                    hMax = h;
                }
            }
        }
        report = "NoiseGenerator2DTest: Height range = < " + hMin + "  " + hMax + " >";
    }


    void OnGUI()
    {
        if (report != null) {
            GUI.TextArea(new Rect(0, 300, Screen.width, 100), report);
        } else {
            GUI.TextArea(new Rect(0, 300, Screen.width, 100), "Press G to start the NoiseGenerator test");
        }
    }
}
