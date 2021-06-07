using BlazorFluentUI.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BlazorClient.Shared.CustomMainLayout
{
    public partial class CustomMainLayout
    {
        private List<NavBarItem> _items = new List<NavBarItem>();
        private List<NavBarItem> _footerItems = new List<NavBarItem>();

        protected override Task OnInitializedAsync()
        {
            InitNavBar();
            return base.OnInitializedAsync();
        }



        private void InitNavBar()
        {
            var books = new NavBarItem
            {
                Text = "Books",
                Url = "books",
                NavMatchType = NavMatchType.AnchorOnly,
                Id = "books",
                Key = "1",
                IconName = "BookAnswers"
            };
            _items.Add(books);

            var footerItem = new NavBarItem
            {
                Url = "account",
                NavMatchType = NavMatchType.AnchorOnly,
                Id = "account",
                Key = "1",
                IconName = "AccountManagement"
            };
            _footerItems.Add(footerItem);
        }
    }
}
