using GhazaSystem.Common.Data;
using GhazaSystem.UI.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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
        public async Task GetLocalUserFromStorage()
        {
            try
            {

                var result = await LStorage.GetAsync<User>("User");
                if (result.Success && result.Value != null)
                {
                    userServices.LocalUser = result.Value;
                    StateHasChanged();
                }
                else
                {
                    Snackbar.Add("مجددا باید وارد سیستم شوید", Severity.Error);
                    NManager.NavigateTo("/", forceLoad: true);
                }
            }
            catch (Exception)
            { NManager.NavigateTo("/", forceLoad: true); }

        }

    }
}