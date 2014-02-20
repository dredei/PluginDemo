/* Автор: dredei
 * Сайт: http://softez.pp.ua/
 * Ссылка на урок: http://softez.pp.ua/2013/06/14/%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5-%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D1%81-%D0%BF%D0%BE%D0%B4%D0%B4%D0%B5%D1%80%D0%B6%D0%BA%D0%BE%D0%B9-%D0%BF%D0%BB%D0%B0/
*/

using PlugIn;

namespace Plugin2
{
    public class PlugIn : IPlugin
    {
        private string _PluginName = "Plugin2";
        private string _DisplayPluginName = "Второй плагин";
        private string _PluginDescription = "Описание второго плагина";
        private string _Author = "Dev";
        private int _Version = 100;
        IPluginHost _Host;

        public void Show()
        {
            frmP2Main frm = new frmP2Main( this );
            frm.ShowDialog();
        }

        public IPluginHost Host
        {
            get { return _Host; }
            set
            {
                _Host = value;
                _Host.Register( this );
            }
        }

        public string PluginName
        {
            get
            {
                return _PluginName;
            }
        }

        public string DisplayPluginName
        {
            get
            {
                return _DisplayPluginName;
            }
        }

        public string PluginDescription
        {
            get
            {
                return _PluginDescription;
            }
        }

        public string Author
        {
            get
            {
                return _Author;
            }
        }

        public int Version
        {
            get
            {
                return _Version;
            }
        }
    }
}
