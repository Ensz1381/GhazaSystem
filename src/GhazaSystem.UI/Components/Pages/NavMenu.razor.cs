using Microsoft.AspNetCore.Components;

namespace GhazaSystem.UI.Components.Pages
{
    public partial class NavMenu
    {
        private bool _open = false;
        private void moseover()
        {
             _open = true;
        }
        private void moseout()
        {
            _open = false;
        }

    }
}