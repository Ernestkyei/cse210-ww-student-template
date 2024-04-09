using System;

// Address class to store address details
class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {ZipCode}";
    }
}

// Base Event class
class Event
{
    // Private member variables
    private string title;
    private string description;
    private DateTime dateTime;
    private Address address;

    // Constructor
    public Event(string title, string description, DateTime dateTime, Address address)
    {
        this.title = title;
        this.description = description;
        this.dateTime = dateTime;
        this.address = address;
    }

    // Method to generate standard details message
    public virtual string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {dateTime.ToShortDateString()}\nTime: {dateTime.ToShortTimeString()}\nAddress: {address}";
    }

    // Method to generate short description message
    public virtual string GetShortDescription()
    {
        return $"Type: Event\nTitle: {title}\nDate: {dateTime.ToShortDateString()}";
    }
}

// Derived Lecture class
class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime dateTime, Address address, string speaker, int capacity)
        : base(title, description, dateTime, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    // Method to generate full details message for lecture
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// Derived Reception class
class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime dateTime, Address address, string rsvpEmail)
        : base(title, description, dateTime, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    // Method to generate full details message for reception
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

// Derived OutdoorGathering class
class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime dateTime, Address address, string weatherForecast)
        : base(title, description, dateTime, address)
    {
        this.weatherForecast = weatherForecast;
    }

    // Method to generate full details message for outdoor gathering
    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating address objects
        Address lectureAddress = new Address { Street = "123 Lecture Ave", City = "Cityville", State = "Stateville", ZipCode = "12345" };
        Address receptionAddress = new Address { Street = "456 Reception St", City = "Townville", State = "Stateville", ZipCode = "67890" };
        Address outdoorGatheringAddress = new Address { Street = "789 Park St", City = "Villageville", State = "Stateville", ZipCode = "13579" };

        // Creating event objects
        Event lectureEvent = new Lecture("Lecture on Science", "Exploring the wonders of science", new DateTime(2024, 4, 10, 14, 0, 0), lectureAddress, "Dr. Smith", 50);
        Event receptionEvent = new Reception("Grand Reception", "Join us for an evening of celebration", new DateTime(2024, 4, 15, 18, 0, 0), receptionAddress, "rsvp@example.com");
        Event outdoorGatheringEvent = new OutdoorGathering("Community Picnic", "Fun day out for all ages", new DateTime(2024, 4, 20, 12, 0, 0), outdoorGatheringAddress, "Sunny");

        // Generating and outputting marketing messages
        Console.WriteLine("Lecture Marketing Messages:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception Marketing Messages:");
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering Marketing Messages:");
        Console.WriteLine(outdoorGatheringEvent.GetStandardDetails());
        Console.WriteLine(outdoorGatheringEvent.GetFullDetails());
        Console.WriteLine(outdoorGatheringEvent.GetShortDescription());
    }
}
