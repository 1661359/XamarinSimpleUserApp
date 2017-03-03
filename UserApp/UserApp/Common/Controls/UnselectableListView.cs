using Xamarin.Forms;

namespace UserApp.Common.Controls
{
    public class UnselectableListView : ListView
    {
        public UnselectableListView()
        {
            ItemTapped += UnselectableListView_ItemTapped;
        }

        private void UnselectableListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SelectedItem = null;
        }
    }
}