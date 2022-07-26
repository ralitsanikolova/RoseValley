using Microsoft.AspNetCore.Components.Forms;

namespace RoseValleyServer.Service.IService
{
    public interface IFIleUpload
    {
       public  Task<string> UploadFile(IBrowserFile file);
       public  bool DeleteFile(string fileName);
    }
}
