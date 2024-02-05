using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Platform;
using UIKit;

namespace MiracleApp.Platforms.iOS
{
    public class CustomCellViewHandler : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            cell.SelectedBackgroundView = new UIView
            {
                BackgroundColor = ((CustomViewCell)item).SelectedBackgroundColor.ToPlatform()
            };

            return cell;
        }
    }
}
