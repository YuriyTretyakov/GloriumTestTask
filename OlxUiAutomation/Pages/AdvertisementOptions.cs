using System;

namespace OlxUiAutomation.Pages
{
    public struct AdvertisementOptions
    {
        public string Title;
        public string Description;
        public string Location;
        public string Person;
        public string Heading;

        public override string ToString()
        {
            return string.Format("Title={0}\r\nDescription={1}\rnLocation={2}\rnPerson={3}\rnHeading={4}", Title,
                Description, Location, Person, Heading);
        }

        public void ValidateRequiredFields()
        {
            if (String.IsNullOrEmpty(Title) || String.IsNullOrEmpty(Description)
                || String.IsNullOrEmpty(Location) || String.IsNullOrEmpty(Person) || String.IsNullOrEmpty(Heading))
                throw new ArgumentException("Not all required fields were entered:\r\n" + ToString());
        }
    }
}
