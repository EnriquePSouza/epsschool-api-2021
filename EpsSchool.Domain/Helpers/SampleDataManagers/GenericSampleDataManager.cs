using System;

namespace EpsSchool.Domain.Helpers
{
    public static class GenericSampleDataManager
    {
        public static readonly DateTime birthDate1 = DateTime.Parse("07/17/2005", new System.Globalization.CultureInfo("en-US"));
        public static readonly DateTime birthDate2 = DateTime.Parse("05/20/2006", new System.Globalization.CultureInfo("en-US"));
        
    }
}