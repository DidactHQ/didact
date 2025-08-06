using System.Security.Cryptography;
using System.Text;

namespace DidactEngine.Licensing
{
    public class LicenseValidator
    {
        // From didact-prod-license-server-encryption-key PEM file.
        private const string PublicKeyPemString = @"
        -----BEGIN PUBLIC KEY-----
        MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEArXcXnZQVLQiBEG2PwvdJ33vgk1UaqrvQ1+ZAr17IdhYSe1uuCZ4WTOfKT0u8P4HlcDKYq5KwegkBItR7uEhCu17gfGyJ/+nZzEddXSjAN97ar1e3yerr5SsVWKX5LRUtUOGrB8HpHgW5dSVvD8H1WJrvCdCH6NwxhMAZhiZgOMe2c5p4yyhz6HvzYydXlG7C+RH3da6FOAoYPFvzLX57WMZdYVRMtQ3kd28bxaa14HmqcSNsBbh3YOESUxKZH5spqv04xRUaJhI9CosgouoUTGdexremhnY+WkV2BYvXyUjTPPbWUS79F+Qrpi3He6MBl8Ud8pINW7XXf9jJ9HD1UQIDAQAB
        -----END PUBLIC KEY-----        
        ";

        private readonly ILogger<LicenseValidator> _logger;
        private readonly RSA _publicKey;

        public LicenseValidator(ILogger<LicenseValidator> logger)
        {
            _logger = logger;
            _publicKey = RSA.Create();
            _publicKey.ImportFromPem(PublicKeyPemString.ToCharArray());
        }

        public bool ValidateLicense(string fullLicense)
        {
            // Split data and signature
            var parts = fullLicense.Split('.');
            var dataBytes = Convert.FromBase64String(parts[0]);
            var signatureBytes = Convert.FromBase64String(parts[1]);

            // Verify the signature
            bool isValid = _publicKey.VerifyData(dataBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            if (!isValid) return false;

            // Parse the license data
            var licenseData = Encoding.UTF8.GetString(dataBytes);
            var parts2 = licenseData.Split('|');
            var failSafeExpiry = DateTime.Parse(parts[1]);

            // Check if the fail-safe expiry is still valid
            return DateTime.UtcNow <= failSafeExpiry;
        }
    }
}