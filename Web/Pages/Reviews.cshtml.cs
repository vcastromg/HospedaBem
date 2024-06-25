using System.Security.Claims;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HexagonalArchitecture.Pages;

public class Reviews : PageModel
{
    private readonly ReviewService _reviewService;

    public Reviews(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    
    public IEnumerable<Review> _reviews { get; set; }

    public void OnGet()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _reviews = _reviewService.GetReviewsByUser(userId);
    }
}