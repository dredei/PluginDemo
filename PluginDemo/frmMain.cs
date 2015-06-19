/* Автор: dredei
 * Сайт: http://softez.pp.ua/
 * Ссылка на урок: http://softez.pp.ua/2013/06/14/%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5-%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D1%81-%D0%BF%D0%BE%D0%B4%D0%B4%D0%B5%D1%80%D0%B6%D0%BA%D0%BE%D0%B9-%D0%BF%D0%BB%D0%B0/
*/

#region Using

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using PlugIn;

#endregion

namespace PluginDemo
{
    public partial class FrmMain : Form, IPluginHost
    {
        private List<IPlugin> _plugins;

        public FrmMain()
        {
            this.InitializeComponent();
        }

        private void AddPluginsItems()
        {
            this.lvPlugins.Items.Clear();
            foreach ( IPlugin plugin in this._plugins )
            {
                if ( plugin == null )
                {
                    continue;
                }
                this.lvPlugins.Items.Add( plugin.DisplayPluginName );
                this.lvPlugins.Items[ this.lvPlugins.Items.Count - 1 ].SubItems.Add( plugin.Version.ToString() );
                this.lvPlugins.Items[ this.lvPlugins.Items.Count - 1 ].SubItems.Add( plugin.Author );
            }
        }

        private void LoadPlugins( string path )
        {
            string[] pluginFiles = Directory.GetFiles( path, "*.dll" );
            this._plugins = new List<IPlugin>();

            foreach ( string pluginPath in pluginFiles )
            {
                Type objType = null;
                try
                {
                    // пытаемся загрузить библиотеку
                    Assembly assembly = Assembly.LoadFrom( pluginPath );
                    if ( assembly != null )
                    {
                        objType = assembly.GetType( Path.GetFileNameWithoutExtension( pluginPath ) + ".PlugIn" );
                    }
                }
                catch
                {
                    continue;
                }
                try
                {
                    if ( objType != null )
                    {
                        this._plugins.Add( (IPlugin)Activator.CreateInstance( objType ) );
                        this._plugins[ this._plugins.Count - 1 ].Host = this;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        private void FrmMain_Load( object sender, EventArgs e )
        {
            this.LoadPlugins( Application.StartupPath );
            this.AddPluginsItems();
        }

        public bool Register( IPlugin plug )
        {
            return true;
        }

        private void lvPlugins_DoubleClick( object sender, EventArgs e )
        {
            if ( this.lvPlugins.SelectedItems.Count > 0 )
            {
                int selectedIndex = this.lvPlugins.SelectedItems[ 0 ].Index;
                this._plugins[ selectedIndex ].Show();
            }
        }
    }
}