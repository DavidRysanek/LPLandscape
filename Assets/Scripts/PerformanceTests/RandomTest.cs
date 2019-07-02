using UnityEngine;
using System;
using DRE.Mathematics;


public class RandomTest : MonoBehaviour {

    private string report = null;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SpeedTest();
        }
    }


    void OnGUI()
    {
        if (report != null) {
            GUI.TextArea(new Rect(0, 400, Screen.width, 100), report);
        } else {
            GUI.TextArea(new Rect(0, 400, Screen.width, 100), "Press R to start the Random test");
        }
    }

    // 10 000 000 iterations
    // DEBUG
    // Unity.Random float = 280ms
    // Unity.Random int =   280ms
    // Unity.Random ulong = 420ms
    // Xor.Float = 478ms
    // Xor.Int =   680ms
    // Xor.ULong = 510ms

    // RELEASE
    // Unity.Random float = 130s
    // Unity.Random int =   130ms
    // Unity.Random ulong = 250ms
    // Xor.Float = 110ms
    // Xor.Int =   155ms
    // Xor.ULong = 144ms
    void SpeedTest()
    {
        const int iterations = 10000000;
        IRandom r = new XorShift128PlusRandom();
        var stopwatch = new System.Diagnostics.Stopwatch();


        ulong unityLong = 0;
        stopwatch.Reset();
        stopwatch.Start();
        for (var i = 0; i < iterations; ++i)
        {
            unityLong = (ulong)(UnityEngine.Random.value);
        }
        var unityLongTime = stopwatch.ElapsedMilliseconds;

        float unityInt = 0;
        stopwatch.Reset();
        stopwatch.Start();
        for (var i = 0; i < iterations; ++i)
        {
            unityInt = (int)(UnityEngine.Random.value);
        }
        var unityIntTime = stopwatch.ElapsedMilliseconds;

        float unityFloat = 0;
        stopwatch.Reset();
        stopwatch.Start();
        for (var i = 0; i < iterations; ++i)
        {
            unityFloat = UnityEngine.Random.value;
        }
        var unityFloatTime = stopwatch.ElapsedMilliseconds;


        ulong dreLong = 0;
        stopwatch.Reset();
        stopwatch.Start();
        for (var i = 0; i < iterations; ++i)
        {
            dreLong = r.NextULong();
        }
        var dreLongTime = stopwatch.ElapsedMilliseconds;

        int dreInt = 0;
        stopwatch.Reset();
        stopwatch.Start();
        for (var i = 0; i < iterations; ++i)
        {
            dreInt = r.NextInt();
        }
        var intTime = stopwatch.ElapsedMilliseconds;

        float dreFloat = 0;
        stopwatch.Reset();
        stopwatch.Start();
        for (var i = 0; i < iterations; ++i)
        {
            dreFloat = r.NextFloat();
        }
        var dreFloatTime = stopwatch.ElapsedMilliseconds;

        float v = 0;
        v = (float)dreLong; // Dismiss warning
        v = (float)dreInt; // Dismiss warning
        v = (float)dreFloat; // Dismiss warning
        unityFloat = v;

        report = "Random - " + iterations + " iterations \n"
            + "Test   Unity,      XorShift128Plus \n"
            + "float   " + unityFloatTime + " ms,   " + dreFloatTime + " ms\n"
            + "int     " + unityIntTime + " ms,   " + intTime + " ms\n"
            + "ulong   " + unityLongTime + " ms,   " + dreLongTime + " ms";
    }


	void AbsTest()
	{
		check(long.MinValue, long.MaxValue, ulong.MaxValue);
		check(0,0,0);
		check(0,1,1);
		check(0,-1,1);
		check(0,10,10);
		check(3,5,2);
		check(5,3,2);
		check(-3,5,8);
		check(5,-3,8);
		check(-3,-5,2);
		check(-5,-3,2);
		check(3,-5,8);
		check(long.MinValue,0,(ulong)long.MaxValue + 1);
		check(long.MinValue,-1,(ulong)long.MaxValue);
		check(long.MinValue,1,(ulong)long.MaxValue + 2);
	}


	void check(long lowerBound, long upperBound, ulong abs)
	{
		ulong d = AbsLongs(lowerBound, upperBound);
		if (abs == d) {
			Debug.Log(lowerBound + " to " + upperBound + " = " + d);
		} else {
			Debug.LogError(lowerBound + " to " + upperBound + " = " + d + "should be " + abs);
		}
	}

	public ulong AbsLongs(long lowerBound, long upperBound)
	{
		//		if (upperBound > lowerBound) {
		//			return (ulong)(upperBound - lowerBound);
		//		} else {
		//			return (ulong)(lowerBound - upperBound);
		//		}
		long maxValue = (upperBound < lowerBound) ? lowerBound : upperBound;
		long minValue = (upperBound > lowerBound) ? lowerBound : upperBound;
		return (ulong)(maxValue - minValue);
	}

	public ulong AbsLongs1(long lowerBound, long upperBound)
	{
		if (lowerBound == upperBound) {
			return 0;
		}

		long maxValue = (upperBound < lowerBound) ? lowerBound : upperBound;
		long minValue = (upperBound > lowerBound) ? lowerBound : upperBound;

		ulong minValueAddition = 0;
		if (minValue == long.MinValue) {
			minValue += 1;
			minValueAddition = 1;
		}

		ulong absMaxValue = (ulong)Math.Abs(maxValue);
		ulong absMinValue = (ulong)Math.Abs(minValue) + minValueAddition;

		ulong range = 0;
		if (0 <= minValue && minValue <= maxValue) {
			// Both positive
			range = absMaxValue - absMinValue;
		} else if (minValue <= maxValue && maxValue <= 0) {
			// Both negative
			range = absMinValue - absMaxValue;
		} else {
			range = absMinValue + absMaxValue;
		}

		return range;
	}

	ulong AbsDistanceBetweenLongs(long lowerBound, long upperBound)
	{
		if (lowerBound == upperBound) {
			return 0;
		}

		long maxValue = (upperBound < lowerBound) ? lowerBound : upperBound;
		long minValue = (upperBound > lowerBound) ? lowerBound : upperBound;
		ulong minValueAddition = 0;
		if (minValue == long.MinValue) {
			minValue += 1;
			minValueAddition = 1;
		}

		ulong absMaxValue = (ulong)Math.Abs(maxValue);
		ulong absMinValue = (ulong)Math.Abs(minValue) + minValueAddition;

		ulong range = 0;
		if (0 <= minValue && minValue <= maxValue) {
			// Both positive
			range = absMaxValue - absMinValue;
		} else if (minValue <= maxValue && maxValue <= 0) {
			// Both negative
			range = absMinValue - absMaxValue;
		} else if (minValue <= 0 && 0 <= maxValue) {
			range = absMinValue + absMaxValue;
		} else if (maxValue <= 0 && 0 <= minValue) {
			range = absMinValue + absMaxValue;
		} else {
			range = 1234;
		}

		return range;
	}



	void RandomTest1()
	{
		//		DRE.Random.XorShift128Random rng = new DRE.Random.XorShift128Random(1);
		//		for (int i = 0; i < 100; i++) {
		//			Debug.Log(rng.NextUInt());
		//			Debug.Log(rng.Next(255));
		//			Debug.Log(rng.NextFloat());
		//			Debug.Log(rng.NextInt(8));
		//			Debug.Log(rng.NextInt(4, 8));
		//		}


		//		for (int i = 0; i < 1000; i++) {
		//			long v = (long)(ulong.MaxValue % (ulong)(long.MaxValue - i));
		//			Debug.Log(v);
		//		}


		IRandom r = new XorShift128PlusRandom();

		r.NextLong(-1, long.MaxValue);

		//		long r0 = long.MaxValue;
		//		long r1 = -1;
		//		long r2 = -10;
		//		long r3 = long.MinValue;
		//		ulong range1 = (ulong)Math.Abs((long)(long.MaxValue) - (long)(r1));
		//		ulong range2 = (ulong)Math.Abs((long)(long.MaxValue) - (long)(r2));
		//		ulong range3 = (ulong)Math.Abs((long)(long.MaxValue) - (long)(r3));



//		long a = 0;
//		a = r.NextLong(-5,5);
//		a = r.NextLong(5,-5);
//		a = r.NextLong(5,2);
//		a = r.NextLong(5,-2);
//		a = r.NextLong(-5,2);

		int x0 = 0, x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0;
		long lowerBound = -2;
		long upperBound = 3;
		for (int i = 0; i < 1000; i++) {
			//			ulong v = r.NextULong(lowerBound, upperBound);
			long v = r.NextLong(lowerBound, upperBound);
			Debug.Log(v);
			if (v == lowerBound) {
				x0++;
			} else if (v == lowerBound + 1) {
				x1++;
			} else if (v == lowerBound + 2) {
				x2++;
			} else if (v == lowerBound + 3) {
				x3++;
			} else if (v == lowerBound + 4) {
				x4++;
			} else {
				x5++;
			}
		}

		Debug.Log("x: " + x0 + "   " + x1 + "   " + x2 + "   " + x3 + "   " + x4 + "   " + x5);
	}


	void RandomTest2()
	{
		IRandom r = new XorShift128PlusRandom();

		for (int i = 0; i < 100; i++) {
			Debug.Log(r.NextBool());
		}
	}

	void BytesTest()
	{
		IRandom r = new XorShift128PlusRandom();

		byte[] b = new byte[] {0,0,0,0,0};
		for (int i = 0; i < 100; i++) {
			r.NextBytes(b);
			Debug.Log(b.ToString());
		}
	}



	void NumbersTest()
	{
		//		float f = 1f;
		//		for (int i = 0; i < 200; i++) {
		//			f = f * 0.5f;
		//			float ff = 1f - f;
		//			string s = ff.ToString(".0##############################################################################################################");
		//			Debug.Log(i + " : " + s);
		//		}
		//

		double d = 1;
		for (int i = 0; i < 500; i++) {
			d *= 0.5;
			double dd = 0.1 + d;
			string s = dd.ToString(".0##########################################################################################################################################");
			Debug.Log(i + " : " + s);
		}
	}
}
