/* Автор: dredei
 * Сайт: http://softez.pp.ua/
 * Ссылка на урок: http://softez.pp.ua/2013/06/14/%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5-%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D1%81-%D0%BF%D0%BE%D0%B4%D0%B4%D0%B5%D1%80%D0%B6%D0%BA%D0%BE%D0%B9-%D0%BF%D0%BB%D0%B0/
*/

namespace PlugIn
{
    public interface IPlugin
    {
        string PluginName { get; } // имя плагина
        string DisplayPluginName { get; } // имя плагина, которое отображается
        string PluginDescription { get; } // описание плагина
        string Author { get; } // имя автора
        int Version { get; } // версия
        IPluginHost Host { get; set; } // ссылка на главную форму

        void Show(); // отображает форму
    }

    public interface IPluginHost
    {
        bool Register( IPlugin plug );
    }
}