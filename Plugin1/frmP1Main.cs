/* Автор: dredei
 * Сайт: http://softez.pp.ua/
 * Ссылка на урок: http://softez.pp.ua/2013/06/14/%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5-%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D1%81-%D0%BF%D0%BE%D0%B4%D0%B4%D0%B5%D1%80%D0%B6%D0%BA%D0%BE%D0%B9-%D0%BF%D0%BB%D0%B0/
*/

using System;
using System.Windows.Forms;
using PlugIn;

namespace Plugin1
{
    public partial class frmP1Main : Form
    {
        IPlugin plug;

        public frmP1Main( IPlugin plug )
        {
            InitializeComponent();
            this.plug = plug;
        }

        private void frmP1Main_Load( object sender, EventArgs e )
        {
            tbInfo.AppendText( plug.Author + "\r\n" );
            tbInfo.AppendText( plug.DisplayPluginName + "\r\n" );
            tbInfo.AppendText( plug.PluginDescription + "\r\n" );
            tbInfo.AppendText( plug.PluginName + "\r\n" );
            tbInfo.AppendText( plug.Version.ToString() + "\r\n" );
        }
    }
}
