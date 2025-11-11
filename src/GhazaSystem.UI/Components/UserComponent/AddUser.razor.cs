using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace GhazaSystem.UI.Components.UserComponent
{
    public partial class AddUser
    {
        [Parameter]
        public string radio { get; set; } = "Professional";

        [Inject]
        private UserServices userServices { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        UserDTOs model = new UserDTOs();
        [Parameter]
        public bool ShowSussec { get; set; } = true;
        public void CloseMe()
        {

            ShowSussec = false;
            StateHasChanged();
        }


        async Task sentUser()
        {
            Snackbar.Add("salam",Severity.Info);
            ShowSussec = true;
            var result = await userServices.AddAsync(model);
            if(result.IsSuccess) ShowSussec = true;
        }

        void snackbar()
        {
            Snackbar.Add("salama testie", Severity.Success);
        }
        void snackbar(string message)
        {
            Snackbar.Add(message!);
        }

    }
}