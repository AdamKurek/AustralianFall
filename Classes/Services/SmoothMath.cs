using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Classes.Services
{
    internal class DONtUseit
    {
        private static void exampleRun()
        {
            const float minValue = -25f;
            const float maxValue = 25f;
            const float duration = 10f;
            // const float frequency = 1f;//1f goes from min trough max to min
            const float frequency = 0.5f;//0.5 goes from min to max
            float currentTime = 0f;

            while (currentTime <= duration)
            {
                float t = currentTime / duration;
                float value = Mathff.Lerp(minValue, maxValue, Mathff.SmoothStep(0, 1, MathF.Sin(t * MathF.PI * frequency)));

                Console.WriteLine($"Time: {currentTime}, Value: {value}");

                currentTime++;
            }
        }
    }

    public static class Mathff
    {
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        public static float SmoothStep(float edge0, float edge1, float x)
        {
            x = Clamp01((x - edge0) / (edge1 - edge0));
            return x * x * (3 - 2 * x);
        }

        public static float Clamp01(float value)
        {
            return MathF.Max(0f, MathF.Min(1f, value));
        }
    }

}
