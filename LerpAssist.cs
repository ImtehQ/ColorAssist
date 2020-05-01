using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RealisticPhysics
{
    public enum LerpAssistList
    {
        linear,
        quadIn,
        quadOut,
        quadInOut,
        cubicIn,
        cubicOut,
        cubicInOut,
        quartIn,
        quartOut,
        quartInOut,
        quintIn,
        quintOut,
        quintInOut,
        sineIn,
        sineOut,
        sineInOut,
        expoIn,
        expoOut,
        expoInOut,
        circIn,
        circOut,
        circInOut,
        backIn,
        backOut,
        backInOut,
        elasticIn,
        elasticOut,
        elasticInOut,
        bounceIn,
        bounceOut,
        bounceInOut
    }

    public static class LerpAssist
    {
        public static Quaternion ToCorrectedQuaternion(Quaternion original_start, Quaternion original_end, float time)
        {
            return new Quaternion(
                LerpCorrected(original_start.x, original_end.x, time),
                LerpCorrected(original_start.y, original_end.y, time),
                LerpCorrected(original_start.z, original_end.z, time),
                LerpCorrected(original_start.w, original_end.w, time));
        }
        public static Vector3 ToCorrectedVector3(Vector3 original_start, Vector3 original_end, float time)
        {
            return new Vector3(
                LerpCorrected(original_start.x, original_end.x, time),
                LerpCorrected(original_start.y, original_end.y, time),
                LerpCorrected(original_start.z, original_end.z, time));
        }

        public static float LerpCorrected(float b, float e, float v)
        {
            return ((e - b) * v) + b;
        }

        public static float Linear(float _normalized)
        {
            return _normalized;
        }

        public static float QuadIn(float _normalized)
        {
            return _normalized * _normalized;
        }

        public static float QuadOut(float _normalized)
        {
            return _normalized * (2 - _normalized);
        }

        public static float QuadInOut(float _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return 0.5f * _normalized * _normalized;
            }

            return -0.5f * (--_normalized * (_normalized - 2) - 1);
        }

        public static float CubicIn(float _normalized)
        {
            return _normalized * _normalized * _normalized;
        }

        public static float CubicOut(float _normalized)
        {
            return --_normalized * _normalized * _normalized + 1;
        }

        public static float CubicInOut(float _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return 0.5f * _normalized * _normalized * _normalized;
            }

            return 0.5f * ((_normalized -= 2) * _normalized * _normalized + 2);
        }

        public static float QuartIn(float _normalized)
        {
            return _normalized * _normalized * _normalized * _normalized;
        }

        public static float QuartOut(float _normalized)
        {
            return 1 - (--_normalized * _normalized * _normalized * _normalized);
        }

        public static float QuartInOut(float _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return 0.5f * _normalized * _normalized * _normalized * _normalized;
            }

            return -0.5f * ((_normalized -= 2) * _normalized * _normalized * _normalized - 2);
        }

        public static float QuintIn(float _normalized)
        {
            return _normalized * _normalized * _normalized * _normalized * _normalized;
        }

        public static float QuintOut(float _normalized)
        {
            return --_normalized * _normalized * _normalized * _normalized * _normalized + 1;
        }

        public static float QuintInOut(float _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return 0.5f * _normalized * _normalized * _normalized * _normalized * _normalized;
            }

            return 0.5f * ((_normalized -= 2) * _normalized * _normalized * _normalized * _normalized + 2);
        }

        public static float SineIn(float _normalized)
        {
            return 1 - Mathf.Cos(_normalized * Mathf.PI / 2);
        }

        public static float SineOut(float _normalized)
        {
            return Mathf.Sin(_normalized * Mathf.PI / 2);
        }

        public static float SineInOut(float _normalized)
        {
            return 0.5f * (1 - Mathf.Cos(Mathf.PI * _normalized));
        }

        public static float ExpoIn(float _normalized)
        {
            return _normalized == 0 ? 0 : Mathf.Pow(1024, _normalized - 1);
        }

        public static float ExpoOut(float _normalized)
        {
            return _normalized == 1 ? 1 : 1 - Mathf.Pow(2, -10 * _normalized);
        }

        public static float ExpoInOut(float _normalized)
        {
            if (_normalized == 0)
            {
                return 0;
            }

            if (_normalized == 1)
            {
                return 1;
            }

            if ((_normalized *= 2) < 1)
            {
                return 0.5f * Mathf.Pow(1024, _normalized - 1);
            }

            return 0.5f * (-Mathf.Pow(2, -10 * (_normalized - 1)) + 2);
        }

        public static float CircIn(float _normalized)
        {
            return 1 - Mathf.Sqrt(1 - _normalized * _normalized);
        }

        public static float CircOut(float _normalized)
        {
            return Mathf.Sqrt(1 - (--_normalized * _normalized));
        }

        public static float CircInOut(float _normalized)
        {
            if ((_normalized *= 2) < 1)
            {
                return -0.5f * (Mathf.Sqrt(1 - _normalized * _normalized) - 1);
            }

            return 0.5f * (Mathf.Sqrt(1 - (_normalized -= 2) * _normalized) + 1);
        }

        public static float BackIn(float _normalized)
        {
            var s = 1.70158f;

            return _normalized * _normalized * ((s + 1) * _normalized - s);
        }

        public static float BackOut(float _normalized)
        {
            var s = 1.70158f;

            return --_normalized * _normalized * ((s + 1) * _normalized + s) + 1;
        }

        public static float BackInOut(float _normalized)
        {
            var s = 1.70158f * 1.525f;

            if ((_normalized *= 2) < 1)
            {
                return 0.5f * (_normalized * _normalized * ((s + 1) * _normalized - s));
            }

            return 0.5f * ((_normalized -= 2) * _normalized * ((s + 1) * _normalized + s) + 2);
        }

        public static float ElasticIn(float _normalized)
        {
            if (_normalized == 0)
            {
                return 0;
            }

            if (_normalized == 1)
            {
                return 1;
            }

            return -Mathf.Pow(2, 10 * (_normalized - 1)) * Mathf.Sin((_normalized - 1.1f) * 5 * Mathf.PI);
        }

        public static float ElasticOut(float _normalized)
        {
            if (_normalized == 0)
            {
                return 0;
            }

            if (_normalized == 1)
            {
                return 1;
            }

            return Mathf.Pow(2, -10 * _normalized) * Mathf.Sin((_normalized - 0.1f) * 5 * Mathf.PI) + 1;
        }

        public static float ElasticInOut(float _normalized)
        {
            if (_normalized == 0)
            {
                return 0;
            }

            if (_normalized == 1)
            {
                return 1;
            }

            _normalized *= 2;

            if (_normalized < 1)
            {
                return -0.5f * Mathf.Pow(2, 10 * (_normalized - 1)) * Mathf.Sin((_normalized - 1.1f) * 5 * Mathf.PI);
            }

            return 0.5f * Mathf.Pow(2, -10 * (_normalized - 1)) * Mathf.Sin((_normalized - 1.1f) * 5 * Mathf.PI) + 1;
        }

        public static float BounceIn(float _normalized)
        {
            return 1 - BounceOut(1 - _normalized);
        }

        public static float BounceOut(float _normalized)
        {
            if (_normalized < (1 / 2.75f))
            {
                return 7.5625f * _normalized * _normalized;
            }
            else if (_normalized < (2 / 2.75f))
            {
                return 7.5625f * (_normalized -= (1.5f / 2.75f)) * _normalized + 0.75f;
            }
            else if (_normalized < (2.5f / 2.75f))
            {
                return 7.5625f * (_normalized -= (2.25f / 2.75f)) * _normalized + 0.9375f;
            }
            else
            {
                return 7.5625f * (_normalized -= (2.625f / 2.75f)) * _normalized + 0.984375f;
            }
        }

        public static float BounceInOut(float _normalized)
        {
            if (_normalized < 0.5f)
            {
                return BounceIn(_normalized * 2) * 0.5f;
            }

            return BounceOut(_normalized * 2 - 1) * 0.5f + 0.5f;
        }
    }
}