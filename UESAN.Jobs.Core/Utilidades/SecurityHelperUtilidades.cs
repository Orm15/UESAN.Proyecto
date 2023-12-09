using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Proyecto.Core.Utilidades
{
	public class SecurityHelperUtilidades
	{
		public static string HashPassword(string password, string salt)
		{
			using (var sha256 = SHA256.Create())
			{
				var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
				return Convert.ToBase64String(hashedBytes);
			}
		}

		public static string GenerateSalt()
		{
			byte[] saltBytes = new byte[8];
			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(saltBytes);
			}
			return Convert.ToBase64String(saltBytes);
		}

		public static (string Password, string Salt) SetPassword(string password)
		{
			string Salt, Contra;
			// Generar una nueva sal y calcular el hash de la contraseña
			Salt = SecurityHelperUtilidades.GenerateSalt();
			Contra = SecurityHelperUtilidades.HashPassword(password, Salt);
			return  (Contra,Salt);
		}



	}
}
