using Domino.Models;
using Domino.Views;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Domino
{
    internal class EnumToPageConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((AppPage)value)
            {
                case AppPage.Game:
                    return new GameView();
                case AppPage.Leaderboard:
                    return new LeaderboardView();
                case AppPage.MainMenu:
                    return new MainMenuView();
                case AppPage.SumUp:
                    return new SumUpView();
                default:
                    return new MainMenuView();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new EnumToPageConverter();
        }
    }
}
