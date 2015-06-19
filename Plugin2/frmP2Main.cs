/* Автор: dredei
 * Сайт: http://softez.pp.ua/
 * Ссылка на урок: http://softez.pp.ua/2013/06/14/%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5-%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D1%81-%D0%BF%D0%BE%D0%B4%D0%B4%D0%B5%D1%80%D0%B6%D0%BA%D0%BE%D0%B9-%D0%BF%D0%BB%D0%B0/
*/

#region Using

using System;
using System.Windows.Forms;
using PlugIn;

#endregion

namespace Plugin2
{
    public partial class FrmP2Main : Form
    {
        private readonly IPlugin _plug;

        public FrmP2Main( IPlugin plug )
        {
            this.InitializeComponent();
            this._plug = plug;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            MessageBox.Show( this._plug.PluginDescription, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
    }
}