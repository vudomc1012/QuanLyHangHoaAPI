using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WASM.Services;
using DTO;

namespace WASM.Pages.HangHoa
{
    public partial class ViewHangHoa
    {
        [Inject] private IHangHoaService sinhVienAPIService { get; set; }        
        [Inject] private NavigationManager _chuyen { get; set; }

        private List<DTO.ViewHangHoa> lstsv;      
        
        protected override async Task OnInitializedAsync()
        {
            lstsv = await sinhVienAPIService.GetlistSV();
            
        }
        private void Themmoi()
        {
            _chuyen.NavigateTo("/createhanghoa");
        }       
        private void Sua(Guid ma)
        {
            _chuyen.NavigateTo($"/updatehanghoa/{ma}");
        }
        private async void Xoa(Guid ma)
        {
            await sinhVienAPIService.Delete(ma);
            //_chuyen.NavigateTo("/viewsinhvien");
            _chuyen.NavigateTo("viewhanghoa", true);
        }
    }
}
