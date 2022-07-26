using Microsoft.JSInterop;

namespace RoseValleyServer.Service.ExcellExport
{
    public static class Excel
    {
         public static async Task SaveAsFileAsync(this IJSRuntime js , string filename , byte[] data,string type = "application/octet-strem")
        {
            await js.InvokeAsync<object>("Excel.FileExcel", filename, type, Convert.ToBase64String(data));
        }
    }
}
