# MisCsharp
Various C# snippets which may be useful. It's also may be a little spaghetti.
___

1. ## IBAN
    - A Class snippet for "Regular Expressions" (Regex) matches to find "International Bank Account Numbers" (IBAN).
    - Contains: 
        1. Regex pettern to detect a possible IBAN
        2. Enum for 72 "CountryIDs" (DE,FR,IT,ES,GB...)
        3. A struct "CountryInfo" to relate an IBAN to ther origen country
        4. An Dictionary <CountryId, CountryInfo>
     - Example: 
        ```cs
                    String stringWithIBAN = "transferring 100€ to DE89 3704 0044 0532 0130 00 12:00 01-01-2020";
                    
                    //Returns a possible valid IBAN "DE89 3704 0044 0532 0130 00 12" " 12" is too much.
                    var regex = Regex.Match(stringWithIBAN, standardIBANpattern);

                    CountryInfo cInfo;
                    //Generate a List<CountryId> which contains every Values of this enum and return the one 
                    //"Where" match the first two chars of the IBAN [DE]
                    CountryId cID = ((CountryId[])Enum.GetValues(typeof(CountryId))).ToList().Where(x => 
                    x.ToString() == regex.Value.Substring(0, 2)).First(); //Spaghetti
                    Countries.TryGetValue(cID, out cInfo);

                    //Returns a valid IBAN
                    regex = Regex.Match(regex.Value, cInfo.IbanPattern); 

                    If(regex.Value =! "")
                    {
                    string IBAN = regex.Value; //DE89 3704 0044 0532 0130 00
                    string Country = cID.toString(); //DE
                    string CountryName = ci.Name; //Germany
                    }
2. ## TBA
