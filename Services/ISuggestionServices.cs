using SuggestionApp.Models;

namespace SuggestionApp.Services
{
    public interface ISuggestionServices
    {
        Task<List<Suggestion>> GetSuggestionsAsync();
        Task<Suggestion?> GetSuggestionById(int id);
        Task<Suggestion?> CreateSuggestionAsync(Suggestion suggestion);
        Task<Suggestion?> UpdateSuggestionAsync(Suggestion suggestion);
        Task<bool> DeleteSuggestionAsync(Suggestion suggestion);
    }
}