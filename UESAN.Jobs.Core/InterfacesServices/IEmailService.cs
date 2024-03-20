using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IEmailService
    {
		string SendEmailPDF(EmailDTO request, Stream pdfStream, string pdfFileName);

		string SendEmailPassword(EmailPassword request);
	}
}