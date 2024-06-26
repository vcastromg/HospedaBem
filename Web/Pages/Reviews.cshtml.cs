using System.Security.Claims;
using Application.Services;
using DataGeneration;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HexagonalArchitecture.Pages;

public class Reviews : PageModel
{
    private readonly ReviewService _reviewService;
    private readonly Generator _generator;

    public Reviews(ReviewService reviewService, Generator generator)
    {
        _reviewService = reviewService;
        _generator = generator;
    }

    public IList<Review> _reviews { get; set; }
    public List<Hotel> _hotels { get; set; }

    public void OnGet()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return;
        
        _reviews = _reviewService.GetReviewsByUser(userId);
        _hotels = _generator.GenerateHotelsList(_reviews.Count);
    }
}