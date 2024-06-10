using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Services;

namespace TeamManagementApp.Views.Main
{
    public class MainPresenter
    {
        private IMainView _view;
        private readonly IMainService _mainService;
        private readonly IViewFactory _viewFactory;

        public MainPresenter(IMainService mainService, IViewFactory viewFactory)
        {
            _mainService = mainService;
            _viewFactory = viewFactory;
        }
        public void SetView(IMainView view)
        {
            _view = view;
        }
        public async Task Test()
        {
            _view.Text1.Text = await _mainService.Test();
        }
    }
}
