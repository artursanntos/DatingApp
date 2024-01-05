using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SendUsers(DataContext context) {
        if (await context.Users.AnyAsync()) return; // If there are any users in the database, return

        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json"); // Read the JSON file
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; // Create a new JsonSerializerOptions object
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options); // Deserialize the JSON file into a list of AppUser objects

        foreach (var user in users) // Loop through each user
        {
            using var hmac = new HMACSHA512(); // Create a new HMACSHA512 object
            user.UserName = user.UserName.ToLower(); // Set the username to lowercase
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd")); // Compute the password hash
            user.PasswordSalt = hmac.Key; // Set the password salt
            context.Users.Add(user); // Add the user to the database
        }

        await context.SaveChangesAsync(); // Save the changes
    }
}
