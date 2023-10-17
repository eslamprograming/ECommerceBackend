namespace BLL.Service
{
    public interface ISendMailService
    {
        Task sendEmailAsync(string mailTo,string subject, string body);
        
    }
}
