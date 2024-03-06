﻿using UESAN.Proyecto.Core.DTO;

namespace UESAN.Proyecto.Core.InterfacesServices
{
    public interface IEmailService
    {
        void SendEmailPDF(EmailDTO request, Stream pdfStream, string pdfFileName);
        void SendEmailPassword(EmailPassword request);
	}
}