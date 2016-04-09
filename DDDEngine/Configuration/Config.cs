using System.Collections.Generic;
using System.Windows.Controls;
using DDDEngine.Configuration.LineDrawingStrategy;
using DDDEngine.Utils.Exceptions;

namespace DDDEngine.Configuration
{
    public static class Config
    {

        public static ILineDrawingStrategy LineDrawingStrategy { get; set; } = new DefaultLineDrawingStrategy();
        private static Canvas _canvas;
        private static readonly Dictionary<string, object> Data = new Dictionary<string, object>();

        public static Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    throw new CanvasNotInitializedException();
                }
                return _canvas;
            }
            set { _canvas = value; }
        }

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
            _canvas = null;
            Data.Clear();
        }
    }
}