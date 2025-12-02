using GhazaSystem.Common.Data;
using GhazaSystem.Common.DTOs;
using GhazaSystem.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace GhazaSystem.UI.Components.Dialog
{
    public partial class AddFoodDialog()
    {
        [CascadingParameter] public IMudDialogInstance MudDialog { get; set; } = default!;

        public FoodDTOs foodForm = new FoodDTOs() { Amount = 0, Name = "Defualt"};


        public string foodName = "";
        private string description = "";
        private decimal price = 0;
        private string category = "ایرانی";
        private IBrowserFile? selectedFile;
        private string? imagePreview;
        double _value;
        private long max_size = 20 * 1024 * 1024;
        private string base_image_path = "wwwroot/image/foods/";
        private string show_image_path = "/image/foods/";
        private byte[] buffer = new byte[1024];




        async Task InputChange(InputFileChangeEventArgs args)
        {
            /* خواندن عکس بدون پروگرس
            MemoryStream memoryStream = new MemoryStream();

            await args.File.OpenReadStream(max_size).CopyToAsync(memoryStream);

            File.WriteAllBytes($"{base_image_path}{args.File.Name}", memoryStream.ToArray());
            */
            _value = 0;
            Stream stream = args.File.OpenReadStream(max_size);
            FileStream fileStream = new FileStream($"{base_image_path}{args.File.Name}", FileMode.Create);
            long file_size = args.File.Size;
            double resount = 100 / (file_size / 1024);
            while (true)
            {
                int readbyte = await stream.ReadAsync(buffer);

                if (readbyte == 0)
                {
                    _value = 100;
                    break;
                }

                _value += resount;
                StateHasChanged();
                fileStream.Write(buffer, 0, readbyte);

            }

            foodName = args.File.Name;
            /*
            foodForm.Photos = $"{base_image_path}{args.File.Name}";

            var result = await foodServices.AddAsync(foodForm);
            Snackbar.Add($"غذای {foodForm.Name} اضافه شد", Severity.Success);
            */
            imagePreview = $"{show_image_path}{foodName}";
    }


        private async Task Submit()
        {
            if (string.IsNullOrWhiteSpace(foodName))
            {
                return;
            }
            foodForm.Photos = $"{show_image_path}{foodName}";

            var result = await foodServices.AddAsync(foodForm);
            Snackbar.Add($"غذای {foodForm.Name} اضافه شد", Severity.Success);


            MudDialog.Close(DialogResult.Ok(foodName));
        }

        private void Cancel() => MudDialog.Cancel();
    }
}