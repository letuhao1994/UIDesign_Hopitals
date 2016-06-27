using System;

namespace HelperLayer
{
    public class RandomHelper
    {
        #region Singleton
        private static RandomHelper _instance;

        public static RandomHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RandomHelper();
                }

                return _instance;
            }
        }

        private RandomHelper()
        {
            Random = new Random();
        }
        #endregion

        public Random Random { get; }
    }
}
