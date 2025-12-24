using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace GhazaSystem.UI.Components.Dialog.Company;


public partial class AddCompanyDialog()
{
    [CascadingParameter] public IMudDialogInstance MudDialog { get; set; } = default!;

    public CompanyDTOs companyDTOs = new CompanyDTOs();


    double _value;

    private async Task Submit()
    {
        if (string.IsNullOrWhiteSpace(companyDTOs.Name))
        {
            return;
        }

        var result = await companyServices.AddAsync(companyDTOs);
        Snackbar.Add($"شرکت {companyDTOs.Name} اضافه شد", Severity.Success);


        MudDialog.Close(DialogResult.Ok(companyDTOs));
    }

    private void Cancel() => MudDialog.Cancel();
}