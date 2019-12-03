using System;
using System.Collections.Generic;

namespace Finance
{
        class IBAN
    {
        public static string standardIBANpattern = @"[A-Z]{2}[0-9]{2} ?[A-Z0-9]{4} ?[A-Z0-9]{4} ?[A-Z0-9]{1,4} ?" +
        @"([A-Z0-9]{1,4})? ?([A-Z0-9]{1,4})? ?([A-Z0-9]{1,4})? ?([A-Z0-9]{1,4})?"; // Regex pattern case for all known IBAN's

        public static readonly Dictionary<CountryId, CountryInfo> Countries = new Dictionary<CountryId, CountryInfo>()
        {
            {CountryId.AL,
                new CountryInfo()
                { Name="Albania", IbanPattern= @"AL[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){2}([a-zA-Z0-9]{4}\s?){4}\s?"}},
            {CountryId.AD,
                new CountryInfo()
                { Name="Andorra", IbanPattern= @"AD[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){2}([a-zA-Z0-9]{4}\s?){3}\s?"}},
            {CountryId.AT,
                new CountryInfo()
                { Name="Austria", IbanPattern= @"AT[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}\s?"}},
            {CountryId.AZ,
                new CountryInfo()
                { Name="Azerbaijan", IbanPattern= @"AZ[a-zA-Z0-9]{2}\s?([a-zA-Z0-9]{4}\s?){1}([0-9]{4}\s?){5}\s?"}},
            {CountryId.BH,
                new CountryInfo()
                { Name="Bahrain", IbanPattern= @"BH[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([a-zA-Z0-9]{4}\s?){3}([a-zA-Z0-9]{2})\s?"}},
            {CountryId.BY,
                new CountryInfo()
                { Name="Belaru", IbanPattern= @"BY[a-zA-Z0-9]{2}\s?([a-zA-Z0-9]{4}\s?){1}([0-9]{4}\s?){5}\s?v"}},
            {CountryId.BE,
                new CountryInfo()
                { Name="Belgium", IbanPattern= @"BE[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){3}\s?"}},
            {CountryId.BA,
                new CountryInfo()
                { Name="Bosnia and Herzegovina", IbanPattern= @"BA[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}\s?"}},
            {CountryId.BR,
                new CountryInfo()
                { Name="Brazil", IbanPattern= @"BR[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){5}([0-9]{3})([a-zA-Z]{1}\s?)([a-zA-Z0-9]{1})\s?"}},
            {CountryId.BG,
                new CountryInfo()
                { Name="Bulgaria", IbanPattern= @"BG[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([0-9]{4}\s?){1}([0-9]{2})([a-zA-Z0-9]{2}\s?)([a-zA-Z0-9]{4}\s?){1}([a-zA-Z0-9]{2})\s?"}},
            {CountryId.CR,
                new CountryInfo()
                { Name="Costa Rica", IbanPattern= @"CR[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}([0-9]{2})\s?"}},
            {CountryId.HR,
                new CountryInfo()
                { Name="Croatia", IbanPattern= @"HR[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}([0-9]{1})\s?"}},
            {CountryId.CY,
                new CountryInfo()
                { Name="Cyprus", IbanPattern= @"CY[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){2}([a-zA-Z0-9]{4}\s?){4}\s?"}},
            {CountryId.CZ,
                new CountryInfo()
                { Name="Czech Republic", IbanPattern= @"CZ[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){5}\s?"}},
            {CountryId.DK,
                new CountryInfo()
                { Name="Denmark", IbanPattern= @"DK[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){3}([0-9]{2})\s?"}},
            {CountryId.DO,
                new CountryInfo()
                { Name="Dominican Republic", IbanPattern= @"DO[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([0-9]{4}\s?){5}\s?"}},
            {CountryId.TL,
                new CountryInfo()
                { Name="East Timor", IbanPattern= @"TL[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}([0-9]{3})\s?"}},
            {CountryId.EE,
                new CountryInfo()
                { Name="Estonia", IbanPattern= @"EE[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}\s?"}},
            {CountryId.FO,
                new CountryInfo()
                { Name="Faroe Islands", IbanPattern= @"FO[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){3}([0-9]{2})\s?"}},
            {CountryId.FI,
                new CountryInfo()
                { Name="Finland", IbanPattern= @"FI[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){3}([0-9]{2})\s?"}},
            {CountryId.FR,
                new CountryInfo()
                { Name="France", IbanPattern= @"FR[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){2}([0-9]{2})([a-zA-Z0-9]{2}\s?)([a-zA-Z0-9]{4}\s?){2}([a-zA-Z0-9]{1})([0-9]{2})\s?"}},
            {CountryId.GE,
                new CountryInfo()
                { Name="Georgia", IbanPattern= @"GE[a-zA-Z0-9]{2}\s?([a-zA-Z0-9]{2})([0-9]{2}\s?)([0-9]{4}\s?){3}([0-9]{2})\s?"}},
            {CountryId.DE,
                new CountryInfo()
                { Name="Germany", IbanPattern= @"[A-Za-z]{2} ?\d{2} ?\d{4} ?\d{4} ?\d{4} ?\d{4} ?\d{2}"}}, //manually
            {CountryId.GI,
                new CountryInfo()
                { Name="Gibraltar", IbanPattern= @"GI[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([a-zA-Z0-9]{4}\s?){3}([a-zA-Z0-9]{3})\s?"}},
            {CountryId.GR,
                new CountryInfo()
                { Name="Greece", IbanPattern= @"GR[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){1}([0-9]{3})([a-zA-Z0-9]{1}\s?)([a-zA-Z0-9]{4}\s?){3}([a-zA-Z0-9]{3})\s?"}},
            {CountryId.GL,
                new CountryInfo()
                { Name="Greenland", IbanPattern= @"GL[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){3}([0-9]{2})\s?"}},
            {CountryId.GT,
                new CountryInfo()
                { Name="Guatemala", IbanPattern= @"GT[a-zA-Z0-9]{2}\s?([a-zA-Z0-9]{4}\s?){1}([a-zA-Z0-9]{4}\s?){5}\s?"}},
            {CountryId.HU,
                new CountryInfo()
                { Name="Hungary", IbanPattern= @"HU[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){6}\s?"}},
            {CountryId.IS,
                new CountryInfo()
                { Name="Iceland", IbanPattern= @"IS[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){5}([0-9]{2})\s?"}},
            {CountryId.IE,
                new CountryInfo()
                { Name="Ireland", IbanPattern= @"IE[a-zA-Z0-9]{2}\s?([a-zA-Z0-9]{4}\s?){1}([0-9]{4}\s?){3}([0-9]{2})\s?"}},
            {CountryId.IL,
                new CountryInfo()
                { Name="Israel", IbanPattern= @"IL[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}([0-9]{3})\s?"}},
            {CountryId.IT,
                new CountryInfo()
                { Name="Italy", IbanPattern= @"IT[a-zA-Z0-9]{2}\s?([a-zA-Z]{1})([0-9]{3}\s?)([0-9]{4}\s?){1}([0-9]{3})([a-zA-Z0-9]{1}\s?)([a-zA-Z0-9]{4}\s?){2}([a-zA-Z0-9]{3})\s?"}},
            {CountryId.JO,
                new CountryInfo()
                { Name="Jordan", IbanPattern= @"JO[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([0-9]{4}\s?){5}([0-9]{2})\s?"}},
            {CountryId.KZ,
                new CountryInfo()
                { Name="Kazakhstan", IbanPattern= @"KZ[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){3}([0-9]{1})([a-zA-Z0-9]{3}\s?)([a-zA-Z0-9]{4}\s?){2}([a-zA-Z0-9]{2})\s?"}},
            {CountryId.XK,
                new CountryInfo()
                { Name="Kosovo", IbanPattern= @"XK[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){1}([0-9]{4}\s?){2}([0-9]{2})([0-9]{2}\s?)\s?"}},
            {CountryId.KW,
                new CountryInfo()
                { Name="Kuwait", IbanPattern= @"KW[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([a-zA-Z0-9]{4}\s?){5}([a-zA-Z0-9]{2})\s?"}},
            {CountryId.LV,
                new CountryInfo()
                { Name="Latvia", IbanPattern= @"LV[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([a-zA-Z0-9]{4}\s?){3}([a-zA-Z0-9]{1})\s?"}},
            {CountryId.LB,
                new CountryInfo()
                { Name="Lebanon", IbanPattern= @"LB[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){1}([a-zA-Z0-9]{4}\s?){5}\s?"}},
            {CountryId.LI,
                new CountryInfo()
                { Name="Liechtenstein", IbanPattern= @"LI[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){1}([0-9]{1})([a-zA-Z0-9]{3}\s?)([a-zA-Z0-9]{4}\s?){2}([a-zA-Z0-9]{1})\s?"}},
            {CountryId.LT,
                new CountryInfo()
                { Name="Lithuania", IbanPattern= @"LT[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}\s?"}},
            {CountryId.LU,
                new CountryInfo()
                { Name="Luxembourg", IbanPattern= @"LU[a-zA-Z0-9]{2}\s?([0-9]{3})([a-zA-Z0-9]{1}\s?)([a-zA-Z0-9]{4}\s?){3}\s?"}},
            {CountryId.MK,
                new CountryInfo()
                { Name="North Macedonia", IbanPattern= @"MK[a-zA-Z0-9]{2}\s?([0-9]{3})([a-zA-Z0-9]{1}\s?)([a-zA-Z0-9]{4}\s?){2}([a-zA-Z0-9]{1})([0-9]{2})\s?"}},
            {CountryId.MT,
                new CountryInfo()
                { Name="Malta", IbanPattern= @"MT[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([0-9]{4}\s?){1}([0-9]{1})([a-zA-Z0-9]{3}\s?)([a-zA-Z0-9]{4}\s?){3}([a-zA-Z0-9]{3})\s?"}},
            {CountryId.MR,
                new CountryInfo()
                { Name="Mauritania", IbanPattern= @"MR[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){5}([0-9]{3})\s?"}},
            {CountryId.MU,
                new CountryInfo()
                { Name="Mauritius", IbanPattern= @"MU[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([0-9]{4}\s?){4}([0-9]{3})([a-zA-Z]{1}\s?)([a-zA-Z]{2})\s?"}},
            {CountryId.MC,
                new CountryInfo()
                { Name="Monaco", IbanPattern= @"MC[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){2}([0-9]{2})([a-zA-Z0-9]{2}\s?)([a-zA-Z0-9]{4}\s?){2}([a-zA-Z0-9]{1})([0-9]{2})\s?"}},
            {CountryId.MD,
                new CountryInfo()
                { Name="Moldova", IbanPattern= @"MD[a-zA-Z0-9]{2}\s?([a-zA-Z0-9]{2})([a-zA-Z0-9]{2}\s?)([a-zA-Z0-9]{4}\s?){4}\s?"}},
            {CountryId.ME,
                new CountryInfo()
                { Name="Montenegro", IbanPattern= @"ME[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}([0-9]{2})\s?"}},
            {CountryId.NL,
                new CountryInfo()
                { Name="Netherlands", IbanPattern= @"NL[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([0-9]{4}\s?){2}([0-9]{2})\s?"}},
            {CountryId.NO,
                new CountryInfo()
                { Name="Norway", IbanPattern= @"NO[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){2}([0-9]{3})\s?"}},
            {CountryId.PK,
                new CountryInfo()
                { Name="Pakistan", IbanPattern= @"PK[a-zA-Z0-9]{2}\s?([a-zA-Z0-9]{4}\s?){1}([0-9]{4}\s?){4}\s?"}},
            {CountryId.PS,
                new CountryInfo()
                { Name="Palestine", IbanPattern= @"PS[a-zA-Z0-9]{2}\s?([a-zA-Z0-9]{4}\s?){1}([0-9]{4}\s?){5}([0-9]{1})\s?"}},
            {CountryId.PL,
                new CountryInfo()
                { Name="Poland", IbanPattern= @"PL[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){6}\s?"}},
            {CountryId.PT,
                new CountryInfo()
                { Name="Portugal", IbanPattern= @"PT[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){5}([0-9]{1})\s?"}},
            {CountryId.QA,
                new CountryInfo()
                { Name="Qatar", IbanPattern= @"QA[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([a-zA-Z0-9]{4}\s?){5}([a-zA-Z0-9]{1})\s?"}},
            {CountryId.RO,
                new CountryInfo()
                { Name="Romania", IbanPattern= @"RO[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([a-zA-Z0-9]{4}\s?){4}\s?"}},
            {CountryId.SM,
                new CountryInfo()
                { Name="San Marino", IbanPattern= @"SM[a-zA-Z0-9]{2}\s?([a-zA-Z]{1})([0-9]{3}\s?)([0-9]{4}\s?){1}([0-9]{3})([a-zA-Z0-9]{1}\s?)([a-zA-Z0-9]{4}\s?){2}([a-zA-Z0-9]{3})\s?"}},
            {CountryId.SA,
                new CountryInfo()
                { Name="Saudi Arabia", IbanPattern= @"SA[a-zA-Z0-9]{2}\s?([0-9]{2})([a-zA-Z0-9]{2}\s?)([a-zA-Z0-9]{4}\s?){4}\s?"}},
            {CountryId.RS,
                new CountryInfo()
                { Name="Serbia", IbanPattern= @"RS[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){4}([0-9]{2})\s?"}},
            {CountryId.SK,
                new CountryInfo()
                { Name="Slovakia", IbanPattern= @"SK[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){5}\s?"}},
            {CountryId.SI,
                new CountryInfo()
                { Name="Slovenia", IbanPattern= @"SI[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){3}([0-9]{3})\s?"}},
            {CountryId.ES,
                new CountryInfo()
                { Name="Spain", IbanPattern= @"ES[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){5}\s?"}},
            {CountryId.SE,
                new CountryInfo()
                { Name="Sweden", IbanPattern= @"SE[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){5}\s?"}},
            {CountryId.CH,
                new CountryInfo()
                { Name="Switzerland", IbanPattern= @"CH[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){1}([0-9]{1})([a-zA-Z0-9]{3}\s?)([a-zA-Z0-9]{4}\s?){2}([a-zA-Z0-9]{1})\s?"}},
            {CountryId.TN,
                new CountryInfo()
                { Name="Tunisia", IbanPattern= @"TN[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){5}\s?"}},
            {CountryId.TR,
                new CountryInfo()
                { Name="Turkey", IbanPattern= @"TR[a-zA-Z0-9]{2}\s?([0-9]{4}\s?){1}([0-9]{1})([a-zA-Z0-9]{3}\s?)([a-zA-Z0-9]{4}\s?){3}([a-zA-Z0-9]{2})\s?"}},
            {CountryId.AE,
                new CountryInfo()
                { Name="United Arab Emirates", IbanPattern= @"AE[a-zA-Z0-9]{2}\s?([0-9]{3})([0-9]{1}\s?)([0-9]{4}\s?){3}([0-9]{3})\s?"}},
            {CountryId.GB,
                new CountryInfo()
                { Name="United Kingdom", IbanPattern= @"GB[a-zA-Z0-9]{2}\s?([a-zA-Z]{4}\s?){1}([0-9]{4}\s?){3}([0-9]{2})\s?"}},
            {CountryId.VA,
                new CountryInfo()
                { Name="Vatican City", IbanPattern= @"VA[a-zA-Z0-9]{2}\s?([0-9]{3})([0-9]{1}\s?)([0-9]{4}\s?){3}([0-9]{2})\s?"}},
            {CountryId.VG,
                new CountryInfo()
                { Name="British Virgin Islands ", IbanPattern= @"VG[a-zA-Z0-9]{2}\s?([a-zA-Z0-9]{4}\s?){1}([0-9]{4}\s?){4}\s?"}}
        };

        public enum CountryId
        {
            AL,
            AD,
            AT,
            AZ,
            BH,
            BY,
            BE,
            BA,
            BR,
            BG,
            CR,
            HR,
            CY,
            CZ,
            DK,
            DO,
            TL,
            EE,
            FO,
            FI,
            FR,
            GE,
            DE,
            GI,
            GR,
            GL,
            GT,
            HU,
            IS,
            IE,
            IL,
            IT,
            JO,
            KZ,
            XK,
            KW,
            LV,
            LB,
            LI,
            LT,
            LU,
            MK,
            MT,
            MR,
            MU,
            MC,
            MD,
            ME,
            NL,
            NO,
            PK,
            PS,
            PL,
            PT,
            QA,
            RO,
            SM,
            SA,
            RS,
            SK,
            SI,
            ES,
            SE,
            CH,
            TN,
            TR,
            AE,
            GB,
            VA,
            VG
        }

        public struct CountryInfo
        {
            public String Name;
            public String IbanPattern;
        }
    }
}