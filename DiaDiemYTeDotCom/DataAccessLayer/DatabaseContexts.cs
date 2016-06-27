using System.Data.Entity;
using System.Xml;

namespace DataAccessLayer
{
    class DatabaseContexts: DbContext
    {
        #region Singleton

        private static DatabaseContexts _instance;
        public static DatabaseContexts Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseContexts();
                }

                return _instance;
            }
        }

        private DatabaseContexts()
        {
            _locationDocument = new XmlDocument();
            _locationDocument.Load(_assemblyPath + LocationDbPath);
        }

        #endregion

        #region Attributes

        private string _assemblyPath;

        private const string LocationDbPath = "\\Database\\LocationDB.Xml";
        private readonly XmlDocument _locationDocument;

        #endregion

        #region Methods

        public void SetAssemblyPath(string path)
        {
            _assemblyPath = path;
        }

        #endregion
    }
}
