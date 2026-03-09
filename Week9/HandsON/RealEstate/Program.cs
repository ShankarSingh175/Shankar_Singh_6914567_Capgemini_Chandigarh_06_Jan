using System;
using System.Collections.Generic;
using System.Linq;

public class RealEstateListing
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Location { get; set; }

    public RealEstateListing(int id, string title, string description, int price, string location)
    {
        ID = id;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
    }
}
public class RealEstateApp
{
    private List<RealEstateListing> listings = new List<RealEstateListing>();

    // Add listing
    public void AddListing(RealEstateListing listing)
    {
        listings.Add(listing);
    }

    // Remove listing by ID
    public void RemoveListing(int listingID)
    {
        var listing = listings.Find(l => l.ID == listingID);

        if (listing != null)
            listings.Remove(listing);
    }

    // Update listing
    public void UpdateListing(RealEstateListing updatedListing)
    {
        var listing = listings.Find(l => l.ID == updatedListing.ID);

        if (listing != null)
        {
            listing.Title = updatedListing.Title;
            listing.Description = updatedListing.Description;
            listing.Price = updatedListing.Price;
            listing.Location = updatedListing.Location;
        }
    }

    // Return all listings
    public List<RealEstateListing> GetListings()
    {
        return listings;
    }

    // Filter by location
    public List<RealEstateListing> GetListingsByLocation(string location)
    {
        return listings
            .Where(l => l.Location.ToLower() == location.ToLower())
            .ToList();
    }

    // Filter by price range
    public List<RealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        return listings
            .Where(l => l.Price >= minPrice && l.Price <= maxPrice)
            .ToList();
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        RealEstateApp app = new RealEstateApp();

        app.AddListing(new RealEstateListing(1, "Luxury Villa", "Sea view villa", 900000, "Goa"));
        app.AddListing(new RealEstateListing(2, "City Apartment", "2BHK apartment", 450000, "Mumbai"));
        app.AddListing(new RealEstateListing(3, "Farm House", "Large farm house", 600000, "Goa"));

        Console.WriteLine("All Listings:");

        foreach (var l in app.GetListings())
        {
            Console.WriteLine($"{l.ID} {l.Title} {l.Location} {l.Price}");
        }

        Console.WriteLine("\nListings in Goa:");

        foreach (var l in app.GetListingsByLocation("Goa"))
        {
            Console.WriteLine($"{l.Title} - {l.Price}");
        }

        Console.WriteLine("\nListings between 400000 and 700000:");

        foreach (var l in app.GetListingsByPriceRange(400000, 700000))
        {
            Console.WriteLine($"{l.Title} - {l.Price}");
        }
    }
}