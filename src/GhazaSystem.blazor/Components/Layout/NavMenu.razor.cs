namespace GhazaSystem.blazor.Components.Layout
{
    public partial class NavMenu
    {
        private bool _open = false;

        private void ToggleDrawer()
        {
            _open = !_open;
        }
    }
}