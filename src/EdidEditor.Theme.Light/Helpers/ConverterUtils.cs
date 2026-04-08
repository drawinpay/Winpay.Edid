using System.Windows;

namespace EdidEditor.Theme.Light.Helpers
{
    /// <summary>
    /// 转换器扩展类
    /// </summary>
    public static class ConverterUtils
    {
        /// <summary>
        /// 转换数字
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double ToNumber<T>(T argument)
        {
            if (argument is int intResult)
            {
                return intResult;
            }
            if (argument is double doubleResult)
            {
                return doubleResult;
            }
            if (argument is string str)
            {
                return double.Parse(str);
            }
            throw new ArgumentException();
        }

        /// <summary>
        /// 反转显示
        /// </summary>
        /// <param name="visibility"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Visibility ReverseVisibility(Visibility visibility)
        {
            switch (visibility)
            {
                case Visibility.Visible: return Visibility.Collapsed;
                case Visibility.Hidden: return Visibility.Visible;
                case Visibility.Collapsed: return Visibility.Visible;
            }
            throw new ArgumentException();
        }

        /// <summary>
        /// 根据圆的中心、半径、角度获取另一个点
        /// </summary>
        /// <param name="centerPoint">圆的中心</param>
        /// <param name="r">半径</param>
        /// <param name="arcAngel">弧度角度</param>
        /// <returns></returns>
        public static Point GetPointByAngel(Point centerPoint, double r, double arcAngel)
        {
            var p = new Point
            {
                X = Math.Sin(arcAngel) * r + centerPoint.X,
                Y = centerPoint.Y - Math.Cos(arcAngel) * r
            };
            return p;
        }
    }
}
