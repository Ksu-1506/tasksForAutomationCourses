namespace Task7ForCourses
{
    class Country
    {
        public Country()
        {

        }
        public Country(string country, bool isTelenorSupported)
        {
            CountryName = country;
            IsTelenorSupported = isTelenorSupported;
        }
        public string CountryName { get; set; }
        public bool IsTelenorSupported { get; set; }

    }
}

