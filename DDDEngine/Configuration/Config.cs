using System.Collections.Generic;
using DDDEngine.Configuration.LineDrawingStrategy;

namespace DDDEngine.Configuration
{
   public static class Config
    {

        public static ILineDrawingStrategy LineDrawingStrategy { get; set; } = new DefaultLineDrawingStrategy();
        private static readonly Dictionary<string, object> Data = new Dictionary<string, object>();
        public static double G { get; set; } = 9.8;

        public static void Add(string s, object o)
        {
            Data.Add(s, o);
        }

        public static object Get(string s)
        {
            return Data[s];
        }

        public static void Clear()
        {
            LineDrawingStrategy = new DefaultLineDrawingStrategy();
            Data.Clear();
        }
    }
}