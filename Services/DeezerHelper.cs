using System.Collections.Generic;

namespace QuickClipBlazor.Services
{
    public static class DeezerHelper
    {
        //Generated from https://developers.deezer.com/guidelines/countries
        //Using: JSON.stringify([...$('tr td[width=200]')].map(x => x.innerText))
        private static readonly List<string> _allowedCountryList = new List<string>()
        {
            "AE", "AF", "AG", "AI", "AL", "AM", "AO", "AR", "AT", "AU", "AZ", "BA", "BB", "BD", "BE", "BF", "BG", "BH",
            "BI", "BJ", "BN", "BO", "BR", "BT", "BW", "BY", "CA", "CC", "CD", "CF", "CG", "CH", "CI", "CK", "CL", "CM",
            "CO", "CR", "CV", "CX", "CY", "CZ", "DE", "DJ", "DK", "DM", "DZ", "EC", "EE", "EG", "ER", "ES", "ET", "FI",
            "FJ", "FK", "FM", "FR", "GA", "GB", "GD", "GE", "GH", "GM", "GN", "GQ", "GR", "GT", "GW", "HN", "HR", "HU",
            "ID", "IE", "IL", "IO", "IQ", "IS", "IT", "JM", "JO", "JP", "KE", "KG", "KH", "KI", "KM", "KN", "KW", "KY",
            "KZ", "LA", "LB", "LC", "LK", "LR", "LS", "LT", "LU", "LV", "LY", "MA", "MD", "ME", "MG", "MH", "MK", "ML",
            "MN", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ", "NA", "NE", "NF", "NG", "NI", "NL", "NO", "NP",
            "NR", "NU", "NZ", "OM", "PA", "PE", "PG", "PH", "PK", "PL", "PN", "PT", "PW", "PY", "QA", "RO", "RS", "RU",
            "RW", "SA", "SB", "SC", "SE", "SG", "SI", "SJ", "SK", "SL", "SN", "SO", "ST", "SV", "SZ", "TC", "TD", "TG",
            "TH", "TJ", "TK", "TL", "TM", "TN", "TO", "TR", "TV", "TZ", "UA", "UG", "US", "UY", "UZ", "VC", "VE", "VG",
            "VN", "VU", "WS", "YE", "ZA", "ZM", "ZW"
        };

        public static bool IsAllowedCountry(string countryCode)
        {
            return _allowedCountryList.Contains(countryCode);
        }
    }
}