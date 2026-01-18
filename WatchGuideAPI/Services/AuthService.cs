using WatchGuideAPI.Data;
using WatchGuideAPI.DTOs;
using WatchGuideAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WatchGuideAPI.Services
{
    // Contract for authentication-related operations
    public interface IAuthService
    {
        Task<AuthResponse> Register(RegisterRequest request);
        Task<AuthResponse> Login(LoginRequest request);
    }

    // Handles user registration and login logic
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AuthResponse> Register(RegisterRequest request)
        {
            // Check if email or username already exists
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Email == request.Email ||
                    u.Username == request.Username);

            if (existingUser != null)
                throw new Exception("User already exists");

            // Hash password before saving
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Create new user entity
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Return safe response (no password)
            return new AuthResponse
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Message = "Registration successful"
            };
        }

        public async Task<AuthResponse> Login(LoginRequest request)
        {
            // Find user by username
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
                throw new Exception("Invalid email or password");

            // Verify password hash
            bool isValid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash
            );

            if (!isValid)
                throw new Exception("Invalid email or password");

            return new AuthResponse
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Message = "Login successful"
            };
        }
    }
}