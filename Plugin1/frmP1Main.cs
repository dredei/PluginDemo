/* Автор: dredei
 * Сайт: http://softez.pp.ua/
 * Ссылка на урок: http://softez.pp.ua/2013/06/14/%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5-%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D1%81-%D0%BF%D0%BE%D0%B4%D0%B4%D0%B5%D1%80%D0%B6%D0%BA%D0%BE%D0%B9-%D0%BF%D0%BB%D0%B0/
*/

#region Using

using System;
using System.Windows.Forms;
using PlugIn;

#endregion

namespace Plugin1
{
    public partial class FrmP1Main : Form
    {
        private readonly IPlugin _plug;

        public FrmP1Main( IPlugin plug )
        {
            this.InitializeComponent();
            this._plug = plug;
        }

        private void FrmP1Main_Load( object sender, EventArgs e )
        {
            this.tbInfo.AppendText( this._plug.Author + "\r\n" );
            this.tbInfo.AppendText( this._plug.DisplayPluginName + "\r\n" );
            this.tbInfo.AppendText( this._plug.PluginDescription + "\r\n" );
            this.tbInfo.AppendText( this._plug.PluginName + "\r\n" );
            this.tbInfo.AppendText( this._plug.Version + "\r\n" );
        }
    }
}