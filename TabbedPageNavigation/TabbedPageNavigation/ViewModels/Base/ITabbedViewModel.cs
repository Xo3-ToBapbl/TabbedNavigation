using System.Collections.Generic;

namespace TabbedPageNavigation.ViewModels.Base
{
    public interface ITabbedViewModel
    {
        void AddTabsViewModels(ICollection<BaseViewModel> viewModels);
    }
}