using Microsoft.EntityFrameworkCore;
using SuggestionApp.Data;
using SuggestionApp.Models;

namespace SuggestionApp.Services
{
    public class SuggestionServices : ISuggestionServices
    {
        private readonly AppDbContext _context;

        public SuggestionServices(AppDbContext context  )
        {
            _context = context;
        }

        public async Task<List<Suggestion>> GetSuggestionsAsync()
        {
            var suggestions = await _context.Suggestions.ToListAsync();
            return suggestions;
        }

        public async Task<Suggestion> GetSuggestionById(int id)
        {
            var suggestion = await _context.Suggestions.FirstOrDefaultAsync(s => s.SuggestionId == id);
            return suggestion;
        }

        public async Task<Suggestion?> CreateSuggestionAsync(Suggestion suggestion)
        {
            try
            {
                var sug = await _context.Suggestions.AddAsync(suggestion);
                await _context.SaveChangesAsync();
                return suggestion;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Suggestion?> UpdateSuggestionAsync(Suggestion suggestion)
        {
            try
            {
                var sug = await _context.Suggestions.FirstOrDefaultAsync(s => s.SuggestionId == suggestion.SuggestionId);
                if (sug != null)
                {
                    var upsug = _context.Suggestions.Update(suggestion);
                    await _context.SaveChangesAsync();
                    return suggestion;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<bool> DeleteSuggestionAsync(Suggestion suggestion)
        {
            try
            {
                var sug = await _context.Suggestions.FirstOrDefaultAsync(s => s.SuggestionId == suggestion.SuggestionId);
                if (sug != null)
                {
                    _context.Suggestions.Remove(sug);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
    
}
