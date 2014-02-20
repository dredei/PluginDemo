/* Автор: dredei
 * Сайт: http://softez.pp.ua/
 * Ссылка на урок: http://softez.pp.ua/2013/06/14/%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5-%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D1%81-%D0%BF%D0%BE%D0%B4%D0%B4%D0%B5%D1%80%D0%B6%D0%BA%D0%BE%D0%B9-%D0%BF%D0%BB%D0%B0/
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using PlugIn;

namespace PluginDemo
{
    public partial class frmMain : Form, IPluginHost
    {
        List<IPlugin> plugins;

        public frmMain()
        {
            InitializeComponent();
        }

        public void addPluginsItems()
        {
            lvPlugins.Items.Clear();
            for ( int i = 0; i < plugins.Count; i++ )
            {
                IPlugin plg = plugins[ i ];
                if ( plg == null )
                    continue;
                lvPlugins.Items.Add( plg.DisplayPluginName );
                lvPlugins.Items[ lvPlugins.Items.Count - 1 ].SubItems.Add( plg.Version.ToString() );
                lvPlugins.Items[ lvPlugins.Items.Count - 1 ].SubItems.Add( plg.Author );
            }
        }

        private void loadPlugins( string path )
        {
            string[] pluginFiles = Directory.GetFiles( path, "*.dll" );
            plugins = new List<IPlugin>();

            for ( int i = 0; i < pluginFiles.Length; i++ )
            {
                string args = pluginFiles[ i ].Substring(
                    pluginFiles[ i ].LastIndexOf( "\\" ) + 1,
                    pluginFiles[ i ].IndexOf( ".dll" ) -
                    pluginFiles[ i ].LastIndexOf( "\\" ) - 1 );

                Type ObjType = null;
                try
                {
                    Assembly ass = null;
                    ass = Assembly.Load( args );
                    var s = ass.FullName;
                    if ( ass != null )
                    {
                        ObjType = ass.GetType( args + ".PlugIn" );
                    }
                }
                catch
                {
                    return;
                }
                try
                {
                    if ( ObjType != null )
                    {
                        plugins.Add( (IPlugin)Activator.CreateInstance( ObjType ) );
                        plugins[ plugins.Count - 1 ].Host = this;

                    }
                }
                catch
                {
                    return;
                }
            }
        }

        private void frmMain_Load( object sender, EventArgs e )
        {
            loadPlugins( Application.StartupPath );
            addPluginsItems();
        }

        public bool Register( IPlugin plug )
        {
            return true;
        }

        private void lvPlugins_DoubleClick( object sender, EventArgs e )
        {
            if ( lvPlugins.SelectedItems.Count > 0 )
            {
                int selectedIndex = lvPlugins.SelectedItems[ 0 ].Index;
                plugins[ selectedIndex ].Show();
            }
        }
    }
}
