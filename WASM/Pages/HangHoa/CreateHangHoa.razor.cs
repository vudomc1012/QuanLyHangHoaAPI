using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WASM.Services;

namespace WASM.Pages.HangHoa
{
    public partial class CreateHangHoa
    {
        [Inject] private IHangHoaService sinhVienAPIService { get; set; }     
       
        [Inject] private NavigationManager _chuyen { get; set; }
        private DTO.ViewHangHoa sv = new DTO.ViewHangHoa();       
        protected override async Task OnInitializedAsync()
        {
           
        }
        private async void SubmitSinhVien(EditContext context)
        {
            if (sv != null)
            {
                await sinhVienAPIService.Create(sv);
                _chuyen.NavigateTo("/viewhanghoa");
                await sinhVienAPIService.GetlistSV();
            }
        }
    }
}
