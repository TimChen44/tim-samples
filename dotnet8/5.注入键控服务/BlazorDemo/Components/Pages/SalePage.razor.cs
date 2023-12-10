using BlazorDemo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Components.Pages
{
    public partial class SalePage
    {
        [Inject(Key = "VIP")]
        public MyDemoSrv? VipSrv { get; set; }

        [Inject(Key = "Customer")]
        public MyDemoSrv? CustomerSrv { get; set; }

        private string? message { get; set; }
        private void VIPButton()
        {
            message = VipSrv?.GetUserType();
        }

        private void CustomerButton()
        {
            message = CustomerSrv?.GetUserType();
        }

        #region

        [Inject(Key = "Read")]
        public EFDemoContext? ReadContext { get; set; }

        [Inject(Key = "Write")]
        public EFDemoContext? WriteContext { get; set; }

        private void ShowConnectionString()
        {
            Console.WriteLine($"ReadContext : {ReadContext.Database.GetConnectionString()}");
            Console.WriteLine($"WriteContext: {WriteContext.Database.GetConnectionString()}");
        }

        #endregion
    }
}
