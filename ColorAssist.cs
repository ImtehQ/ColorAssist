using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RealisticPhysics
{
    public enum ColorAssistChannel
    {
        Red, Blue, Green, Alpha
    }

    public static class ColorAssist
    {
        /// <summary>
        /// Creates a random color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color Random(this Color color)
        {
            return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
        }

        /// <summary>
        /// Converts a float to colour, basec on channel
        /// </summary>
        /// <param name="value"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static Color ToColor(this float value, ColorAssistChannel channel, bool alphaBlack = false)
        {
            if (channel == ColorAssistChannel.Red)
                return new Color(value, 0, 0, 1);
            else if (channel == ColorAssistChannel.Blue)
                return new Color(0, value, 0, 1);
            else if (channel == ColorAssistChannel.Green)
                return new Color(0, 0, value, 1);
            else if (channel == ColorAssistChannel.Alpha && alphaBlack)
                return new Color(0, 0, 0, value);
            else if (channel == ColorAssistChannel.Alpha)
                return new Color(1, 1, 1, value);
            return Color.black;
        }

        /// <summary>
        /// Creates a array of colors based on given perameters
        /// </summary>
        /// <param name="count"></param>
        /// <param name="minRange"></param>
        /// <param name="maxRange"></param>
        /// <param name="channel"></param>
        /// <param name="alphaBlack"></param>
        /// <returns></returns>
        public static Color[] ToColorArray(byte count, byte minRange, byte maxRange, ColorAssistChannel channel, bool alphaBlack = false)
        {
            if (maxRange <= minRange)
            {
                Debug.LogErrorFormat("maxRange of {0} is smaller or equal to minRange of {1}", maxRange, minRange);
                return null;
            }
            Color[] colors = new Color[count];

            float value = (maxRange - minRange) / count;

            for (int i = 0; i < count; i++)
            {
                value *= i;
                value /= 256;
                colors[i] = value.ToColor(channel, alphaBlack);
            }
            return colors;
        }

        /// <summary>
        /// Creates a color basec of given values
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Color ToColor(this float first, float second)
        {
            return new Color(first, second, 0, 1);
        }
        /// <summary>
        /// Creates a color basec of given values
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Color ToColor(this float first, float second, float third)
        {
            return new Color(first, second, third, 1);
        }
        /// <summary>
        /// Creates a color basec of given values
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Color ToColor(this float first, float second, float third, float fourth)
        {
            return new Color(first, second, third, fourth);
        }

        /// <summary>
        /// Convert ushort to color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Color ToColor(this ushort value)
        {
            byte[] bytes = System.BitConverter.GetBytes(value);
            if (bytes.Length == 1)
                return new Color(((float)bytes[0]) / 256, 1, 1, 1);
            if (bytes.Length == 2)
                return new Color(((float)bytes[0]) / 256, (((float)bytes[1]) / 256), 1, 1);
            if (bytes.Length == 3)
                return new Color(((float)bytes[0]) / 256, (((float)bytes[1]) / 256), (((float)bytes[2]) / 256), 1);
            if (bytes.Length == 4)
                return new Color(((float)bytes[0]) / 256, (((float)bytes[1]) / 256), (((float)bytes[2]) / 256), (((float)bytes[3]) / 256));
            
            Debug.LogErrorFormat("Value of {0} could not be converted to a color", value);
            return Color.black;

        }

        /// <summary>
        /// converts a number to a color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Color ToColor(this float value)
        {
            return ((ushort)value).ToColor();
        }

        /// <summary>
        /// Return a int number containing 2 channels of the provided color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToUInt16(this Color value)
        {
            byte[] colorBytes = new byte[4];

            colorBytes[0] = (byte)(value.r * 256);
            colorBytes[1] = (byte)(value.g * 256);

            return System.BitConverter.ToUInt16(colorBytes, 0);
        }


        /// <summary>
        /// Return a Uint number containing 2 channels of the provided color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt16(this Color value)
        {
            byte[] colorBytes = new byte[4];

            colorBytes[0] = (byte)(value.r * 256);
            colorBytes[1] = (byte)(value.g * 256);

            return System.BitConverter.ToInt16(colorBytes, 0);
        }

        /// <summary>
        /// Return a short number containing 2 channels of the provided color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short ToShort16(this Color value)
        {
            byte[] colorBytes = new byte[4];

            colorBytes[0] = (byte)(value.r * 256);
            colorBytes[1] = (byte)(value.g * 256);

            return System.BitConverter.ToInt16(colorBytes, 0);
        }

        /// <summary>
        /// Return a Ushort number containing 2 channels of the provided color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ushort ToUshort16(this Color value)
        {
            byte[] colorBytes = new byte[4];

            colorBytes[0] = (byte)(value.r * 256);
            colorBytes[1] = (byte)(value.g * 256);

            return System.BitConverter.ToUInt16(colorBytes, 0);
        }

        /// <summary>
        /// Return a int number containing 4 channels of the provided color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(this Color value)
        {
            byte[] colorBytes = new byte[4];

            colorBytes[0] = (byte)(value.r * 256);
            colorBytes[1] = (byte)(value.g * 256);
            colorBytes[2] = (byte)(value.b * 256);
            colorBytes[3] = (byte)(value.a * 256);

            return System.BitConverter.ToInt32(colorBytes, 0);
        }

        /// <summary>
        /// Return a Uint number containing 4 channels of the provided color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint ToUInt32(this Color value)
        {
            byte[] colorBytes = new byte[4];

            colorBytes[0] = (byte)(value.r * 256);
            colorBytes[1] = (byte)(value.g * 256);
            colorBytes[2] = (byte)(value.b * 256);
            colorBytes[3] = (byte)(value.a * 256);

            return System.BitConverter.ToUInt32(colorBytes, 0);
        }

        /// <summary>
        /// Converts a float[,] array to a textue2D
        /// Where value * maxvalue, toColorValue
        /// </summary>
        /// <param name="array"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static Texture2D ToTexture2D(this float[,] array, int width, int height, int maxValue)
        {
            Texture2D t2D = new Texture2D(width, height);
            ushort value;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    value = (ushort)(array[x, y] * maxValue);
                    if(maxValue <= 256)
                        t2D.SetPixel(x, y, (value).ToColor());
                }
            }
            t2D.Apply();
            return t2D;
        }

    }

    /// <summary>
    /// Holds a Dictionary of colors
    /// </summary>
    public class ColorHolder
    {
        private Color nullColor;
        private Color holderColor;

        public Dictionary<string, Color> Collection =
            new Dictionary<string, Color>();

        private int countLimit;
        public int Limit
        {
            get { return countLimit; }
            set { countLimit = value; }
        }

        public ColorHolder(int limit = 1000)
        {
            countLimit = limit;

            nullColor = Color.black;
            holderColor = Color.black;
        }

        public bool IsNull()
        {
            if (Collection.Count > 0)
                return false;
            return true;
        }

        /// <summary>
        /// Adds a color to the Dictionary where key will be color number
        /// </summary>
        /// <param name="color"></param>
        public void Add(ref Color color)
        {
            try
            {
                Collection.Add(ColorAssist.ToInt32(color).ToString(), color);
            }
            catch (System.ArgumentException)
            {
                Debug.LogErrorFormat("Add: An element with Key = {0} already exists.", ColorAssist.ToInt32(color).ToString());
            }
        }
        /// <summary>
        /// Adds a color to the Dictionary where key will be color number
        /// </summary>
        /// <param name="color"></param>
        public void Add(Color color)
        {
            try
            {
                Collection.Add(ColorAssist.ToInt32(color).ToString(), color);
            }
            catch (System.ArgumentException)
            {
                Debug.LogErrorFormat("Add: An element with Key = {0} already exists.", ColorAssist.ToInt32(color).ToString());
            }
        }

        /// <summary>
        /// Add a color to the Dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="color"></param>
        public void Add(ref string key, ref Color color)
        {
            if(Collection.Count + 1 > countLimit)
            {
                Debug.LogError("Add exceeds maximum count of the set");
            }
            try
            {
                Collection.Add(key, color);
            }
            catch (System.ArgumentException)
            {
                Debug.LogErrorFormat("Add: An element with Key = {0} already exists.", key);
            }
        }

        /// <summary>
        /// Add a color to the Dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="color"></param>
        public void Add(string key, Color color)
        {
            try
            {
                Collection.Add(key, color);
            }
            catch (System.ArgumentException)
            {
                Debug.LogErrorFormat("Add: An element with Key = {0} already exists.", key);
            }
        }

        /// <summary>
        /// Adds a color array to the Dictionary
        /// </summary>
        /// <param name="colors"></param>
        public void Add(ref Color[] colors)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                Add(colors[i].ToUInt32().ToString(), colors[i]);
            }
        }

        /// <summary>
        /// Adds a list of colors to the Dictionary
        /// </summary>
        /// <param name="Count"></param>
        public void Add(ref int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Add(i.ToString(), ColorAssist.ToColor((float)i));
            }
        }
        /// <summary>
        /// Adds a list of colors to the Dictionary
        /// </summary>
        /// <param name="Count"></param>
        public void Add(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Add(i.ToString(), ColorAssist.ToColor((float)i));
            }
        }
        /// <summary>
        /// Gets a color from the Dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Color Get(ref string key)
        {
            try
            {
                return Collection[key];
            }
            catch (KeyNotFoundException)
            {
                Debug.LogErrorFormat("Get: An element with Key = {0} does not exists.", key);
                return nullColor;
            }
        }
        /// <summary>
        /// Gets a color from the Dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Color Get(string key)
        {
            try
            {
                return Collection[key];
            }
            catch (KeyNotFoundException)
            {
                Debug.LogErrorFormat("Get: An element with Key = {0} does not exists.", key);
                return nullColor;
            }
        }

        /// <summary>
        /// Trys to get a color from the Dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Color TryGet(ref string key)
        {

            if (Collection.TryGetValue(key, out holderColor))
            {
                return holderColor;
            }
            else
            {
                Debug.LogErrorFormat("TryGet: An element with Key = {0} is not found.", key);
                return nullColor;
            }
        }
        /// <summary>
        /// Trys to get a color from the Dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Color TryGet(string key)
        {

            if (Collection.TryGetValue(key, out holderColor))
            {
                return holderColor;
            }
            else
            {
                Debug.LogErrorFormat("TryGet: An element with Key = {0} is not found.", key);
                return nullColor;
            }
        }

        /// <summary>
        /// Set a colors value directly
        /// </summary>
        /// <param name="key"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void Set(ref string key, ref int r,ref int g, ref int b, ref int a)
        {
            holderColor = Collection[key];
            holderColor.r = r; holderColor.g = g; holderColor.b = b; holderColor.a = a;
        }
        /// <summary>
        /// Set a colors value directly
        /// </summary>
        /// <param name="key"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void Set(ref string key, int r, int g, int b, int a)
        {
            holderColor = Collection[key];
            holderColor.r = r; holderColor.g = g; holderColor.b = b; holderColor.a = a;
        }
        /// <summary>
        /// Set a colors value directly
        /// </summary>
        /// <param name="key"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void Set(string key, int r, int g, int b, int a)
        {
            holderColor = Collection[key];
            holderColor.r = r; holderColor.g = g; holderColor.b = b; holderColor.a = a;
        }

        /// <summary>
        /// Try to set a colors value directly
        /// </summary>
        /// <param name="key"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void TrySet(ref string key, ref int r, ref int g, ref int b, ref int a)
        {
            if (Collection.TryGetValue(key, out holderColor))
            {
                holderColor.r = r; holderColor.g = g; holderColor.b = b; holderColor.a = a;
            }
            else
            {
                Debug.LogErrorFormat("TrySet: An element with Key = {0} is not found.", key);
            }
        }
        /// <summary>
        /// Try to set a colors value directly
        /// </summary>
        /// <param name="key"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void TrySet(ref string key, int r, int g, int b, int a)
        {
            if (Collection.TryGetValue(key, out holderColor))
            {
                holderColor.r = r; holderColor.g = g; holderColor.b = b; holderColor.a = a;
            }
            else
            {
                Debug.LogErrorFormat("TrySet: An element with Key = {0} is not found.", key);
            }
        }
        /// <summary>
        /// Try to set a colors value directly
        /// </summary>
        /// <param name="key"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void TrySet(string key, int r, int g, int b, int a)
        {
            if (Collection.TryGetValue(key, out holderColor))
            {
                holderColor.r = r; holderColor.g = g; holderColor.b = b; holderColor.a = a;
            }
            else
            {
                Debug.LogErrorFormat("TrySet: An element with Key = {0} is not found.", key);
            }
        }

        /// <summary>
        /// Removes the 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(ref string key)
        {
            Collection.Remove(key);
        }
        /// <summary>
        /// Removes the 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            Collection.Remove(key);
        }
    }
}
